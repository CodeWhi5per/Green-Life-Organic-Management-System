using GreenLife_Organic_Management_System.Data.Repositories;
using GreenLife_Organic_Management_System.Utilities;

namespace GreenLife_Organic_Management_System.Forms.Admin;

public partial class ReportsForm : Form
{
    private readonly OrderRepository _orderRepository;
    private readonly ProductRepository _productRepository;
    
    public ReportsForm()
    {
        InitializeComponent();
        _orderRepository = new OrderRepository();
        _productRepository = new ProductRepository();
    }
    
    private void ReportsForm_Load(object sender, EventArgs e)
    {
        dtpStartDate.Value = DateTime.Now.AddMonths(-1);
        dtpEndDate.Value = DateTime.Now;
    }
    
    private void btnGenerateSalesReport_Click(object sender, EventArgs e)
    {
        try
        {
            var orders = _orderRepository.GetAllOrders()
                .Where(o => o.OrderDate >= dtpStartDate.Value && o.OrderDate <= dtpEndDate.Value && o.Status != Models.OrderStatus.Cancelled)
                .OrderByDescending(o => o.OrderDate)
                .ToList();
            
            dgvReport.DataSource = orders;
            
            var totalSales = orders.Sum(o => o.FinalAmount);
            var totalOrders = orders.Count;
            var avgOrderValue = totalOrders > 0 ? totalSales / totalOrders : 0;
            
            txtReportSummary.Text = $"Sales Report Summary\n" +
                                   $"Period: {dtpStartDate.Value:dd/MM/yyyy} to {dtpEndDate.Value:dd/MM/yyyy}\n\n" +
                                   $"Total Orders: {totalOrders}\n" +
                                   $"Total Sales: ${totalSales:N2}\n" +
                                   $"Average Order Value: ${avgOrderValue:N2}";
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error generating sales report: {ex.Message}", "Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    
    private void btnGenerateStockReport_Click(object sender, EventArgs e)
    {
        try
        {
            var products = _productRepository.GetAllProducts()
                .OrderBy(p => p.StockQuantity)
                .ToList();
            
            dgvReport.DataSource = products;
            
            var lowStockProducts = products.Where(p => p.IsLowStock()).Count();
            var outOfStock = products.Where(p => p.StockQuantity == 0).Count();
            var totalValue = products.Sum(p => p.Price * p.StockQuantity);
            
            txtReportSummary.Text = $"Stock Report Summary\n" +
                                   $"Generated: {DateTime.Now:dd/MM/yyyy HH:mm}\n\n" +
                                   $"Total Products: {products.Count}\n" +
                                   $"Low Stock Items: {lowStockProducts}\n" +
                                   $"Out of Stock: {outOfStock}\n" +
                                   $"Total Stock Value: ${totalValue:N2}";
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error generating stock report: {ex.Message}", "Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    
    private void btnExportExcel_Click(object sender, EventArgs e)
    {
        try
        {
            using var sfd = new SaveFileDialog();
            sfd.Filter = "Excel Files|*.xlsx";
            sfd.FileName = $"Report_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";
            
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (dgvReport.DataSource is List<Models.Order> orders)
                {
                    ExportHelper.ExportOrdersToExcel(orders, sfd.FileName);
                }
                else if (dgvReport.DataSource is List<Models.Product> products)
                {
                    ExportHelper.ExportProductsToExcel(products, sfd.FileName);
                }
                
                MessageBox.Show("Report exported successfully!", "Success", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error exporting report: {ex.Message}", "Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    
    private void btnClose_Click(object sender, EventArgs e)
    {
        this.Close();
    }
}
