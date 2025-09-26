namespace backend.Models;

public class LoginRegisterResponse : AuthTokens
{
    public bool IsValid { get; set; } = false;
    public string Message { get; set; } = string.Empty;
}
