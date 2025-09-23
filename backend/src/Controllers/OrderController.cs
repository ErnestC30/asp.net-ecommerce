using backend.Extensions;
using backend.Interfaces;
using backend.Models.OrderDto;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IOrderService _orderService;

        public OrderController(IHttpContextAccessor httpContextAccessor, IOrderService orderService)
        {
            _httpContextAccessor = httpContextAccessor;
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] OrderCreateDto orderCreateDto)
        {

            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var userId = User.GetUserId();
                var orderDto = await _orderService.CreateOrder(orderCreateDto, userId);

                return Ok(orderDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("StatusOptions")]
        public async Task<IActionResult> GetOrderStatusOptions()
        {
            var optionsDto = await _orderService.GetOrderStatusOptions();
            return Ok(optionsDto);
        }

    }
}
