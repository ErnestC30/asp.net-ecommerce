using backend.Models.CategoryDto;

namespace backend.Models.ProductDto;

public class CreateProductDto
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public decimal? DiscountPrice { get; set; }
    public int Quantity { get; set; }
    public bool IsActive { get; set; }
    public long CategoryId { get; set; }
}