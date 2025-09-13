namespace backend.Models;

public class CartItem
{
    public long Id { get; set; }
    [Range(1, 100, ErrorMessage = "Quantity must be between 1 and 100.")]
    public required int Quantity { get; set; }
    public required long ProductId { get; set; }
    public required Product Product { get; set; }
    public required long CartId { get; set; }
    public required Cart Cart { get; set; }

}