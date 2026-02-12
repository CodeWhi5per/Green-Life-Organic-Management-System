using GreenLife_Organic_Management_System.Data.Repositories;
using GreenLife_Organic_Management_System.Utilities;

namespace GreenLife_Organic_Management_System.Forms.Admin;

public partial class AdminDashboardForm : Form
{
    private readonly ProductRepository _productRepository;
    private readonly OrderRepository _orderRepository;
    
    public AdminDashboardForm()
    {
        InitializeComponent();
        _productRepository = new ProductRepository();
        _orderRepository = new OrderRepository();
    }
    
    private void AdminDashboardForm_Load(object sender, EventArgs e)
    {
        LoadDashboardData();
        lblWelcome.Text = $"Welcome, {SessionManager.CurrentUser?.FullName}!";
    }
    
    private void LoadDashboardData()
    {
        try
        {
            // Get statistics
            var products = _productRepository.GetAllProducts();
            var orders = _orderRepository.GetAllOrders();
            var lowStockProducts = _productRepository.GetLowStockProducts();
            var totalSales = _orderRepository.GetTotalSales();
            
            lblTotalProducts.Text = products.Count.ToString();
            lblLowStock.Text = lowStockProducts.Count.ToString();
            lblTotalOrders.Text = orders.Count.ToString();
            lblTotalSales.Text = $"${totalSales:N2}";
            
            // Set low stock warning color
            if (lowStockProducts.Count > 0)
            {
                lblLowStock.ForeColor = System.Drawing.Color.Red;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading dashboard: {ex.Message}", "Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    
    private void btnProducts_Click(object sender, EventArgs e)
    {
        var form = new ProductManagementForm();
        form.ShowDialog();
        LoadDashboardData(); // Refresh dashboard after returning
    }
    
    private void btnCustomers_Click(object sender, EventArgs e)
    {
        var form = new CustomerManagementForm();
        form.ShowDialog();
    }
    
    private void btnOrders_Click(object sender, EventArgs e)
    {
        var form = new OrderManagementForm();
        form.ShowDialog();
        LoadDashboardData(); // Refresh dashboard after returning
    }
    
    private void btnReports_Click(object sender, EventArgs e)
    {
        var form = new ReportsForm();
        form.ShowDialog();
    }
    
    private void btnLogout_Click(object sender, EventArgs e)
    {
        var result = MessageBox.Show("Are you sure you want to logout?", "Logout", 
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        
        if (result == DialogResult.Yes)
        {
            SessionManager.Logout();
            this.Close();
        }
    }
}
