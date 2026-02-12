using System.Data.SqlClient;
using GreenLife_Organic_Management_System.Models;

namespace GreenLife_Organic_Management_System.Data.Repositories;

public class ProductRepository
{
    public List<Product> GetAllProducts(bool includeInactive = false)
    {
        var products = new List<Product>();
        using var connection = DatabaseContext.GetConnection();
        connection.Open();
        
        var query = includeInactive 
            ? "SELECT * FROM Products ORDER BY Name" 
            : "SELECT * FROM Products WHERE IsActive = 1 ORDER BY Name";
            
        using var command = new SqlCommand(query, connection);
        using var reader = command.ExecuteReader();
        
        while (reader.Read())
        {
            products.Add(MapProduct(reader));
        }
        
        return products;
    }
    
    public Product? GetProductById(int productId)
    {
        using var connection = DatabaseContext.GetConnection();
        connection.Open();
        
        var query = "SELECT * FROM Products WHERE ProductId = @ProductId";
        using var command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@ProductId", productId);
        
        using var reader = command.ExecuteReader();
        if (reader.Read())
        {
            return MapProduct(reader);
        }
        
        return null;
    }
    
    public List<Product> SearchProducts(string searchTerm, string? category = null, decimal? minPrice = null, decimal? maxPrice = null)
    {
        var products = new List<Product>();
        using var connection = DatabaseContext.GetConnection();
        connection.Open();
        
        var query = "SELECT * FROM Products WHERE IsActive = 1";
        
        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            query += " AND (Name LIKE @SearchTerm OR Description LIKE @SearchTerm)";
        }
        
        if (!string.IsNullOrWhiteSpace(category))
        {
            query += " AND Category = @Category";
        }
        
        if (minPrice.HasValue)
        {
            query += " AND Price >= @MinPrice";
        }
        
        if (maxPrice.HasValue)
        {
            query += " AND Price <= @MaxPrice";
        }
        
        query += " ORDER BY Name";
        
        using var command = new SqlCommand(query, connection);
        
        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            command.Parameters.AddWithValue("@SearchTerm", $"%{searchTerm}%");
        }
        
        if (!string.IsNullOrWhiteSpace(category))
        {
            command.Parameters.AddWithValue("@Category", category);
        }
        
        if (minPrice.HasValue)
        {
            command.Parameters.AddWithValue("@MinPrice", minPrice.Value);
        }
        
        if (maxPrice.HasValue)
        {
            command.Parameters.AddWithValue("@MaxPrice", maxPrice.Value);
        }
        
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            products.Add(MapProduct(reader));
        }
        
        return products;
    }
    
    public List<string> GetCategories()
    {
        var categories = new List<string>();
        using var connection = DatabaseContext.GetConnection();
        connection.Open();
        
        var query = "SELECT DISTINCT Category FROM Products WHERE IsActive = 1 ORDER BY Category";
        using var command = new SqlCommand(query, connection);
        using var reader = command.ExecuteReader();
        
        while (reader.Read())
        {
            categories.Add(reader.GetString(0));
        }
        
        return categories;
    }
    
    public bool CreateProduct(Product product)
    {
        try
        {
            using var connection = DatabaseContext.GetConnection();
            connection.Open();
            
            var query = @"INSERT INTO Products (Name, Category, Description, Price, StockQuantity, Supplier, DiscountPercentage)
                         VALUES (@Name, @Category, @Description, @Price, @StockQuantity, @Supplier, @DiscountPercentage)";
            
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Name", product.Name);
            command.Parameters.AddWithValue("@Category", product.Category);
            command.Parameters.AddWithValue("@Description", product.Description ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Price", product.Price);
            command.Parameters.AddWithValue("@StockQuantity", product.StockQuantity);
            command.Parameters.AddWithValue("@Supplier", product.Supplier ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@DiscountPercentage", product.DiscountPercentage ?? (object)DBNull.Value);
            
            return command.ExecuteNonQuery() > 0;
        }
        catch
        {
            return false;
        }
    }
    
    public bool UpdateProduct(Product product)
    {
        try
        {
            using var connection = DatabaseContext.GetConnection();
            connection.Open();
            
            var query = @"UPDATE Products SET Name = @Name, Category = @Category, Description = @Description,
                         Price = @Price, StockQuantity = @StockQuantity, Supplier = @Supplier,
                         DiscountPercentage = @DiscountPercentage, LastUpdated = GETDATE(), IsActive = @IsActive
                         WHERE ProductId = @ProductId";
            
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ProductId", product.ProductId);
            command.Parameters.AddWithValue("@Name", product.Name);
            command.Parameters.AddWithValue("@Category", product.Category);
            command.Parameters.AddWithValue("@Description", product.Description ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Price", product.Price);
            command.Parameters.AddWithValue("@StockQuantity", product.StockQuantity);
            command.Parameters.AddWithValue("@Supplier", product.Supplier ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@DiscountPercentage", product.DiscountPercentage ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@IsActive", product.IsActive);
            
            return command.ExecuteNonQuery() > 0;
        }
        catch
        {
            return false;
        }
    }
    
    public bool DeleteProduct(int productId)
    {
        try
        {
            using var connection = DatabaseContext.GetConnection();
            connection.Open();
            
            // Soft delete
            var query = "UPDATE Products SET IsActive = 0 WHERE ProductId = @ProductId";
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ProductId", productId);
            
            return command.ExecuteNonQuery() > 0;
        }
        catch
        {
            return false;
        }
    }
    
    public List<Product> GetLowStockProducts(int threshold = 10)
    {
        var products = new List<Product>();
        using var connection = DatabaseContext.GetConnection();
        connection.Open();
        
        var query = "SELECT * FROM Products WHERE IsActive = 1 AND StockQuantity <= @Threshold ORDER BY StockQuantity";
        using var command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@Threshold", threshold);
        
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            products.Add(MapProduct(reader));
        }
        
        return products;
    }
    
    public bool UpdateStock(int productId, int quantity)
    {
        try
        {
            using var connection = DatabaseContext.GetConnection();
            connection.Open();
            
            var query = "UPDATE Products SET StockQuantity = StockQuantity + @Quantity WHERE ProductId = @ProductId";
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ProductId", productId);
            command.Parameters.AddWithValue("@Quantity", quantity);
            
            return command.ExecuteNonQuery() > 0;
        }
        catch
        {
            return false;
        }
    }
    
    private Product MapProduct(SqlDataReader reader)
    {
        return new Product
        {
            ProductId = reader.GetInt32(reader.GetOrdinal("ProductId")),
            Name = reader.GetString(reader.GetOrdinal("Name")),
            Category = reader.GetString(reader.GetOrdinal("Category")),
            Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? string.Empty : reader.GetString(reader.GetOrdinal("Description")),
            Price = reader.GetDecimal(reader.GetOrdinal("Price")),
            StockQuantity = reader.GetInt32(reader.GetOrdinal("StockQuantity")),
            Supplier = reader.IsDBNull(reader.GetOrdinal("Supplier")) ? string.Empty : reader.GetString(reader.GetOrdinal("Supplier")),
            CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
            LastUpdated = reader.IsDBNull(reader.GetOrdinal("LastUpdated")) ? null : reader.GetDateTime(reader.GetOrdinal("LastUpdated")),
            IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive")),
            DiscountPercentage = reader.IsDBNull(reader.GetOrdinal("DiscountPercentage")) ? null : reader.GetDecimal(reader.GetOrdinal("DiscountPercentage"))
        };
    }
}
