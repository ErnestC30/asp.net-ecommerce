using System.ComponentModel.DataAnnotations;

namespace backend.Helpers;

public class ProductQueryObject
{
    [Range(0, int.MaxValue, ErrorMessage = "Page number cannot be negative.")]
    public int PageNumber { get; set; } = 0;

    [Range(1, 100, ErrorMessage = "Page size must be between 1 and 100.")]
    public int PageSize { get; set; } = 10;

    public int? CategoryId { get; set; }
}