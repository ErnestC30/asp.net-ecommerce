namespace backend.Models.OrderDto
{
    public class OrderLineItemCreateDto
    {
        public required string ProductUuid { get; set; }
        public required string Name { get; set; }
        public required Decimal Price { get; set; }
        public Decimal? DiscountPrice { get; set; } = null;
        [Range(1, 99)]
        public required int Quantity { get; set; }

    }
}
