using System.Data.SqlClient;
using GreenLife_Organic_Management_System.Models;

namespace GreenLife_Organic_Management_System.Data.Repositories;

public class ReviewRepository
{
    public bool CreateReview(Review review)
    {
        try
        {
            using var connection = DatabaseContext.GetConnection();
            connection.Open();
            
            var query = @"INSERT INTO Reviews (ProductId, CustomerId, Rating, Comment, IsVerifiedPurchase)
                         VALUES (@ProductId, @CustomerId, @Rating, @Comment, @IsVerifiedPurchase)";
            
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ProductId", review.ProductId);
            command.Parameters.AddWithValue("@CustomerId", review.CustomerId);
            command.Parameters.AddWithValue("@Rating", review.Rating);
            command.Parameters.AddWithValue("@Comment", review.Comment ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@IsVerifiedPurchase", review.IsVerifiedPurchase);
            
            return command.ExecuteNonQuery() > 0;
        }
        catch
        {
            return false;
        }
    }
    
    public List<Review> GetProductReviews(int productId)
    {
        var reviews = new List<Review>();
        using var connection = DatabaseContext.GetConnection();
        connection.Open();
        
        var query = @"SELECT r.*, u.FullName as CustomerName 
                     FROM Reviews r 
                     INNER JOIN Users u ON r.CustomerId = u.UserId 
                     WHERE r.ProductId = @ProductId 
                     ORDER BY r.ReviewDate DESC";
        
        using var command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@ProductId", productId);
        
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            reviews.Add(MapReview(reader));
        }
        
        return reviews;
    }
    
    public double GetAverageRating(int productId)
    {
        using var connection = DatabaseContext.GetConnection();
        connection.Open();
        
        var query = "SELECT AVG(CAST(Rating AS FLOAT)) FROM Reviews WHERE ProductId = @ProductId";
        using var command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@ProductId", productId);
        
        var result = command.ExecuteScalar();
        return result == DBNull.Value ? 0 : Convert.ToDouble(result);
    }
    
    public bool HasCustomerPurchasedProduct(int customerId, int productId)
    {
        using var connection = DatabaseContext.GetConnection();
        connection.Open();
        
        var query = @"SELECT COUNT(*) FROM OrderItems oi 
                     INNER JOIN Orders o ON oi.OrderId = o.OrderId 
                     WHERE o.CustomerId = @CustomerId AND oi.ProductId = @ProductId 
                     AND o.Status = @DeliveredStatus";
        
        using var command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@CustomerId", customerId);
        command.Parameters.AddWithValue("@ProductId", productId);
        command.Parameters.AddWithValue("@DeliveredStatus", (int)OrderStatus.Delivered);
        
        var count = (int)command.ExecuteScalar()!;
        return count > 0;
    }
    
    private Review MapReview(SqlDataReader reader)
    {
        return new Review
        {
            ReviewId = reader.GetInt32(reader.GetOrdinal("ReviewId")),
            ProductId = reader.GetInt32(reader.GetOrdinal("ProductId")),
            CustomerId = reader.GetInt32(reader.GetOrdinal("CustomerId")),
            CustomerName = reader.GetString(reader.GetOrdinal("CustomerName")),
            Rating = reader.GetInt32(reader.GetOrdinal("Rating")),
            Comment = reader.IsDBNull(reader.GetOrdinal("Comment")) ? string.Empty : reader.GetString(reader.GetOrdinal("Comment")),
            ReviewDate = reader.GetDateTime(reader.GetOrdinal("ReviewDate")),
            IsVerifiedPurchase = reader.GetBoolean(reader.GetOrdinal("IsVerifiedPurchase"))
        };
    }
}
