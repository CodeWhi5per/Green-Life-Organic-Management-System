using GreenLife_Organic_Management_System.Data.Repositories;
using GreenLife_Organic_Management_System.Models;
using GreenLife_Organic_Management_System.Services;
using GreenLife_Organic_Management_System.Utilities;

namespace GreenLife_Organic_Management_System.Forms.Customer;

public partial class CustomerDashboardForm : Form
{
    private readonly ProductRepository _productRepository;
    private readonly OrderRepository _orderRepository;
    
    public CustomerDashboardForm()
    {
        InitializeComponent();
        _productRepository = new ProductRepository();
        _orderRepository = new OrderRepository();
    }
    
    private void CustomerDashboardForm_Load(object sender, EventArgs e)
    {
        lblWelcome.Text = $"Welcome, {SessionManager.CurrentUser?.FullName}!";
        LoadProducts();
        LoadCategories();
        UpdateCartBadge();
    }
    
    private void LoadProducts()
    {
        try
        {
            var products = _productRepository.GetAllProducts();
            DisplayProducts(products);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading products: {ex.Message}", "Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    
    private void LoadCategories()
    {
        var categories = _productRepository.GetCategories();
        cmbCategory.Items.Clear();
        cmbCategory.Items.Add("All Categories");
        foreach (var category in categories)
        {
            cmbCategory.Items.Add(category);
        }
        cmbCategory.SelectedIndex = 0;
    }
    
    private void DisplayProducts(List<Product> products)
    {
        dgvProducts.DataSource = products;
        
        if (dgvProducts.Columns.Count > 0)
        {
            dgvProducts.Columns["ProductId"].Visible = false;
            dgvProducts.Columns["Name"].Width = 180;
            dgvProducts.Columns["Category"].Width = 100;
            dgvProducts.Columns["Description"].Width = 250;
            dgvProducts.Columns["Price"].DefaultCellStyle.Format = "C2";
            dgvProducts.Columns["DiscountedPrice"].HeaderText = "Final Price";
            dgvProducts.Columns["DiscountedPrice"].DefaultCellStyle.Format = "C2";
            dgvProducts.Columns["StockQuantity"].HeaderText = "In Stock";
            dgvProducts.Columns["StockQuantity"].Width = 80;
            dgvProducts.Columns["Supplier"].Visible = false;
            dgvProducts.Columns["CreatedAt"].Visible = false;
            dgvProducts.Columns["LastUpdated"].Visible = false;
            dgvProducts.Columns["IsActive"].Visible = false;
            dgvProducts.Columns["DiscountPercentage"].Visible = false;
        }
    }
    
    private void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            var searchTerm = txtSearch.Text.Trim();
            var category = cmbCategory.SelectedIndex > 0 ? cmbCategory.SelectedItem?.ToString() : null;
            
            decimal? minPrice = null;
            decimal? maxPrice = null;
            
            if (decimal.TryParse(txtMinPrice.Text, out var min))
                minPrice = min;
            if (decimal.TryParse(txtMaxPrice.Text, out var max))
                maxPrice = max;
            
            var products = _productRepository.SearchProducts(searchTerm, category, minPrice, maxPrice);
            DisplayProducts(products);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error searching products: {ex.Message}", "Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    
    private void btnAddToCart_Click(object sender, EventArgs e)
    {
        if (dgvProducts.CurrentRow == null)
        {
            MessageBox.Show("Please select a product.", "No Selection", 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        
        var product = (Product)dgvProducts.CurrentRow.DataBoundItem;
        
        if (product.StockQuantity == 0)
        {
            MessageBox.Show("This product is out of stock.", "Out of Stock", 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        
        if (!int.TryParse(txtQuantity.Text, out var quantity) || quantity <= 0)
        {
            MessageBox.Show("Please enter a valid quantity.", "Invalid Quantity", 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        
        if (quantity > product.StockQuantity)
        {
            MessageBox.Show($"Only {product.StockQuantity} units available.", "Insufficient Stock", 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        
        CartService.AddToCart(product, quantity);
        MessageBox.Show("Product added to cart!", "Success", 
            MessageBoxButtons.OK, MessageBoxIcon.Information);
        
        UpdateCartBadge();
        txtQuantity.Text = "1";
    }
    
    private void btnViewCart_Click(object sender, EventArgs e)
    {
        var cartForm = new CartForm();
        cartForm.ShowDialog();
        UpdateCartBadge();
    }
    
    private void btnMyOrders_Click(object sender, EventArgs e)
    {
        var ordersForm = new MyOrdersForm();
        ordersForm.ShowDialog();
    }
    
    private void btnProfile_Click(object sender, EventArgs e)
    {
        var profileForm = new ProfileForm();
        profileForm.ShowDialog();
    }
    
    private void btnLogout_Click(object sender, EventArgs e)
    {
        var result = MessageBox.Show("Are you sure you want to logout?", "Logout", 
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        
        if (result == DialogResult.Yes)
        {
            CartService.ClearCart();
            SessionManager.Logout();
            this.Close();
        }
    }
    
    private void UpdateCartBadge()
    {
        var count = CartService.GetCartCount();
        btnViewCart.Text = $"View Cart ({count})";
    }
}
