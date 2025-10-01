using NpgsqlTypes;

namespace backend.Models;

public class Product : BaseEntity
{
    public long Id { get; set; }
    public Guid Uuid { get; set; }
    public required string Name { get; set; }
    public string? Slug { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public decimal? DiscountPrice { get; set; }
    public int Quantity { get; set; }
    public bool IsActive { get; set; }
    public long? CategoryId { get; set; }
    public Category? Category { get; set; }
    public ICollection<ProductImage> Images { get; } = new List<ProductImage>();
}