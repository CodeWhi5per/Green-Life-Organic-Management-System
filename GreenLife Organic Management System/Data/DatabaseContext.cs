﻿﻿using System.Data.SqlClient;

namespace GreenLife_Organic_Management_System.Data;

public class DatabaseContext
{
    private static readonly string ConnectionString = GetConnectionString();

    private static string GetConnectionString()
    {
        // Get the application's base directory
        string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
        string dbPath = Path.Combine(appDirectory, "GreenLifeDB.mdf");
        
        // Try multiple connection strings in order of preference
        var connectionStrings = new[]
        {
            // SQL Server Express (most common installation)
            $@"Data Source=.\SQLEXPRESS;AttachDbFilename={dbPath};Integrated Security=True;Connect Timeout=30;User Instance=False",
            // SQL Server Express alternate format
            $@"Data Source=localhost\SQLEXPRESS;AttachDbFilename={dbPath};Integrated Security=True;Connect Timeout=30;User Instance=False",
            // LocalDB (lightweight option)
            $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={dbPath};Integrated Security=True;Connect Timeout=30",
            // Default SQL Server instance
            $@"Data Source=.;AttachDbFilename={dbPath};Integrated Security=True;Connect Timeout=30;User Instance=False"
        };
        
        // Try each connection string to find a working one
        foreach (var connStr in connectionStrings)
        {
            try
            {
                using (var conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    conn.Close();
                    return connStr; // Return the first working connection string
                }
            }
            catch
            {
                // Continue to next connection string
            }
        }
        
        // If none work, return the first one (will fail with helpful error message)
        return connectionStrings[0];
    }
    
    public static SqlConnection GetConnection()
    {
        return new SqlConnection(ConnectionString);
    }
    
    public static void InitializeDatabase()
    {
        try
        {
            using var connection = GetConnection();
            connection.Open();
            
            // Create Users table
            ExecuteNonQuery(connection, @"
                IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Users')
                CREATE TABLE Users (
                    UserId INT PRIMARY KEY IDENTITY(1,1),
                    Username NVARCHAR(50) UNIQUE NOT NULL,
                    PasswordHash NVARCHAR(255) NOT NULL,
                    Email NVARCHAR(100) NOT NULL,
                    FullName NVARCHAR(100) NOT NULL,
                    PhoneNumber NVARCHAR(20),
                    Address NVARCHAR(255),
                    Role INT NOT NULL,
                    CreatedAt DATETIME DEFAULT GETDATE(),
                    IsActive BIT DEFAULT 1
                )");
            
            // Create Products table
            ExecuteNonQuery(connection, @"
                IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Products')
                CREATE TABLE Products (
                    ProductId INT PRIMARY KEY IDENTITY(1,1),
                    Name NVARCHAR(100) NOT NULL,
                    Category NVARCHAR(50) NOT NULL,
                    Description NVARCHAR(500),
                    Price DECIMAL(10,2) NOT NULL,
                    StockQuantity INT NOT NULL DEFAULT 0,
                    Supplier NVARCHAR(100),
                    CreatedAt DATETIME DEFAULT GETDATE(),
                    LastUpdated DATETIME,
                    IsActive BIT DEFAULT 1,
                    DiscountPercentage DECIMAL(5,2)
                )");
            
            // Create Orders table
            ExecuteNonQuery(connection, @"
                IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Orders')
                CREATE TABLE Orders (
                    OrderId INT PRIMARY KEY IDENTITY(1,1),
                    CustomerId INT NOT NULL,
                    OrderDate DATETIME DEFAULT GETDATE(),
                    Status INT NOT NULL DEFAULT 0,
                    TotalAmount DECIMAL(10,2) NOT NULL,
                    DiscountAmount DECIMAL(10,2) DEFAULT 0,
                    FinalAmount DECIMAL(10,2) NOT NULL,
                    ShippingAddress NVARCHAR(255) NOT NULL,
                    Notes NVARCHAR(500),
                    ShippedDate DATETIME,
                    DeliveredDate DATETIME,
                    FOREIGN KEY (CustomerId) REFERENCES Users(UserId)
                )");
            
            // Create OrderItems table
            ExecuteNonQuery(connection, @"
                IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'OrderItems')
                CREATE TABLE OrderItems (
                    OrderItemId INT PRIMARY KEY IDENTITY(1,1),
                    OrderId INT NOT NULL,
                    ProductId INT NOT NULL,
                    ProductName NVARCHAR(100) NOT NULL,
                    Quantity INT NOT NULL,
                    UnitPrice DECIMAL(10,2) NOT NULL,
                    Subtotal DECIMAL(10,2) NOT NULL,
                    DiscountApplied DECIMAL(10,2),
                    FOREIGN KEY (OrderId) REFERENCES Orders(OrderId),
                    FOREIGN KEY (ProductId) REFERENCES Products(ProductId)
                )");
            
            // Create Reviews table
            ExecuteNonQuery(connection, @"
                IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Reviews')
                CREATE TABLE Reviews (
                    ReviewId INT PRIMARY KEY IDENTITY(1,1),
                    ProductId INT NOT NULL,
                    CustomerId INT NOT NULL,
                    Rating INT NOT NULL CHECK (Rating >= 1 AND Rating <= 5),
                    Comment NVARCHAR(500),
                    ReviewDate DATETIME DEFAULT GETDATE(),
                    IsVerifiedPurchase BIT DEFAULT 0,
                    FOREIGN KEY (ProductId) REFERENCES Products(ProductId),
                    FOREIGN KEY (CustomerId) REFERENCES Users(UserId)
                )");
            
            // Create Discounts table
            ExecuteNonQuery(connection, @"
                IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Discounts')
                CREATE TABLE Discounts (
                    DiscountId INT PRIMARY KEY IDENTITY(1,1),
                    Code NVARCHAR(50) UNIQUE NOT NULL,
                    Type INT NOT NULL,
                    Value DECIMAL(10,2) NOT NULL,
                    StartDate DATETIME NOT NULL,
                    EndDate DATETIME NOT NULL,
                    MinimumPurchase DECIMAL(10,2) DEFAULT 0,
                    IsActive BIT DEFAULT 1,
                    UsageLimit INT,
                    UsageCount INT DEFAULT 0
                )");
            
            // Insert default admin if no users exist
            var userCount = ExecuteScalar(connection, "SELECT COUNT(*) FROM Users");
            if (Convert.ToInt32(userCount) == 0)
            {
                var defaultPasswordHash = BCrypt.Net.BCrypt.HashPassword("admin123");
                ExecuteNonQuery(connection, @"
                    INSERT INTO Users (Username, PasswordHash, Email, FullName, PhoneNumber, Address, Role)
                    VALUES (@Username, @PasswordHash, @Email, @FullName, @PhoneNumber, @Address, @Role)",
                    new SqlParameter("@Username", "admin"),
                    new SqlParameter("@PasswordHash", defaultPasswordHash),
                    new SqlParameter("@Email", "admin@greenlife.com"),
                    new SqlParameter("@FullName", "System Administrator"),
                    new SqlParameter("@PhoneNumber", "0000000000"),
                    new SqlParameter("@Address", "GreenLife HQ"),
                    new SqlParameter("@Role", 0)); // Admin role
            }
            
            // Insert sample products if none exist
            var productCount = ExecuteScalar(connection, "SELECT COUNT(*) FROM Products");
            if (Convert.ToInt32(productCount) == 0)
            {
                InsertSampleProducts(connection);
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"Database initialization failed: {ex.Message}", ex);
        }
    }
    
    private static void ExecuteNonQuery(SqlConnection connection, string query, params SqlParameter[] parameters)
    {
        using var command = new SqlCommand(query, connection);
        if (parameters != null)
        {
            command.Parameters.AddRange(parameters);
        }
        command.ExecuteNonQuery();
    }
    
    private static object? ExecuteScalar(SqlConnection connection, string query, params SqlParameter[] parameters)
    {
        using var command = new SqlCommand(query, connection);
        if (parameters != null)
        {
            command.Parameters.AddRange(parameters);
        }
        return command.ExecuteScalar();
    }
    
    private static void InsertSampleProducts(SqlConnection connection)
    {
        var products = new[]
        {
            ("Organic Apples", "Fruits", "Fresh organic apples from local farms", 3.99m, 100, "Green Valley Farms"),
            ("Organic Bananas", "Fruits", "Ripe organic bananas", 2.49m, 150, "Tropical Organic"),
            ("Organic Carrots", "Vegetables", "Crunchy organic carrots", 1.99m, 80, "Root Veggie Co"),
            ("Organic Spinach", "Vegetables", "Fresh organic spinach leaves", 2.99m, 60, "Leafy Greens Ltd"),
            ("Organic Milk", "Dairy", "Full cream organic milk", 4.99m, 40, "Pure Dairy Farms"),
            ("Organic Eggs", "Dairy", "Free-range organic eggs (12 pack)", 5.99m, 75, "Happy Hens"),
            ("Organic Brown Rice", "Grains", "Premium organic brown rice", 6.99m, 50, "Grain Masters"),
            ("Organic Quinoa", "Grains", "High-protein organic quinoa", 8.99m, 45, "Ancient Grains Co"),
            ("Organic Tomatoes", "Vegetables", "Juicy organic tomatoes", 3.49m, 90, "Sun Harvest"),
            ("Organic Honey", "Sweeteners", "Raw organic honey", 9.99m, 30, "Bee Natural"),
            ("Organic Olive Oil", "Oils", "Extra virgin organic olive oil", 12.99m, 35, "Mediterranean Oils"),
            ("Organic Green Tea", "Beverages", "Premium organic green tea", 7.49m, 55, "Tea Gardens"),
            ("Organic Almonds", "Nuts", "Raw organic almonds", 11.99m, 40, "Nutty Delights"),
            ("Organic Strawberries", "Fruits", "Sweet organic strawberries", 5.99m, 65, "Berry Best"),
            ("Organic Broccoli", "Vegetables", "Fresh organic broccoli", 2.79m, 70, "Green Valley Farms")
        };
        
        foreach (var (name, category, description, price, stock, supplier) in products)
        {
            ExecuteNonQuery(connection, @"
                INSERT INTO Products (Name, Category, Description, Price, StockQuantity, Supplier)
                VALUES (@Name, @Category, @Description, @Price, @StockQuantity, @Supplier)",
                new SqlParameter("@Name", name),
                new SqlParameter("@Category", category),
                new SqlParameter("@Description", description),
                new SqlParameter("@Price", price),
                new SqlParameter("@StockQuantity", stock),
                new SqlParameter("@Supplier", supplier));
        }
    }
}
