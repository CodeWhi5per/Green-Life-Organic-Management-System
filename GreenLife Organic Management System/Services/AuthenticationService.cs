using GreenLife_Organic_Management_System.Data.Repositories;
using GreenLife_Organic_Management_System.Models;

namespace GreenLife_Organic_Management_System.Services;

public class AuthenticationService
{
    private readonly UserRepository _userRepository;
    
    public AuthenticationService()
    {
        _userRepository = new UserRepository();
    }
    
    public (bool success, User? user, string message) Login(string username, string password)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return (false, null, "Username and password are required.");
            }
            
            var user = _userRepository.GetUserByUsername(username);
            
            if (user == null)
            {
                return (false, null, "Invalid username or password.");
            }
            
            if (!BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                return (false, null, "Invalid username or password.");
            }
            
            if (!user.IsActive)
            {
                return (false, null, "Your account has been deactivated.");
            }
            
            return (true, user, "Login successful!");
        }
        catch (Exception ex)
        {
            return (false, null, $"Login failed: {ex.Message}");
        }
    }
    
    public (bool success, string message) Register(string username, string password, string email, string fullName, string phoneNumber, string address)
    {
        try
        {
            if (_userRepository.UsernameExists(username))
            {
                return (false, "Username already exists.");
            }
            
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
            
            var user = new User
            {
                Username = username,
                PasswordHash = passwordHash,
                Email = email,
                FullName = fullName,
                PhoneNumber = phoneNumber,
                Address = address,
                Role = UserRole.Customer,
                CreatedAt = DateTime.Now,
                IsActive = true
            };
            
            if (_userRepository.CreateUser(user))
            {
                return (true, "Registration successful! You can now log in.");
            }
            
            return (false, "Registration failed. Please try again.");
        }
        catch (Exception ex)
        {
            return (false, $"Registration failed: {ex.Message}");
        }
    }
}
