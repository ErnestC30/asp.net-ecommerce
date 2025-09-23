namespace backend.Models;

public class OrderLineItem
{
    public long Id { get; set; }
    public required long OrderId { get; set; }
    public Order? Order { get; set; }
    public required string ProductUuid { get; set; }
    public required string Name { get; set; }
    public required Decimal Price { get; set; }
    public Decimal? DiscountPrice { get; set; }
    [Range(1, 99)]
    public required int Quantity { get; set; }
}
