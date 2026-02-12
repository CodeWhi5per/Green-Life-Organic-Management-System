using GreenLife_Organic_Management_System.Models;

namespace GreenLife_Organic_Management_System.Services;

public class CartService
{
    private static List<CartItem> _cartItems = new List<CartItem>();
    
    public static void AddToCart(Product product, int quantity)
    {
        var existingItem = _cartItems.FirstOrDefault(x => x.Product.ProductId == product.ProductId);
        
        if (existingItem != null)
        {
            existingItem.Quantity += quantity;
        }
        else
        {
            _cartItems.Add(new CartItem
            {
                Product = product,
                Quantity = quantity
            });
        }
    }
    
    public static void UpdateQuantity(int productId, int quantity)
    {
        var item = _cartItems.FirstOrDefault(x => x.Product.ProductId == productId);
        if (item != null)
        {
            if (quantity <= 0)
            {
                _cartItems.Remove(item);
            }
            else
            {
                item.Quantity = quantity;
            }
        }
    }
    
    public static void RemoveFromCart(int productId)
    {
        var item = _cartItems.FirstOrDefault(x => x.Product.ProductId == productId);
        if (item != null)
        {
            _cartItems.Remove(item);
        }
    }
    
    public static List<CartItem> GetCartItems()
    {
        return _cartItems;
    }
    
    public static decimal GetCartTotal()
    {
        return _cartItems.Sum(x => x.Subtotal);
    }
    
    public static int GetCartCount()
    {
        return _cartItems.Sum(x => x.Quantity);
    }
    
    public static void ClearCart()
    {
        _cartItems.Clear();
    }
    
    public static bool IsEmpty()
    {
        return _cartItems.Count == 0;
    }
}
