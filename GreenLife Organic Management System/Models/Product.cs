namespace GreenLife_Organic_Management_System.Models;

public class Product
{
    public int ProductId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public string Supplier { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime? LastUpdated { get; set; }
    public bool IsActive { get; set; }
    public decimal? DiscountPercentage { get; set; }
    
    // Computed property
    public decimal DiscountedPrice => DiscountPercentage.HasValue 
        ? Price * (1 - DiscountPercentage.Value / 100) 
        : Price;
    
    public bool IsLowStock(int threshold = 10) => StockQuantity <= threshold;
}
