using GreenLife_Organic_Management_System.Data.Repositories;

namespace GreenLife_Organic_Management_System.Forms.Admin;

public partial class CustomerManagementForm : Form
{
    private readonly UserRepository _userRepository;
    
    public CustomerManagementForm()
    {
        InitializeComponent();
        _userRepository = new UserRepository();
    }
    
    private void CustomerManagementForm_Load(object sender, EventArgs e)
    {
        LoadCustomers();
    }
    
    private void LoadCustomers()
    {
        try
        {
            var customers = _userRepository.GetAllCustomers();
            dgvCustomers.DataSource = customers;
            
            if (dgvCustomers.Columns.Count > 0)
            {
                dgvCustomers.Columns["UserId"].HeaderText = "ID";
                dgvCustomers.Columns["UserId"].Width = 50;
                dgvCustomers.Columns["Username"].Width = 120;
                dgvCustomers.Columns["FullName"].Width = 150;
                dgvCustomers.Columns["Email"].Width = 180;
                dgvCustomers.Columns["PhoneNumber"].Width = 120;
                dgvCustomers.Columns["CreatedAt"].HeaderText = "Registered";
                dgvCustomers.Columns["CreatedAt"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvCustomers.Columns["IsActive"].Width = 70;
                dgvCustomers.Columns["PasswordHash"].Visible = false;
                dgvCustomers.Columns["Role"].Visible = false;
                dgvCustomers.Columns["Address"].Visible = false;
            }
            
            lblTotalCustomers.Text = $"Total Customers: {customers.Count}";
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading customers: {ex.Message}", "Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    
    private void dgvCustomers_SelectionChanged(object sender, EventArgs e)
    {
        if (dgvCustomers.CurrentRow != null)
        {
            var customer = (Models.User)dgvCustomers.CurrentRow.DataBoundItem;
            txtCustomerInfo.Text = $"Customer Details:\n\n" +
                                  $"Username: {customer.Username}\n" +
                                  $"Full Name: {customer.FullName}\n" +
                                  $"Email: {customer.Email}\n" +
                                  $"Phone: {customer.PhoneNumber}\n" +
                                  $"Address: {customer.Address}\n" +
                                  $"Registered: {customer.CreatedAt:dd/MM/yyyy}\n" +
                                  $"Status: {(customer.IsActive ? "Active" : "Inactive")}";
        }
    }
    
    private void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            var searchTerm = txtSearch.Text.Trim().ToLower();
            var customers = _userRepository.GetAllCustomers();
            
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                customers = customers.Where(c => 
                    c.Username.ToLower().Contains(searchTerm) ||
                    c.FullName.ToLower().Contains(searchTerm) ||
                    c.Email.ToLower().Contains(searchTerm)
                ).ToList();
            }
            
            dgvCustomers.DataSource = customers;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error searching customers: {ex.Message}", "Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    
    private void btnToggleStatus_Click(object sender, EventArgs e)
    {
        if (dgvCustomers.CurrentRow == null)
        {
            MessageBox.Show("Please select a customer.", "No Selection", 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        
        try
        {
            var customer = (Models.User)dgvCustomers.CurrentRow.DataBoundItem;
            customer.IsActive = !customer.IsActive;
            
            if (_userRepository.UpdateUser(customer))
            {
                MessageBox.Show($"Customer {(customer.IsActive ? "activated" : "deactivated")} successfully!", 
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCustomers();
            }
            else
            {
                MessageBox.Show("Failed to update customer status.", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error updating status: {ex.Message}", "Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    
    private void btnClose_Click(object sender, EventArgs e)
    {
        this.Close();
    }
}
