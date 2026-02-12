namespace GreenLife_Organic_Management_System.Models;

public class Discount
{
    public int DiscountId { get; set; }
    public string Code { get; set; } = string.Empty;
    public DiscountType Type { get; set; }
    public decimal Value { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal MinimumPurchase { get; set; }
    public bool IsActive { get; set; }
    public int? UsageLimit { get; set; }
    public int UsageCount { get; set; }
    
    public bool IsValid()
    {
        var now = DateTime.Now;
        return IsActive 
               && now >= StartDate 
               && now <= EndDate 
               && (!UsageLimit.HasValue || UsageCount < UsageLimit.Value);
    }
}
