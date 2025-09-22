namespace backend.Models.ProductDto;

public class ProductModificationDto
{
    public required string Name { get; set; }
    public string? Description { get; set; } = "";
    public required decimal Price { get; set; }
    public decimal? DiscountPrice { get; set; }
    public required int Quantity { get; set; }
    public required bool IsActive { get; set; }
    public long? CategoryId { get; set; }
}