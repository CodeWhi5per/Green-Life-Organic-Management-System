namespace GreenLife_Organic_Management_System.Models;

public class Review
{
    public int ReviewId { get; set; }
    public int ProductId { get; set; }
    public int CustomerId { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public int Rating { get; set; } // 1-5
    public string Comment { get; set; } = string.Empty;
    public DateTime ReviewDate { get; set; }
    public bool IsVerifiedPurchase { get; set; }
}
