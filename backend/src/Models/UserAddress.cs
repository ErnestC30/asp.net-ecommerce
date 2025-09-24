namespace backend.Models;

public class UserAddress : BaseEntity
{
    public int Id { get; set; }
    public required Guid Uuid { get; set; }
    public required string UserId { get; set; }
    public AppUser? User { get; set; }
    public required string Line1 { get; set; }
    public required string? Line2 { get; set; }
    public required string Country { get; set; }
    public required string City { get; set; }
    public required string PostalCode { get; set; }
    public bool IsPrimary { get; set; }
}
