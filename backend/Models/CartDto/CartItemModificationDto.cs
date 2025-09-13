namespace backend.Models;

public class CartItemModificationDto
{
    [Required]
    public Guid ProductUuid { get; set; }
    [Required]
    [Range(1, 100, ErrorMessage = "Quantity must be between 0 and 100")]
    public int Quantity { get; set; }
}