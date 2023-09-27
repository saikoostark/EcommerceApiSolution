using System.Text.RegularExpressions;

namespace EcommerceApi.Utils;

public static class UserUtiles
{

    public const string AdminRole = "AdminUser";
    public const string UserRole = "RegularUser";


    public static bool IfEmail(string? str)
    {
        if (str is null)
            return false;
        string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        return Regex.IsMatch(str, pattern);
    }
}


