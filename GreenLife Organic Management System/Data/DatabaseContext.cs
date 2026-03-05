﻿﻿﻿using System.Data;
using System.Data.SqlClient;

namespace GreenLife_Organic_Management_System.Data;

public class DatabaseContext
{
    private static readonly string ConnectionString = GetConnectionString();

    private static string GetConnectionString()
    {
        const string dbName = "GreenLifeDB";
        const string serverName = @"localhost\SQLEXPRESS";
        
        EnsureDatabaseExists(serverName, dbName);
        
        return $"Data Source={serverName};Initial Catalog={dbName};Integrated Security=True;Connect Timeout=30;TrustServerCertificate=True";
    }
    
    private static void EnsureDatabaseExists(string serverName, string dbName)
    {
        try
        {
            string masterConnStr = $"Data Source={serverName};Initial Catalog=master;Integrated Security=True;Connect Timeout=10;TrustServerCertificate=True";
            
            using (var conn = new SqlConnection(masterConnStr))
            {
                conn.Open();
                
                using (var cmd = new SqlCommand("SELECT database_id FROM sys.databases WHERE name = @dbName", conn))
                {
                    cmd.Parameters.AddWithValue("@dbName", dbName);
                    var result = cmd.ExecuteScalar();
                    
                    if (result == null)
                    {
                        using (var createCmd = new SqlCommand($"CREATE DATABASE [{dbName}]", conn))
                        {
                            createCmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }
        catch
        {
            throw new Exception("Unable to connect to SQL Server. Please ensure that SQL Server is installed and running.");
        }
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
                    new SqlParameter("@Role", SqlDbType.Int) { Value = 0 });
            }
            
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
            ("Organic Bananas (Ambul)", "Fruits", "Fresh organic bananas from local farms", 250.00m, 150, "Lanka Organic Farms"),
            ("Organic Papaya (Papol)", "Fruits", "Sweet organic papaya", 180.00m, 100, "Tropical Sri Lanka"),
            ("Organic Mango (Amba)", "Fruits", "Juicy organic mangoes", 350.00m, 80, "Fruit Lanka"),
            ("Organic Pineapple (Annasi)", "Fruits", "Fresh organic pineapple", 220.00m, 90, "Golden Harvest"),
            ("Organic Coconut (Pol)", "Fruits", "Fresh organic coconuts", 120.00m, 200, "Coconut Growers Association"),
            ("Organic Gotukola", "Vegetables", "Fresh organic gotukola leaves", 150.00m, 60, "Green Leaf Organic"),
            ("Organic Murunga (Drumstick)", "Vegetables", "Organic drumstick vegetables", 280.00m, 70, "Village Organics"),
            ("Organic Brinjal (Wambatu)", "Vegetables", "Fresh organic eggplant", 160.00m, 85, "Upcountry Organic"),
            ("Organic Bitter Gourd (Karawila)", "Vegetables", "Organic bitter gourd", 190.00m, 75, "Healthy Greens"),
            ("Organic Tomatoes (Thakkali)", "Vegetables", "Fresh organic tomatoes", 220.00m, 95, "Nuwara Eliya Organic"),
            ("Organic Red Rice (Kekulu)", "Grains", "Traditional organic red rice (1kg)", 350.00m, 120, "Paddy Farmers Coop"),
            ("Organic White Rice (Samba)", "Grains", "Premium organic white rice (1kg)", 280.00m, 150, "Rice Mill Organic"),
            ("Organic Coconut Oil (Pol Thel)", "Oils", "Pure organic coconut oil (500ml)", 650.00m, 50, "Ceylon Coconut Oil"),
            ("Organic Ceylon Tea (Ceylon Thé)", "Beverages", "Premium organic Ceylon tea (250g)", 850.00m, 80, "Ceylon Tea Gardens"),
            ("Organic Jaggery (Hakuru)", "Sweeteners", "Natural organic jaggery (500g)", 320.00m, 60, "Traditional Sweeteners"),
            ("Organic Kithul Treacle (Kithul Pani)", "Sweeteners", "Pure organic kithul treacle (250ml)", 750.00m, 40, "Kithul Tappers Association"),
            ("Organic Curd (Meekiri)", "Dairy", "Fresh organic buffalo curd", 180.00m, 70, "Village Dairy"),
            ("Organic Cashew Nuts", "Nuts", "Premium organic cashew nuts (250g)", 1200.00m, 45, "Cashew Processors Lanka"),
            ("Organic King Coconut Water (Thambili)", "Beverages", "Fresh organic king coconut", 150.00m, 100, "King Coconut Suppliers"),
            ("Organic Curry Leaves (Karapincha)", "Spices", "Fresh organic curry leaves (100g)", 80.00m, 90, "Spice Garden Organic")
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
