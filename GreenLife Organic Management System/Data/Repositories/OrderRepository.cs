using System.Data.SqlClient;
using GreenLife_Organic_Management_System.Models;

namespace GreenLife_Organic_Management_System.Data.Repositories;

public class OrderRepository
{
    public int CreateOrder(Order order)
    {
        using var connection = DatabaseContext.GetConnection();
        connection.Open();
        using var transaction = connection.BeginTransaction();
        
        try
        {
            // Insert order
            var orderQuery = @"INSERT INTO Orders (CustomerId, OrderDate, Status, TotalAmount, DiscountAmount, FinalAmount, ShippingAddress, Notes)
                              VALUES (@CustomerId, @OrderDate, @Status, @TotalAmount, @DiscountAmount, @FinalAmount, @ShippingAddress, @Notes);
                              SELECT CAST(SCOPE_IDENTITY() as int)";
            
            int orderId;
            using (var command = new SqlCommand(orderQuery, connection, transaction))
            {
                command.Parameters.AddWithValue("@CustomerId", order.CustomerId);
                command.Parameters.AddWithValue("@OrderDate", order.OrderDate);
                command.Parameters.AddWithValue("@Status", (int)order.Status);
                command.Parameters.AddWithValue("@TotalAmount", order.TotalAmount);
                command.Parameters.AddWithValue("@DiscountAmount", order.DiscountAmount);
                command.Parameters.AddWithValue("@FinalAmount", order.FinalAmount);
                command.Parameters.AddWithValue("@ShippingAddress", order.ShippingAddress);
                command.Parameters.AddWithValue("@Notes", order.Notes ?? (object)DBNull.Value);
                
                orderId = (int)command.ExecuteScalar()!;
            }
            
            // Insert order items
            var itemQuery = @"INSERT INTO OrderItems (OrderId, ProductId, ProductName, Quantity, UnitPrice, Subtotal, DiscountApplied)
                             VALUES (@OrderId, @ProductId, @ProductName, @Quantity, @UnitPrice, @Subtotal, @DiscountApplied)";
            
            foreach (var item in order.OrderItems)
            {
                using var command = new SqlCommand(itemQuery, connection, transaction);
                command.Parameters.AddWithValue("@OrderId", orderId);
                command.Parameters.AddWithValue("@ProductId", item.ProductId);
                command.Parameters.AddWithValue("@ProductName", item.ProductName);
                command.Parameters.AddWithValue("@Quantity", item.Quantity);
                command.Parameters.AddWithValue("@UnitPrice", item.UnitPrice);
                command.Parameters.AddWithValue("@Subtotal", item.Subtotal);
                command.Parameters.AddWithValue("@DiscountApplied", item.DiscountApplied ?? (object)DBNull.Value);
                command.ExecuteNonQuery();
                
                // Update product stock
                var stockQuery = "UPDATE Products SET StockQuantity = StockQuantity - @Quantity WHERE ProductId = @ProductId";
                using var stockCommand = new SqlCommand(stockQuery, connection, transaction);
                stockCommand.Parameters.AddWithValue("@Quantity", item.Quantity);
                stockCommand.Parameters.AddWithValue("@ProductId", item.ProductId);
                stockCommand.ExecuteNonQuery();
            }
            
            transaction.Commit();
            return orderId;
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }
    
    public List<Order> GetOrdersByCustomer(int customerId)
    {
        var orders = new List<Order>();
        using var connection = DatabaseContext.GetConnection();
        connection.Open();
        
        var query = @"SELECT o.*, u.FullName as CustomerName 
                     FROM Orders o 
                     INNER JOIN Users u ON o.CustomerId = u.UserId 
                     WHERE o.CustomerId = @CustomerId 
                     ORDER BY o.OrderDate DESC";
        
        using var command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@CustomerId", customerId);
        
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            orders.Add(MapOrder(reader));
        }
        
        return orders;
    }
    
    public List<Order> GetAllOrders()
    {
        var orders = new List<Order>();
        using var connection = DatabaseContext.GetConnection();
        connection.Open();
        
        var query = @"SELECT o.*, u.FullName as CustomerName 
                     FROM Orders o 
                     INNER JOIN Users u ON o.CustomerId = u.UserId 
                     ORDER BY o.OrderDate DESC";
        
        using var command = new SqlCommand(query, connection);
        using var reader = command.ExecuteReader();
        
        while (reader.Read())
        {
            orders.Add(MapOrder(reader));
        }
        
        return orders;
    }
    
    public Order? GetOrderById(int orderId)
    {
        using var connection = DatabaseContext.GetConnection();
        connection.Open();
        
        var query = @"SELECT o.*, u.FullName as CustomerName 
                     FROM Orders o 
                     INNER JOIN Users u ON o.CustomerId = u.UserId 
                     WHERE o.OrderId = @OrderId";
        
        using var command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@OrderId", orderId);
        
        using var reader = command.ExecuteReader();
        if (reader.Read())
        {
            var order = MapOrder(reader);
            reader.Close();
            
            // Load order items
            order.OrderItems = GetOrderItems(orderId, connection);
            return order;
        }
        
        return null;
    }
    
    public List<OrderItem> GetOrderItems(int orderId, SqlConnection? connection = null)
    {
        var items = new List<OrderItem>();
        var shouldCloseConnection = connection == null;
        
        if (connection == null)
        {
            connection = DatabaseContext.GetConnection();
            connection.Open();
        }
        
        try
        {
            var query = "SELECT * FROM OrderItems WHERE OrderId = @OrderId";
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@OrderId", orderId);
            
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                items.Add(MapOrderItem(reader));
            }
        }
        finally
        {
            if (shouldCloseConnection)
            {
                connection.Close();
            }
        }
        
        return items;
    }
    
    public bool UpdateOrderStatus(int orderId, OrderStatus status)
    {
        try
        {
            using var connection = DatabaseContext.GetConnection();
            connection.Open();
            
            var query = "UPDATE Orders SET Status = @Status";
            
            if (status == OrderStatus.Shipped)
            {
                query += ", ShippedDate = GETDATE()";
            }
            else if (status == OrderStatus.Delivered)
            {
                query += ", DeliveredDate = GETDATE()";
            }
            
            query += " WHERE OrderId = @OrderId";
            
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@OrderId", orderId);
            command.Parameters.AddWithValue("@Status", (int)status);
            
            return command.ExecuteNonQuery() > 0;
        }
        catch
        {
            return false;
        }
    }
    
    public decimal GetTotalSales(DateTime? startDate = null, DateTime? endDate = null)
    {
        using var connection = DatabaseContext.GetConnection();
        connection.Open();
        
        var query = "SELECT ISNULL(SUM(FinalAmount), 0) FROM Orders WHERE Status != @CancelledStatus";
        
        if (startDate.HasValue)
        {
            query += " AND OrderDate >= @StartDate";
        }
        
        if (endDate.HasValue)
        {
            query += " AND OrderDate <= @EndDate";
        }
        
        using var command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@CancelledStatus", (int)OrderStatus.Cancelled);
        
        if (startDate.HasValue)
        {
            command.Parameters.AddWithValue("@StartDate", startDate.Value);
        }
        
        if (endDate.HasValue)
        {
            command.Parameters.AddWithValue("@EndDate", endDate.Value);
        }
        
        return (decimal)command.ExecuteScalar()!;
    }
    
    private Order MapOrder(SqlDataReader reader)
    {
        return new Order
        {
            OrderId = reader.GetInt32(reader.GetOrdinal("OrderId")),
            CustomerId = reader.GetInt32(reader.GetOrdinal("CustomerId")),
            CustomerName = reader.GetString(reader.GetOrdinal("CustomerName")),
            OrderDate = reader.GetDateTime(reader.GetOrdinal("OrderDate")),
            Status = (OrderStatus)reader.GetInt32(reader.GetOrdinal("Status")),
            TotalAmount = reader.GetDecimal(reader.GetOrdinal("TotalAmount")),
            DiscountAmount = reader.GetDecimal(reader.GetOrdinal("DiscountAmount")),
            FinalAmount = reader.GetDecimal(reader.GetOrdinal("FinalAmount")),
            ShippingAddress = reader.GetString(reader.GetOrdinal("ShippingAddress")),
            Notes = reader.IsDBNull(reader.GetOrdinal("Notes")) ? null : reader.GetString(reader.GetOrdinal("Notes")),
            ShippedDate = reader.IsDBNull(reader.GetOrdinal("ShippedDate")) ? null : reader.GetDateTime(reader.GetOrdinal("ShippedDate")),
            DeliveredDate = reader.IsDBNull(reader.GetOrdinal("DeliveredDate")) ? null : reader.GetDateTime(reader.GetOrdinal("DeliveredDate"))
        };
    }
    
    private OrderItem MapOrderItem(SqlDataReader reader)
    {
        return new OrderItem
        {
            OrderItemId = reader.GetInt32(reader.GetOrdinal("OrderItemId")),
            OrderId = reader.GetInt32(reader.GetOrdinal("OrderId")),
            ProductId = reader.GetInt32(reader.GetOrdinal("ProductId")),
            ProductName = reader.GetString(reader.GetOrdinal("ProductName")),
            Quantity = reader.GetInt32(reader.GetOrdinal("Quantity")),
            UnitPrice = reader.GetDecimal(reader.GetOrdinal("UnitPrice")),
            Subtotal = reader.GetDecimal(reader.GetOrdinal("Subtotal")),
            DiscountApplied = reader.IsDBNull(reader.GetOrdinal("DiscountApplied")) ? null : reader.GetDecimal(reader.GetOrdinal("DiscountApplied"))
        };
    }
}
