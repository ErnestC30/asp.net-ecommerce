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
        var accessToken = await _tokenService.CreateToken(user, expirationTime);

        response.IsValid = true;
        response.JwtToken = accessToken;
        response.JwtTokenExpire = expirationTime;
        response.JwtRefreshToken = refreshToken.Token;
        response.JwtRefreshTokenExpire = refreshToken.ExpiresOnUtc;
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

    public HttpResponse AddTokensToCookie(HttpResponse response, string jwtToken, DateTime jwtTokenExpire, string jwtResponseToken, DateTime jwtResponseTokenExpire)
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

        response.Cookies.Append("jwtToken", jwtToken, jwtTokenCookieOptions);
        response.Cookies.Append("refreshToken", jwtResponseToken, refreshTokenCookieOptions);
        return response;
    }
}
