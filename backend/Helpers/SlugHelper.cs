namespace backend.Helpers;

public static class SlugHelper
{
    public static string GenerateSlug(string str)
    {
        str = str.ToLower();
        str = System.Text.RegularExpressions.Regex.Replace(str, @"[^a-z0-9\s-]", "");
        str = str.Trim().Replace(" ", "_");
        return str;
    }
}