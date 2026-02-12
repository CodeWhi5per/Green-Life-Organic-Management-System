using GreenLife_Organic_Management_System.Data.Repositories;
using GreenLife_Organic_Management_System.Utilities;

namespace GreenLife_Organic_Management_System.Forms.Customer;

public partial class MyOrdersForm : Form
{
    private readonly OrderRepository _orderRepository;
    
    public MyOrdersForm()
    {
        InitializeComponent();
        _orderRepository = new OrderRepository();
    }
    
    private void MyOrdersForm_Load(object sender, EventArgs e)
    {
        LoadOrders();
    }
    
    private void LoadOrders()
    {
        try
        {
            var orders = _orderRepository.GetOrdersByCustomer(SessionManager.CurrentUser!.UserId);
            dgvOrders.DataSource = orders;
            
            if (dgvOrders.Columns.Count > 0)
            {
                dgvOrders.Columns["OrderId"].HeaderText = "Order #";
                dgvOrders.Columns["OrderId"].Width = 80;
                dgvOrders.Columns["OrderDate"].HeaderText = "Date";
                dgvOrders.Columns["OrderDate"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                dgvOrders.Columns["OrderDate"].Width = 140;
                dgvOrders.Columns["Status"].Width = 100;
                dgvOrders.Columns["FinalAmount"].HeaderText = "Amount";
                dgvOrders.Columns["FinalAmount"].DefaultCellStyle.Format = "C2";
                dgvOrders.Columns["FinalAmount"].Width = 100;
                dgvOrders.Columns["CustomerId"].Visible = false;
                dgvOrders.Columns["CustomerName"].Visible = false;
                dgvOrders.Columns["TotalAmount"].Visible = false;
                dgvOrders.Columns["DiscountAmount"].Visible = false;
                dgvOrders.Columns["ShippingAddress"].Visible = false;
                dgvOrders.Columns["Notes"].Visible = false;
                dgvOrders.Columns["ShippedDate"].Visible = false;
                dgvOrders.Columns["DeliveredDate"].Visible = false;
                dgvOrders.Columns["OrderItems"].Visible = false;
            }
            
            lblTotalOrders.Text = $"Total Orders: {orders.Count}";
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading orders: {ex.Message}", "Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    
    private void dgvOrders_SelectionChanged(object sender, EventArgs e)
    {
        if (dgvOrders.CurrentRow != null)
        {
            var order = (Models.Order)dgvOrders.CurrentRow.DataBoundItem;
            LoadOrderDetails(order.OrderId);
        }
    }
    
    private void LoadOrderDetails(int orderId)
    {
        try
        {
            var order = _orderRepository.GetOrderById(orderId);
            if (order != null)
            {
                txtOrderDetails.Text = $"Order #{order.OrderId}\n\n" +
                                      $"Order Date: {order.OrderDate:dd/MM/yyyy HH:mm}\n" +
                                      $"Status: {order.Status}\n" +
                                      $"Shipping Address: {order.ShippingAddress}\n" +
                                      $"Total Amount: ${order.TotalAmount:N2}\n" +
                                      $"Discount: ${order.DiscountAmount:N2}\n" +
                                      $"Final Amount: ${order.FinalAmount:N2}\n\n" +
                                      $"Items:\n";
                
                foreach (var item in order.OrderItems)
                {
                    txtOrderDetails.Text += $"- {item.ProductName} x {item.Quantity} @ ${item.UnitPrice:N2} = ${item.Subtotal:N2}\n";
                }
                
                if (order.ShippedDate.HasValue)
                {
                    txtOrderDetails.Text += $"\nShipped: {order.ShippedDate:dd/MM/yyyy HH:mm}";
                }
                
                if (order.DeliveredDate.HasValue)
                {
                    txtOrderDetails.Text += $"\nDelivered: {order.DeliveredDate:dd/MM/yyyy HH:mm}";
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading order details: {ex.Message}", "Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    
    private void btnClose_Click(object sender, EventArgs e)
    {
        this.Close();
    }
}
