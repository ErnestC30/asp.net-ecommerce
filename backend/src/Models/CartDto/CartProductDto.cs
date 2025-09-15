namespace backend.Models.CartDto;

public class CartProductDto
{
    public Guid Uuid { get; set; }
    public string? Name { get; set; } = "";
    public decimal Price { get; set; }
    public decimal? DiscountPrice { get; set; }
}