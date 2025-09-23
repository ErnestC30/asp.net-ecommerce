namespace backend.Models.OrderDto;

public class OrderLineItemViewDto
{
    public required string ProductUuid { get; set; }
    public required string Name { get; set; }
    public required Decimal Price { get; set; }
    public Decimal? DiscountPrice { get; set; } = null;
    public required int Quantity { get; set; }

}
