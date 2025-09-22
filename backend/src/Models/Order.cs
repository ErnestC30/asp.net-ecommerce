namespace backend.Models;

public class Order : BaseEntity 
{
    public long Id { get; set; }
    public string? UserId { get; set; }
    public AppUser? User { get; set; }
    public long? CartId { get; set; }
    public required string RefId { get; set; }
    public long OrderStatusId { get; set; }
    public required OrderStatus? OrderStatus { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required Decimal Amount { get; set; }
    public required string PaymentProvider { get; set; }
    public required Address BillingAddress { get; set; }
    public required Address ShippingAddress { get; set; }
    public ICollection<OrderLineItem> LineItems { get; } = new List<OrderLineItem>();
}

[Owned]
public class Address
{
    public required string Line1 { get; set; }
    public required string? Line2 { get; set; }
    public required string Country { get; set; }
    public required string City { get; set; }
    public required string PostalCode { get; set; }
}