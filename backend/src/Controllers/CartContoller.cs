using Microsoft.AspNetCore.Identity;

using backend.Extensions;
using backend.Interfaces;
using backend.Services;
using backend.Models;
using backend.Models.CartDto;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<CartDisplayDto>> GetCart()
        {
            var userId = User.GetUserId();

            if (userId == null) return Unauthorized();

            var cart = await _cartService.GetCartByUserId(userId);
            var cartDto = _cartService.CartToCartDisplayDto(cart);

            return Ok(cartDto);

        }

        [HttpPut("addItem")]
        [Authorize]
        public async Task<IActionResult> AddItemToCart([FromBody] CartItemModificationDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var userId = User.GetUserId();

            if (userId == null) return Unauthorized();

            try
            {
                await _cartService.AddItemToCart(userId, dto.ProductUuid, dto.Quantity);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
            return NoContent();

        }

        [HttpPut("subtractItem")]
        [Authorize]
        public async Task<IActionResult> SubtractItemFromCart([FromBody] CartItemModificationDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var userId = User.GetUserId();

            if (userId == null) return Unauthorized();

            try
            {
                await _cartService.SubtractItemFromCart(userId, dto.ProductUuid, dto.Quantity);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
            return NoContent();
        }

        // public Task<IActionResult> UpdateCart()
        // {

        // }

        // public Task<IActionResult> DeleteCart()
        // {

        // }



    }
}