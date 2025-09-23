using System.Runtime.InteropServices.Swift;

namespace backend.Models;

public class Order : BaseEntity 
{
    public long Id { get; set; }
    public string? UserId { get; set; }
    public AppUser? User { get; set; }
    public required string RefId { get; set; } // Should be generated when creating order for public reference
    public long OrderStatusId { get; set; }
    public OrderStatus? OrderStatus { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required Decimal Amount { get; set; }
    public required string PaymentProvider { get; set; }
    public required Address BillingAddress { get; set; }
    public required Address ShippingAddress { get; set; }
    public ICollection<OrderLineItem> LineItems { get; set; } = new List<OrderLineItem>();
    
    public void AddLineItem(string productUuid, string name, Decimal price, Decimal? discountPrice, int quantity)
    {
        var lineItem = new OrderLineItem
        {
            OrderId = this.Id,
            ProductUuid = productUuid,
            Name = name,
            Price = price,
            DiscountPrice = discountPrice,
            Quantity = quantity,
        };

        LineItems.Add(lineItem);
    }
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