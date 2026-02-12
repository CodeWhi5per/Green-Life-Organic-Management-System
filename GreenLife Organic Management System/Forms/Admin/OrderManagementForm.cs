using GreenLife_Organic_Management_System.Data.Repositories;
using GreenLife_Organic_Management_System.Models;

namespace GreenLife_Organic_Management_System.Forms.Admin;

public partial class OrderManagementForm : Form
{
    private readonly OrderRepository _orderRepository;
    
    public OrderManagementForm()
    {
        InitializeComponent();
        _orderRepository = new OrderRepository();
    }
    
    private void OrderManagementForm_Load(object sender, EventArgs e)
    {
        LoadOrders();
        LoadStatusFilter();
    }
    
    private void LoadOrders()
    {
        try
        {
            var orders = _orderRepository.GetAllOrders();
            dgvOrders.DataSource = orders;
            
            if (dgvOrders.Columns.Count > 0)
            {
                dgvOrders.Columns["OrderId"].HeaderText = "Order #";
                dgvOrders.Columns["OrderId"].Width = 70;
                dgvOrders.Columns["CustomerName"].HeaderText = "Customer";
                dgvOrders.Columns["CustomerName"].Width = 150;
                dgvOrders.Columns["OrderDate"].HeaderText = "Order Date";
                dgvOrders.Columns["OrderDate"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                dgvOrders.Columns["Status"].Width = 100;
                dgvOrders.Columns["TotalAmount"].DefaultCellStyle.Format = "C2";
                dgvOrders.Columns["FinalAmount"].DefaultCellStyle.Format = "C2";
                dgvOrders.Columns["CustomerId"].Visible = false;
                dgvOrders.Columns["OrderItems"].Visible = false;
                dgvOrders.Columns["DiscountAmount"].Visible = false;
                dgvOrders.Columns["ShippingAddress"].Visible = false;
                dgvOrders.Columns["Notes"].Visible = false;
                dgvOrders.Columns["ShippedDate"].Visible = false;
                dgvOrders.Columns["DeliveredDate"].Visible = false;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading orders: {ex.Message}", "Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    
    private void LoadStatusFilter()
    {
        cmbStatusFilter.Items.Clear();
        cmbStatusFilter.Items.Add("All Orders");
        foreach (OrderStatus status in Enum.GetValues(typeof(OrderStatus)))
        {
            cmbStatusFilter.Items.Add(status.ToString());
        }
        cmbStatusFilter.SelectedIndex = 0;
    }
    
    private void dgvOrders_SelectionChanged(object sender, EventArgs e)
    {
        if (dgvOrders.CurrentRow != null)
        {
            var order = (Order)dgvOrders.CurrentRow.DataBoundItem;
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
                lblOrderInfo.Text = $"Order #{order.OrderId} - {order.CustomerName}\n" +
                                    $"Date: {order.OrderDate:dd/MM/yyyy HH:mm}\n" +
                                    $"Status: {order.Status}\n" +
                                    $"Shipping Address: {order.ShippingAddress}";
                
                dgvOrderItems.DataSource = order.OrderItems;
                
                if (dgvOrderItems.Columns.Count > 0)
                {
                    dgvOrderItems.Columns["OrderItemId"].Visible = false;
                    dgvOrderItems.Columns["OrderId"].Visible = false;
                    dgvOrderItems.Columns["ProductId"].Visible = false;
                    dgvOrderItems.Columns["ProductName"].HeaderText = "Product";
                    dgvOrderItems.Columns["ProductName"].Width = 200;
                    dgvOrderItems.Columns["Quantity"].Width = 80;
                    dgvOrderItems.Columns["UnitPrice"].DefaultCellStyle.Format = "C2";
                    dgvOrderItems.Columns["Subtotal"].DefaultCellStyle.Format = "C2";
                    dgvOrderItems.Columns["DiscountApplied"].DefaultCellStyle.Format = "C2";
                }
                
                // Load available status transitions
                cmbNewStatus.Items.Clear();
                foreach (OrderStatus status in Enum.GetValues(typeof(OrderStatus)))
                {
                    cmbNewStatus.Items.Add(status.ToString());
                }
                cmbNewStatus.SelectedItem = order.Status.ToString();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading order details: {ex.Message}", "Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    
    private void btnUpdateStatus_Click(object sender, EventArgs e)
    {
        if (dgvOrders.CurrentRow == null)
        {
            MessageBox.Show("Please select an order.", "No Selection", 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        
        if (cmbNewStatus.SelectedItem == null)
        {
            MessageBox.Show("Please select a status.", "No Selection", 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        
        try
        {
            var order = (Order)dgvOrders.CurrentRow.DataBoundItem;
            var newStatus = (OrderStatus)Enum.Parse(typeof(OrderStatus), cmbNewStatus.SelectedItem.ToString()!);
            
            if (_orderRepository.UpdateOrderStatus(order.OrderId, newStatus))
            {
                MessageBox.Show("Order status updated successfully!", "Success", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadOrders();
            }
            else
            {
                MessageBox.Show("Failed to update order status.", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error updating status: {ex.Message}", "Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    
    private void cmbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cmbStatusFilter.SelectedIndex > 0)
        {
            var status = (OrderStatus)Enum.Parse(typeof(OrderStatus), cmbStatusFilter.SelectedItem.ToString()!);
            var allOrders = _orderRepository.GetAllOrders();
            dgvOrders.DataSource = allOrders.Where(o => o.Status == status).ToList();
        }
        else
        {
            LoadOrders();
        }
    }
    
    private void btnClose_Click(object sender, EventArgs e)
    {
        this.Close();
    }
}
