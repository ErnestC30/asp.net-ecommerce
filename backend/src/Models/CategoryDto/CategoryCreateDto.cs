namespace backend.Models.CategoryDto;

public class CategoryCreateDto
{
    public required string Name { get; set; }
    public string? Description { get; set; }
}
