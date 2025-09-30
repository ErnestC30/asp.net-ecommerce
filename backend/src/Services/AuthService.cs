using backend.Interfaces;
using backend.Models;
using Microsoft.AspNetCore.Identity;

namespace backend.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signinManager;
    private readonly ApiDbContext _context;
    private readonly IConfiguration _config;
    private readonly ITokenService _tokenService;
    public AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ApiDbContext context, IConfiguration config, ITokenService tokenService)
    {
        _userManager = userManager;
        _signinManager = signInManager;
        _context = context;
        _config = config;
        _tokenService = tokenService;

    }

    public async Task<LoginRegisterResponse> LoginUser(string email, string password)
    {
        var response = new LoginRegisterResponse();

        var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == email);
        if (user == null)
        {
            response.Message = "Invalid email or password";
            return response;
        }

        var result = await _signinManager.CheckPasswordSignInAsync(user, password, false);
        if (!result.Succeeded)
        {
            response.Message = "Invalid email or password";
            return response;
        }

        // Valid user login

        var refreshToken = new RefreshToken
        {
            Token = _tokenService.GenerateRefreshToken(),
            UserId = user.Id,
            ExpiresOnUtc = DateTime.UtcNow.AddDays(7)
        };

        _context.RefreshTokens.Add(refreshToken);
        await _context.SaveChangesAsync();

        var expirationTime = DateTime.UtcNow.AddMinutes(_config.GetValue<int>("JWT:ExpirationTimeInMinutes"));
        var jwtToken = await _tokenService.CreateToken(user, expirationTime);

        response.IsValid = true;
        response.JwtToken = jwtToken;
        response.JwtTokenExpire = expirationTime;
        response.JwtRefreshToken = refreshToken.Token;
        response.JwtRefreshTokenExpire = refreshToken.ExpiresOnUtc;
        return response;
    }

    public async Task<LoginRegisterResponse> LogoutUser(string userId, string? refreshToken)
    {
        var response = new LoginRegisterResponse();

        var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == userId);
        if (user == null)
        {
            response.Message = "User not found";
            return response;
        }

        // Remove refresh token for that device if available
        var token = await _context.RefreshTokens.Where(t => t.User == user).Where(t => t.Token == refreshToken).FirstOrDefaultAsync();
        if (token == null)
        {
            response.Message = "Invalid response token";
        }

        response.IsValid = true;
        response.Message = "User has been signed out.";
        await _signinManager.SignOutAsync();

        return response;
    }

    public async Task<LoginRegisterResponse> RegisterUser(string email, string password)
    {
        var response = new LoginRegisterResponse();

        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            response.Message = "Missing email or password";
            return response;
        }

        var appUser = new AppUser
        {
            UserName = email,
            Email = email,
            RegistrationDate = DateTime.UtcNow
        };

        var createdUser = await _userManager.CreateAsync(appUser, password);
        if (!createdUser.Succeeded)
        {
            response.Message = string.Join(" ", createdUser.Errors);
            return response;
        }

        var roleResult = await _userManager.AddToRoleAsync(appUser, "User");
        if (!roleResult.Succeeded)
        {
            response.Message = string.Join(" ", roleResult.Errors);
            return response;
        }

        // Valid user registration

        response.IsValid = true;
        return response;
    }

    public async Task DeleteUser(string userId)
    {
        var userForDelete = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == userId);

        if (userForDelete == null) throw new Exception("User with Id not found");

        await _userManager.DeleteAsync(userForDelete);
    }

    public HttpResponse CreateOrUpdateJwtTokenCookies(HttpResponse response, string jwtToken, DateTime jwtTokenExpire, string jwtResponseToken, DateTime jwtResponseTokenExpire)
    {
        var jwtTokenCookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.Strict,
            Expires = jwtTokenExpire
        };

        var refreshTokenCookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.Strict,
            Expires = jwtResponseTokenExpire
        };

        response.Cookies.Append(_config.GetValue<string>("JWT:JwtCookieName") ?? "jwtToken", jwtToken, jwtTokenCookieOptions);
        response.Cookies.Append(_config.GetValue<string>("JWT:RefreshCookieName") ?? "refreshToken", jwtResponseToken, refreshTokenCookieOptions);
        return response;
    }

    public HttpResponse RemoveJwtTokenCookies(HttpResponse response)
    {
        response.Cookies.Delete(_config.GetValue<string>("JWT:JwtCookieName") ?? "jwtToken");
        response.Cookies.Delete(_config.GetValue<string>("JWT:RefreshCookieName") ?? "refreshToken");

        return response;
    }

    public async Task<LoginRegisterResponse> RefreshJwtToken(string userId, string refreshToken)
    {
        var response = new LoginRegisterResponse();

        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
        {
            response.Message = "Unable to refresh user, please log in again.";
            return response;
        }

        var token = await _context.RefreshTokens.Where(t => t.UserId == user.Id).Where(t => t.Token == refreshToken).FirstOrDefaultAsync();
        if (token == null || token.ExpiresOnUtc <= DateTime.UtcNow)
        {
            response.Message = "Unable to refresh user, please log in again.";
            return response;
        }

        // Valid refresh token
        // Current implementation does not renew the refresh token when creating a new jwt token

        var expirationTime = DateTime.UtcNow.AddMinutes(_config.GetValue<int>("JWT:ExpirationTimeInMinutes"));
        var jwtToken = await _tokenService.CreateToken(user, expirationTime);

        response.IsValid = true;
        response.Message = "Jwt token refreshed.";
        response.JwtRefreshToken = refreshToken;
        response.JwtRefreshTokenExpire = token.ExpiresOnUtc;
        response.JwtToken = jwtToken;
        response.JwtTokenExpire = expirationTime;

        return response;

    }
}
