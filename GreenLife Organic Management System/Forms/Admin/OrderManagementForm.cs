﻿using GreenLife_Organic_Management_System.Data.Repositories;
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
            dgvOrders.SelectionChanged -= dgvOrders_SelectionChanged;
            
            var orders = _orderRepository.GetAllOrders();
            dgvOrders.DataSource = orders;
            
            if (dgvOrders.Columns.Count > 0)
            {
                if (dgvOrders.Columns["OrderId"] != null)
                {
                    dgvOrders.Columns["OrderId"].HeaderText = "Order #";
                    dgvOrders.Columns["OrderId"].Width = 70;
                }
                
                if (dgvOrders.Columns["CustomerName"] != null)
                {
                    dgvOrders.Columns["CustomerName"].HeaderText = "Customer";
                    dgvOrders.Columns["CustomerName"].Width = 150;
                }
                
                if (dgvOrders.Columns["OrderDate"] != null)
                {
                    dgvOrders.Columns["OrderDate"].HeaderText = "Order Date";
                    dgvOrders.Columns["OrderDate"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                }
                
                if (dgvOrders.Columns["Status"] != null)
                    dgvOrders.Columns["Status"].Width = 100;
                
                if (dgvOrders.Columns["TotalAmount"] != null)
                    dgvOrders.Columns["TotalAmount"].DefaultCellStyle.Format = "C2";
                
                if (dgvOrders.Columns["FinalAmount"] != null)
                    dgvOrders.Columns["FinalAmount"].DefaultCellStyle.Format = "C2";
                
                if (dgvOrders.Columns["CustomerId"] != null)
                    dgvOrders.Columns["CustomerId"].Visible = false;
                
                if (dgvOrders.Columns["OrderItems"] != null)
                    dgvOrders.Columns["OrderItems"].Visible = false;
                
                if (dgvOrders.Columns["DiscountAmount"] != null)
                    dgvOrders.Columns["DiscountAmount"].Visible = false;
                
                if (dgvOrders.Columns["ShippingAddress"] != null)
                    dgvOrders.Columns["ShippingAddress"].Visible = false;
                
                if (dgvOrders.Columns["Notes"] != null)
                    dgvOrders.Columns["Notes"].Visible = false;
                
                if (dgvOrders.Columns["ShippedDate"] != null)
                    dgvOrders.Columns["ShippedDate"].Visible = false;
                
                if (dgvOrders.Columns["DeliveredDate"] != null)
                    dgvOrders.Columns["DeliveredDate"].Visible = false;
            }
            
            dgvOrders.SelectionChanged += dgvOrders_SelectionChanged;
            
            if (dgvOrders.Rows.Count > 0 && dgvOrders.Rows[0].DataBoundItem != null)
            {
                dgvOrders.Rows[0].Selected = true;
                var order = (Order)dgvOrders.Rows[0].DataBoundItem;
                if (order != null)
                {
                    LoadOrderDetails(order.OrderId);
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading orders: {ex.Message}\n\nStack Trace: {ex.StackTrace}", "Error", 
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
    
    private void dgvOrders_SelectionChanged(object? sender, EventArgs e)
    {
        if (dgvOrders.CurrentRow != null && dgvOrders.CurrentRow.DataBoundItem != null)
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
                
                dgvOrderItems.DataSource = order.OrderItems ?? new List<OrderItem>();
                
                if (dgvOrderItems.Columns.Count > 0)
                {
                    if (dgvOrderItems.Columns["OrderItemId"] != null)
                        dgvOrderItems.Columns["OrderItemId"].Visible = false;
                    
                    if (dgvOrderItems.Columns["OrderId"] != null)
                        dgvOrderItems.Columns["OrderId"].Visible = false;
                    
                    if (dgvOrderItems.Columns["ProductId"] != null)
                        dgvOrderItems.Columns["ProductId"].Visible = false;
                    
                    if (dgvOrderItems.Columns["ProductName"] != null)
                    {
                        dgvOrderItems.Columns["ProductName"].HeaderText = "Product";
                        dgvOrderItems.Columns["ProductName"].Width = 200;
                    }
                    
                    if (dgvOrderItems.Columns["Quantity"] != null)
                        dgvOrderItems.Columns["Quantity"].Width = 80;
                    
                    if (dgvOrderItems.Columns["UnitPrice"] != null)
                        dgvOrderItems.Columns["UnitPrice"].DefaultCellStyle.Format = "C2";
                    
                    if (dgvOrderItems.Columns["Subtotal"] != null)
                        dgvOrderItems.Columns["Subtotal"].DefaultCellStyle.Format = "C2";
                    
                    if (dgvOrderItems.Columns["DiscountApplied"] != null)
                        dgvOrderItems.Columns["DiscountApplied"].DefaultCellStyle.Format = "C2";
                }
                
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
            MessageBox.Show($"Error loading order details: {ex.Message}\n\nStack Trace: {ex.StackTrace}", "Error", 
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
        try
        {
            dgvOrders.SelectionChanged -= dgvOrders_SelectionChanged;
            
            if (cmbStatusFilter.SelectedIndex > 0)
            {
                var status = (OrderStatus)Enum.Parse(typeof(OrderStatus), cmbStatusFilter.SelectedItem.ToString()!);
                var allOrders = _orderRepository.GetAllOrders();
                dgvOrders.DataSource = allOrders.Where(o => o.Status == status).ToList();
            }
            else
            {
                var orders = _orderRepository.GetAllOrders();
                dgvOrders.DataSource = orders;
            }
            
            dgvOrders.SelectionChanged += dgvOrders_SelectionChanged;
            
            if (dgvOrders.Rows.Count > 0 && dgvOrders.Rows[0].DataBoundItem != null)
            {
                dgvOrders.Rows[0].Selected = true;
                var order = (Order)dgvOrders.Rows[0].DataBoundItem;
                if (order != null)
                {
                    LoadOrderDetails(order.OrderId);
                }
            }
            else
            {
                lblOrderInfo.Text = "";
                dgvOrderItems.DataSource = null;
                cmbNewStatus.Items.Clear();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error filtering orders: {ex.Message}", "Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    
    private void btnClose_Click(object sender, EventArgs e)
    {
        this.Close();
    }
}
