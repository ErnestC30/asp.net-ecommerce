namespace backend.Models.CategoryDto;

public class CategoryDto
{
    public required string Name { get; set; }
    public required string Slug { get; set; }
    public string? Description { get; set; }
}
