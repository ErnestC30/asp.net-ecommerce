using System.Security.Claims;

namespace backend.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static string? GetUserId(this ClaimsPrincipal user)
    {
        return user.FindFirstValue(ClaimTypes.NameIdentifier) ?? null;
    }
    public static string? GetEmail(this ClaimsPrincipal user)
    {
        return user.FindFirstValue(ClaimTypes.Email) ?? null;
    }

    public static string? GetUserName(this ClaimsPrincipal user)
    {
        return user.FindFirstValue(ClaimTypes.GivenName) ?? null;
    }
}
