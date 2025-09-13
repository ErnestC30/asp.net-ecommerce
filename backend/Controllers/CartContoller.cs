using Microsoft.AspNetCore.Identity;

using backend.Extensions;
using backend.Interfaces;
using backend.Services;
using backend.Models;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ApiDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICartService _cartService;

        public CartController(UserManager<AppUser> userManager, ApiDbContext context, IHttpContextAccessor httpContextAccessor, ICartService cartService)
        {
            _userManager = userManager;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _cartService = cartService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetCart()
        {
            var userClaims = _httpContextAccessor.HttpContext!.User;
            var userId = userClaims.GetUserId();

            var cart = await _cartService.GetCartByUserId(userId);

            // return cart dto
            return Ok();

        }

        [HttpPut("addItem")]
        [Authorize]
        public async Task<IActionResult> AddItemToCart([FromBody] CartItemModificationDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var userClaims = _httpContextAccessor.HttpContext!.User;
            var userId = userClaims.GetUserId();

            try
            {
                await _cartService.AddItemToCart(userId, dto.ProductUuid, dto.Quantity);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
            return Ok();

        }

        [HttpPut("subtractItem")]
        [Authorize]
        public async Task<IActionResult> SubtractItemFromCart([FromBody] CartItemModificationDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var userClaims = _httpContextAccessor.HttpContext!.User;
            var userId = userClaims.GetUserId();
            try
            {
                await _cartService.SubtractItemFromCart(userId, dto.ProductUuid, dto.Quantity);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
            return Ok();
        }

        // public Task<IActionResult> UpdateCart()
        // {

        // }

        // public Task<IActionResult> DeleteCart()
        // {

        // }



    }
}