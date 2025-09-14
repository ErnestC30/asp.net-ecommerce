using System.ComponentModel.DataAnnotations;

namespace backend.Models;

public class ProductImage
{
    public long Id { get; set; }
    [Required]
    public required string Url { get; set; }
    public int Order { get; set; } = 0;
    public required long ProductId { get; set; }
    public required Product Product { get; set; }
}