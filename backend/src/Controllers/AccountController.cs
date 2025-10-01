using backend.Extensions;
using backend.Interfaces;
using backend.Models.AccountDto;


namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAddressService _addressService;
        private readonly IAuthService _authService;
        private readonly IConfiguration _config;

        public AccountsController(IAddressService addressService, IAuthService authService, IConfiguration config)
        {
            _addressService = addressService;
            _authService = authService;
            _config = config;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var loginResponse = await _authService.LoginUser(loginDto.Email, loginDto.Password);

                if (!loginResponse.IsValid) return BadRequest(loginResponse.Message);

                _authService.CreateOrUpdateJwtTokenCookies(Response, loginResponse.JwtToken, loginResponse.JwtTokenExpire, loginResponse.JwtRefreshToken, loginResponse.JwtRefreshTokenExpire);

                return Ok();
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

        [HttpPost("refreshToken")]
        public async Task<IActionResult> Refresh()
        {
            var userId = User.GetUserId();
            if (userId == null) return BadRequest();

            var refreshToken = Request.Cookies[_config.GetValue<string>("JWT:RefreshCookieName") ?? "refreshToken"];
            if (refreshToken == null) return BadRequest("Missing refresh token cookie.");

            try
            {
                var loginResponse = await _authService.RefreshJwtToken(userId, refreshToken);

                if (!loginResponse.IsValid) return BadRequest(loginResponse.Message);

                _authService.CreateOrUpdateJwtTokenCookies(Response, loginResponse.JwtToken, loginResponse.JwtTokenExpire, loginResponse.JwtRefreshToken, loginResponse.JwtRefreshTokenExpire);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {

            var userId = User.GetUserId();
            if (userId == null) return BadRequest();

            var response = await _authService.LogoutUser(userId, Request.Cookies[_config.GetValue<string>("JWT:RefreshCookieName") ?? "refreshToken"]);

            if (!response.IsValid)
            {
                return BadRequest(response.Message);
            }
            _authService.RemoveJwtTokenCookies(Response);

            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            try
            {
                await _authService.DeleteUser(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpGet("addresses")]
        [Authorize]
        public async Task<IActionResult> GetUserAddresses()
        {
            var userId = User.GetUserId();
            if (userId == null) return BadRequest();

            try
            {
                var user = await _addressService.GetAppUser(userId);
                var addressesDto = await _addressService.GetUserAddresses(user);
                return Ok(addressesDto);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("addresses")]
        [Authorize]
        public async Task<IActionResult> CreateUserAddress([FromBody] UserAddressCreateDto createDto)
        {
            var userId = User.GetUserId();
            if (userId == null) return BadRequest();

            try
            {
                var user = await _addressService.GetAppUser(userId);
                await _addressService.CreateUserAddress(createDto, user);
                return NoContent();
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
                var user = await _addressService.GetAppUser(userId);
                await _addressService.EditUserAddress(editDto, addressGuid, user);
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