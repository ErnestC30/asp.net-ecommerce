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
        private readonly IAddressService _addressService;
        private readonly IAuthService _authService;

        public AccountsController(IAddressService addressService, IAuthService authService)
        {
            _addressService = addressService;
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var loginResponse = await _authService.LoginUser(loginDto.Email, loginDto.Password);

                if (!loginResponse.IsValid) return BadRequest(loginResponse.Message);

                _authService.AddTokensToCookie(Response, loginResponse.JwtToken, loginResponse.JwtTokenExpire, loginResponse.JwtRefreshToken, loginResponse.JwtRefreshTokenExpire);

                // Should remove this dto after finished implementation since tokens are stored as cookies
                return Ok(new UserAccessDto
                {
                    AccessToken = loginResponse.JwtToken,
                    RefreshToken = loginResponse.JwtRefreshToken
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var registerResponse = await _authService.RegisterUser(registerDto.Email, registerDto.Password);

                if (!registerResponse.IsValid) return BadRequest(registerResponse.Message);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
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
            try
            {
                await _authService.DeleteUser(id);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
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