using GreenLife_Organic_Management_System.Models;

namespace GreenLife_Organic_Management_System.Utilities;

public static class SessionManager
{
    public static User? CurrentUser { get; set; }
    
    public static bool IsLoggedIn => CurrentUser != null;
    
    public static bool IsAdmin => CurrentUser?.Role == UserRole.Admin;
    
    public static bool IsCustomer => CurrentUser?.Role == UserRole.Customer;
    
    public static void Logout()
    {
        CurrentUser = null;
    }
}
