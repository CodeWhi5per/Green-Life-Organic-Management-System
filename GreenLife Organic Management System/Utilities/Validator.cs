using System.Text.RegularExpressions;

namespace GreenLife_Organic_Management_System.Utilities;

public static class Validator
{
    public static bool IsValidEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;
        
        try
        {
            var regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            return regex.IsMatch(email);
        }
        catch
        {
            return false;
        }
    }
    
    public static bool IsValidPhoneNumber(string phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(phoneNumber))
            return false;
        
        // Allow digits, spaces, hyphens, and parentheses
        var regex = new Regex(@"^[\d\s\-\(\)]{10,15}$");
        return regex.IsMatch(phoneNumber);
    }
    
    public static bool IsValidPrice(string price)
    {
        return decimal.TryParse(price, out var value) && value >= 0;
    }
    
    public static bool IsValidQuantity(string quantity)
    {
        return int.TryParse(quantity, out var value) && value >= 0;
    }
    
    public static bool IsValidPassword(string password)
    {
        // At least 6 characters
        return !string.IsNullOrWhiteSpace(password) && password.Length >= 6;
    }
    
    public static bool IsNotEmpty(string value)
    {
        return !string.IsNullOrWhiteSpace(value);
    }
}
