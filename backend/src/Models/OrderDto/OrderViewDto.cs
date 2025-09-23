namespace backend.Models.OrderDto;
public class OrderViewDto
{
    public ICollection<OrderLineItemViewDto> LineItems { get; set; } = new List<OrderLineItemViewDto>();
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string PaymentProvider { get; set; }
    public required string BillingLine1 { get; set; }
    public required string? BillingLine2 { get; set; }
    public required string BillingCountry { get; set; }
    public required string BillingCity { get; set; }
    public required string BillingPostalCode { get; set; }
    public required string ShippingLine1 { get; set; }
    public required string? ShippingLine2 { get; set; }
    public required string ShippingCountry { get; set; }
    public required string ShippingCity { get; set; }
    public required string ShippingPostalCode { get; set; }
}
