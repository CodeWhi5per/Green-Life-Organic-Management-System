namespace GreenLife_Organic_Management_System.Models;

public enum UserRole
{
    Admin,
    Customer
}

public enum OrderStatus
{
    Pending,
    Processing,
    Shipped,
    Delivered,
    Cancelled
}

public enum DiscountType
{
    Percentage,
    FixedAmount
}
