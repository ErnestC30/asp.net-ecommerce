namespace backend.Models.CategoryDto;

public class CategoryInfoDto
{
    public required string Name { get; set; }
    public required string Slug { get; set; }
    public string? Description { get; set; }
}
