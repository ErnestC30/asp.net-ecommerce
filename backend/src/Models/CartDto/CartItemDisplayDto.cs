namespace backend.Models.CartDto;

public class CartItemDisplayDto
{
    public required int Quantity { get; set; }
    public required CartProductDto Product { get; set; }
}