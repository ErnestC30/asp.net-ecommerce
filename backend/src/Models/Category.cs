namespace backend.Models;

public class Category : BaseEntity
{
    public long Id { get; set; }
    public required string Name { get; set; }
    public string Slug { get; set; } = default!;
    public string? Description { get; set; }

    public ICollection<Product> Products { get; } = new List<Product>();
}