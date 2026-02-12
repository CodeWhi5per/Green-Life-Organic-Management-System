using GreenLife_Organic_Management_System.Services;
using GreenLife_Organic_Management_System.Utilities;

namespace GreenLife_Organic_Management_System.Forms;

public partial class RegisterForm : Form
{
    private readonly AuthenticationService _authService;
    
    public RegisterForm()
    {
        InitializeComponent();
        _authService = new AuthenticationService();
    }
    
    private void btnRegister_Click(object sender, EventArgs e)
    {
        try
        {
            // Validate inputs
            if (!ValidateInputs())
            {
                return;
            }
            
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Passwords do not match.", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            var (success, message) = _authService.Register(
                txtUsername.Text.Trim(),
                txtPassword.Text,
                txtEmail.Text.Trim(),
                txtFullName.Text.Trim(),
                txtPhoneNumber.Text.Trim(),
                txtAddress.Text.Trim()
            );
            
            if (success)
            {
                MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show(message, "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"An error occurred: {ex.Message}", "Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    
    private bool ValidateInputs()
    {
        if (!Validator.IsNotEmpty(txtUsername.Text))
        {
            MessageBox.Show("Username is required.", "Validation Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
        
        if (!Validator.IsValidPassword(txtPassword.Text))
        {
            MessageBox.Show("Password must be at least 6 characters long.", "Validation Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
        
        if (!Validator.IsValidEmail(txtEmail.Text))
        {
            MessageBox.Show("Please enter a valid email address.", "Validation Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
        
        if (!Validator.IsNotEmpty(txtFullName.Text))
        {
            MessageBox.Show("Full name is required.", "Validation Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
        
        if (!string.IsNullOrWhiteSpace(txtPhoneNumber.Text) && !Validator.IsValidPhoneNumber(txtPhoneNumber.Text))
        {
            MessageBox.Show("Please enter a valid phone number.", "Validation Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
        
        return true;
    }
    
    private void btnCancel_Click(object sender, EventArgs e)
    {
        this.Close();
    }
    
    private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
    {
        txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        txtConfirmPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
    }
}
