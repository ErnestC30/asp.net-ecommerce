using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models;

[Table("refresh_token")]
public class RefreshToken
{
    public int Id { get; set; }

    [Required]
    public required string Token { get; set; }
    [Required]
    public required string UserId { get; set; }
    public DateTime ExpiresOnUtc { get; set; }
    [Required]
    public AppUser User { get; set; } = null!;
}