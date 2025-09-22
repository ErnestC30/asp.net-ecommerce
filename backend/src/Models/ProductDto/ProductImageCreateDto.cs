namespace backend.Models.ProductDto;
public class ProductImageCreateDto
{
    public required IFormFile File { get; set; }
    public int Order { get; set; } = 0;
}