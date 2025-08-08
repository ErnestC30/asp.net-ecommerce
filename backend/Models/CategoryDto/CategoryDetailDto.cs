namespace backend.Models.CategoryDto;

public class CategoryDetailDto
{
    public long Id { get; set; }
    public required string Name { get; set; }
    public required string Slug { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public ICollection<Product> Products { get; set; } = new List<Product>(); // should return a Dto here as well?

}
