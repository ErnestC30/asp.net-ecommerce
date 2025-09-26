namespace backend.Models;

public class AuthTokens
{
    public string JwtToken { get; set; } = string.Empty;
    public string JwtRefreshToken { get; set; } = string.Empty;
    public DateTime JwtTokenExpire { get; set; }
    public DateTime JwtRefreshTokenExpire { get; set; }
}
