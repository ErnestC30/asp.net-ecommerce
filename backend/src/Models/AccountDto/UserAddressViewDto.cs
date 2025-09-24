namespace backend.Models.AccountDto;

public class UserAddressViewDto
{
    public Guid Uuid { get; set; }
    public required string Line1 { get; set; }
    public required string? Line2 { get; set; }
    public required string Country { get; set; }
    public required string City { get; set; }
    public required string PostalCode { get; set; }
    public required bool IsPrimary { get; set; }
}
