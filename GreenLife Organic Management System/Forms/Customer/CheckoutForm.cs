using GreenLife_Organic_Management_System.Data.Repositories;
using GreenLife_Organic_Management_System.Models;
using GreenLife_Organic_Management_System.Services;
using GreenLife_Organic_Management_System.Utilities;

namespace GreenLife_Organic_Management_System.Forms.Customer;

public partial class CheckoutForm : Form
{
    private readonly OrderRepository _orderRepository;
    
    public CheckoutForm()
    {
        InitializeComponent();
        _orderRepository = new OrderRepository();
    }
    
    private void CheckoutForm_Load(object sender, EventArgs e)
    {
        var user = SessionManager.CurrentUser;
        if (user != null)
        {
            txtShippingAddress.Text = user.Address;
        }
        
        var total = CartService.GetCartTotal();
        lblOrderTotal.Text = $"Order Total: ${total:N2}";
        lblFinalAmount.Text = $"Final Amount: ${total:N2}";
    }
    
    private void btnPlaceOrder_Click(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(txtShippingAddress.Text))
            {
                MessageBox.Show("Please enter a shipping address.", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            var cartItems = CartService.GetCartItems();
            if (cartItems.Count == 0)
            {
                MessageBox.Show("Your cart is empty.", "Empty Cart", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            var totalAmount = CartService.GetCartTotal();
            var discountAmount = 0m;
            var finalAmount = totalAmount - discountAmount;
            
            var order = new Order
            {
                CustomerId = SessionManager.CurrentUser!.UserId,
                OrderDate = DateTime.Now,
                Status = OrderStatus.Pending,
                TotalAmount = totalAmount,
                DiscountAmount = discountAmount,
                FinalAmount = finalAmount,
                ShippingAddress = txtShippingAddress.Text.Trim(),
                Notes = txtNotes.Text.Trim(),
                OrderItems = cartItems.Select(ci => new OrderItem
                {
                    ProductId = ci.Product.ProductId,
                    ProductName = ci.Product.Name,
                    Quantity = ci.Quantity,
                    UnitPrice = ci.Product.DiscountedPrice,
                    Subtotal = ci.Subtotal,
                    DiscountApplied = ci.Product.DiscountPercentage.HasValue ? 
                        ci.Product.Price * ci.Quantity * ci.Product.DiscountPercentage.Value / 100 : null
                }).ToList()
            };
            
            var orderId = _orderRepository.CreateOrder(order);
            
            if (orderId > 0)
            {
                CartService.ClearCart();
                MessageBox.Show($"Order #{orderId} placed successfully!\n\n" +
                              $"Total Amount: ${finalAmount:N2}\n" +
                              $"Thank you for shopping with GreenLife!", 
                              "Order Confirmed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to place order. Please try again.", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error placing order: {ex.Message}", "Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    
    private void btnCancel_Click(object sender, EventArgs e)
    {
        this.DialogResult = DialogResult.Cancel;
        this.Close();
    }
}
