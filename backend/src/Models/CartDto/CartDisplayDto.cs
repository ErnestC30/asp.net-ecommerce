namespace backend.Models.CartDto;

public class CartDisplayDto
{
    public List<CartItemDisplayDto> Items { get; set; } = new List<CartItemDisplayDto>();
}