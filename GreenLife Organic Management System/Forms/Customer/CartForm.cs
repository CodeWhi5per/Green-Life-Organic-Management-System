using GreenLife_Organic_Management_System.Data.Repositories;
using GreenLife_Organic_Management_System.Models;
using GreenLife_Organic_Management_System.Services;
using GreenLife_Organic_Management_System.Utilities;

namespace GreenLife_Organic_Management_System.Forms.Customer;

public partial class CartForm : Form
{
    private readonly OrderRepository _orderRepository;
    
    public CartForm()
    {
        InitializeComponent();
        _orderRepository = new OrderRepository();
    }
    
    private void CartForm_Load(object sender, EventArgs e)
    {
        LoadCart();
    }
    
    private void LoadCart()
    {
        var cartItems = CartService.GetCartItems();
        dgvCart.DataSource = cartItems.ToList();
        
        if (dgvCart.Columns.Count > 0)
        {
            dgvCart.Columns["Product"].Visible = false;
            dgvCart.Columns["Quantity"].Width = 100;
            dgvCart.Columns["Subtotal"].DefaultCellStyle.Format = "C2";
        }
        
        // Add product name column
        if (!dgvCart.Columns.Contains("ProductName"))
        {
            var nameColumn = new DataGridViewTextBoxColumn
            {
                Name = "ProductName",
                HeaderText = "Product",
                DataPropertyName = "Product.Name",
                Width = 200
            };
            dgvCart.Columns.Insert(0, nameColumn);
        }
        
        var total = CartService.GetCartTotal();
        lblTotal.Text = $"Total: ${total:N2}";
        
        btnCheckout.Enabled = !CartService.IsEmpty();
    }
    
    private void btnUpdateQuantity_Click(object sender, EventArgs e)
    {
        if (dgvCart.CurrentRow == null)
        {
            MessageBox.Show("Please select an item.", "No Selection", 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        
        if (!int.TryParse(txtNewQuantity.Text, out var quantity) || quantity < 0)
        {
            MessageBox.Show("Please enter a valid quantity.", "Invalid Quantity", 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        
        var cartItem = (CartItem)dgvCart.CurrentRow.DataBoundItem;
        
        if (quantity > cartItem.Product.StockQuantity)
        {
            MessageBox.Show($"Only {cartItem.Product.StockQuantity} units available.", 
                "Insufficient Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        
        CartService.UpdateQuantity(cartItem.Product.ProductId, quantity);
        LoadCart();
        txtNewQuantity.Text = "1";
    }
    
    private void btnRemove_Click(object sender, EventArgs e)
    {
        if (dgvCart.CurrentRow == null)
        {
            MessageBox.Show("Please select an item to remove.", "No Selection", 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        
        var cartItem = (CartItem)dgvCart.CurrentRow.DataBoundItem;
        CartService.RemoveFromCart(cartItem.Product.ProductId);
        LoadCart();
    }
    
    private void btnClearCart_Click(object sender, EventArgs e)
    {
        var result = MessageBox.Show("Are you sure you want to clear the cart?", 
            "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        
        if (result == DialogResult.Yes)
        {
            CartService.ClearCart();
            LoadCart();
        }
    }
    
    private void btnCheckout_Click(object sender, EventArgs e)
    {
        if (CartService.IsEmpty())
        {
            MessageBox.Show("Your cart is empty.", "Empty Cart", 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        
        var checkoutForm = new CheckoutForm();
        if (checkoutForm.ShowDialog() == DialogResult.OK)
        {
            this.Close();
        }
        else
        {
            LoadCart(); // Refresh in case quantities changed
        }
    }
    
    private void btnClose_Click(object sender, EventArgs e)
    {
        this.Close();
    }
}
