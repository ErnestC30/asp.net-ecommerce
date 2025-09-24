using Microsoft.AspNetCore.Identity;

using backend.Interfaces;
using backend.Services;
using backend.Models;
using backend.Models.AccountDto;
using backend.Extensions;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ApiDbContext _context;
        private readonly SignInManager<AppUser> _signinManager;
        private readonly ITokenService _tokenService;
        private readonly IAddressService _addressService;


        public AccountsController(UserManager<AppUser> userManager, ApiDbContext context, SignInManager<AppUser> signInManager, ITokenService tokenService, IAddressService addressService)
        {
            _userManager = userManager;
            _context = context;
            _signinManager = signInManager;
            _tokenService = tokenService;
            _addressService = addressService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == loginDto.Email);
            if (user == null) return Unauthorized("Invalid email or password.");

            var result = await _signinManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if (!result.Succeeded) return Unauthorized("Invalid email or password.");

            // change this to cookie instead of token?
            // - then pass user email / some dto for frontend to store basic user info
            var refreshToken = new RefreshToken
            {
                Token = _tokenService.GenerateRefreshToken(),
                UserId = user.Id,
                ExpiresOnUtc = DateTime.UtcNow.AddDays(7)
            };

            _context.RefreshTokens.Add(refreshToken);
            await _context.SaveChangesAsync();

            var accessToken = await _tokenService.CreateToken(user);

            return Ok(new UserAccessDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken.Token
            });

        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);


                if (string.IsNullOrEmpty(registerDto.Email) || string.IsNullOrEmpty(registerDto.Password))
                {
                    return BadRequest(ModelState);
                }

                var appUser = new AppUser
                {
                    UserName = registerDto.Email,
                    Email = registerDto.Email,
                    RegistrationDate = DateTime.UtcNow
                };

                var createdUser = await _userManager.CreateAsync(appUser, registerDto.Password);

                if (createdUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(appUser, "User");
                    if (roleResult.Succeeded)
                    {
                        return Ok();
                    }
                    else
                    {
                        return StatusCode(500, roleResult.Errors);
                    }
                }
                else
                {
                    return StatusCode(500, createdUser.Errors);
                }

            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        // [HttpGet]
        // public async Task<IActionResult> Logout()
        // {

        // }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var userForDelete = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (userForDelete == null)
            {
                return BadRequest();
            }

            await _userManager.DeleteAsync(userForDelete);
            return Ok();
        }

        [HttpPost("addresses")]
        [Authorize]
        public async Task<IActionResult> CreateUserAddress([FromBody] UserAddressCreateDto createDto)
        {
            var userId = User.GetUserId();
            if (userId == null) return BadRequest();

            try
            {
                await _addressService.CreateUserAddress(createDto, userId);
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpGet("addresses")]
        [Authorize]
        public async Task<IActionResult> GetUserAddresses()
        {
            var userId = User.GetUserId();
            if (userId == null) return BadRequest();

            try
            {
                var addressesDto = await _addressService.GetUserAddresses(userId);
                return Ok(addressesDto);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("addresses/{addressGuid}")]
        [Authorize]
        public async Task<IActionResult> EditUserAddress([FromBody] UserAddressEditDto editDto, string addressGuid)
        {
            var userId = User.GetUserId();
            if (userId == null) return BadRequest();

            try
            {
                await _addressService.EditUserAddress(editDto, addressGuid, userId);
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("addresses/{addressGuid}")]
        [Authorize]
        public async Task<IActionResult> DeleteUserAddress(string addressGuid)
        {
            try
            {
                await _addressService.DeleteUserAddress(addressGuid);
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}