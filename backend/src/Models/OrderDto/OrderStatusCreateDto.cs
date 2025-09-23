namespace backend.Models.OrderDto;

public class OrderStatusCreateDto
{
    public required String Name { get; set; }
    public String? Slug { get; set; }
}
