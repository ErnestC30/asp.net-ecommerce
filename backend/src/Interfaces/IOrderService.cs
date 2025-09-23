using backend.Models.OrderDto;

namespace backend.Interfaces;

public interface IOrderService
{
    public Task<OrderViewDto> CreateOrder(OrderCreateDto orderCreateDto, string? userId);
    public Task<ICollection<OrderStatusViewDto>> GetOrderStatusOptions();
}
