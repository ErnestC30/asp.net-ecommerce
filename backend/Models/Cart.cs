namespace backend.Models;

public class Cart : BaseEntity
{
    public long Id { get; set; }
    public string? UserId { get; set; }
    public AppUser? AppUser { get; set; }
    public ICollection<CartItem> Items { get; set; } = new List<CartItem>();
}