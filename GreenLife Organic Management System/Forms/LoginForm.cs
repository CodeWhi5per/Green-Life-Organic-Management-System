using GreenLife_Organic_Management_System.Services;
using GreenLife_Organic_Management_System.Utilities;
using GreenLife_Organic_Management_System.Forms.Admin;
using GreenLife_Organic_Management_System.Forms.Customer;

namespace GreenLife_Organic_Management_System.Forms;

public partial class LoginForm : Form
{
    private readonly AuthenticationService _authService;
    
    public LoginForm()
    {
        InitializeComponent();
        _authService = new AuthenticationService();
    }
    
    private void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            var username = txtUsername.Text.Trim();
            var password = txtPassword.Text;
            
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter username and password.", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            var (success, user, message) = _authService.Login(username, password);
            
            if (success && user != null)
            {
                SessionManager.CurrentUser = user;
                
                this.Hide();
                
                if (SessionManager.IsAdmin)
                {
                    var adminDashboard = new AdminDashboardForm();
                    adminDashboard.FormClosed += (s, args) => this.Close();
                    adminDashboard.Show();
                }
                else
                {
                    var customerDashboard = new CustomerDashboardForm();
                    customerDashboard.FormClosed += (s, args) => this.Close();
                    customerDashboard.Show();
                }
            }
            else
            {
                MessageBox.Show(message, "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"An error occurred: {ex.Message}", "Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    
    private void btnRegister_Click(object sender, EventArgs e)
    {
        var registerForm = new RegisterForm();
        registerForm.ShowDialog();
    }
    
    private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
    {
        txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
    }
    
    private void LoginForm_Load(object sender, EventArgs e)
    {
        txtPassword.UseSystemPasswordChar = true;
    }
}
