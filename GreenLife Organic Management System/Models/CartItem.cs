namespace GreenLife_Organic_Management_System.Models;

public class CartItem
{
    public Product Product { get; set; } = new Product();
    public int Quantity { get; set; }
    public decimal Subtotal => Product.DiscountedPrice * Quantity;
}
