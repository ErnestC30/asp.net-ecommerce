using backend.Models.CategoryDto;

namespace backend.Models.ProductDto;

public class ProductDetailDto
{
    public long Id { get; set; }
    public Guid Uuid { get; set; }
    public required string Name { get; set; }
    public required string Slug { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public decimal DiscountPrice { get; set; }
    public int Quantity { get; set; }
    public bool IsActive { get; set; }

    public CategoryInfoDto? Category { get; set; }
}