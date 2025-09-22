namespace backend.Models;

public class OrderStatus
{
    public long Id { get; set; }
    public required string Name { get; set; }
    public required string Slug { get; set; }
    public ICollection<Order> Orders { get; set; } = new List<Order>();

}
