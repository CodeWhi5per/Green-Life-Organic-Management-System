using System.Data.SqlClient;
using GreenLife_Organic_Management_System.Models;

namespace GreenLife_Organic_Management_System.Data.Repositories;

public class UserRepository
{
    public User? GetUserByUsername(string username)
    {
        using var connection = DatabaseContext.GetConnection();
        connection.Open();
        
        var query = "SELECT * FROM Users WHERE Username = @Username AND IsActive = 1";
        using var command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@Username", username);
        
        using var reader = command.ExecuteReader();
        if (reader.Read())
        {
            return MapUser(reader);
        }
        
        return null;
    }
    
    public User? GetUserById(int userId)
    {
        using var connection = DatabaseContext.GetConnection();
        connection.Open();
        
        var query = "SELECT * FROM Users WHERE UserId = @UserId";
        using var command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@UserId", userId);
        
        using var reader = command.ExecuteReader();
        if (reader.Read())
        {
            return MapUser(reader);
        }
        
        return null;
    }
    
    public List<User> GetAllCustomers()
    {
        var users = new List<User>();
        using var connection = DatabaseContext.GetConnection();
        connection.Open();
        
        var query = "SELECT * FROM Users WHERE Role = @Role ORDER BY CreatedAt DESC";
        using var command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@Role", (int)UserRole.Customer);
        
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            users.Add(MapUser(reader));
        }
        
        return users;
    }
    
    public bool CreateUser(User user)
    {
        try
        {
            using var connection = DatabaseContext.GetConnection();
            connection.Open();
            
            var query = @"INSERT INTO Users (Username, PasswordHash, Email, FullName, PhoneNumber, Address, Role)
                         VALUES (@Username, @PasswordHash, @Email, @FullName, @PhoneNumber, @Address, @Role)";
            
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Username", user.Username);
            command.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
            command.Parameters.AddWithValue("@Email", user.Email);
            command.Parameters.AddWithValue("@FullName", user.FullName);
            command.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Address", user.Address ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Role", (int)user.Role);
            
            return command.ExecuteNonQuery() > 0;
        }
        catch
        {
            return false;
        }
    }
    
    public bool UpdateUser(User user)
    {
        try
        {
            using var connection = DatabaseContext.GetConnection();
            connection.Open();
            
            var query = @"UPDATE Users SET Email = @Email, FullName = @FullName, 
                         PhoneNumber = @PhoneNumber, Address = @Address, IsActive = @IsActive
                         WHERE UserId = @UserId";
            
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserId", user.UserId);
            command.Parameters.AddWithValue("@Email", user.Email);
            command.Parameters.AddWithValue("@FullName", user.FullName);
            command.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Address", user.Address ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@IsActive", user.IsActive);
            
            return command.ExecuteNonQuery() > 0;
        }
        catch
        {
            return false;
        }
    }
    
    public bool UsernameExists(string username)
    {
        using var connection = DatabaseContext.GetConnection();
        connection.Open();
        
        var query = "SELECT COUNT(*) FROM Users WHERE Username = @Username";
        using var command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@Username", username);
        
        var count = (int)command.ExecuteScalar()!;
        return count > 0;
    }
    
    private User MapUser(SqlDataReader reader)
    {
        return new User
        {
            UserId = reader.GetInt32(reader.GetOrdinal("UserId")),
            Username = reader.GetString(reader.GetOrdinal("Username")),
            PasswordHash = reader.GetString(reader.GetOrdinal("PasswordHash")),
            Email = reader.GetString(reader.GetOrdinal("Email")),
            FullName = reader.GetString(reader.GetOrdinal("FullName")),
            PhoneNumber = reader.IsDBNull(reader.GetOrdinal("PhoneNumber")) ? string.Empty : reader.GetString(reader.GetOrdinal("PhoneNumber")),
            Address = reader.IsDBNull(reader.GetOrdinal("Address")) ? string.Empty : reader.GetString(reader.GetOrdinal("Address")),
            Role = (UserRole)reader.GetInt32(reader.GetOrdinal("Role")),
            CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
            IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive"))
        };
    }
}
