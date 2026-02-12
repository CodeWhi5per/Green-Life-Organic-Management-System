using GreenLife_Organic_Management_System.Data.Repositories;
using GreenLife_Organic_Management_System.Utilities;

namespace GreenLife_Organic_Management_System.Forms.Customer;

public partial class ProfileForm : Form
{
    private readonly UserRepository _userRepository;
    
    public ProfileForm()
    {
        InitializeComponent();
        _userRepository = new UserRepository();
    }
    
    private void ProfileForm_Load(object sender, EventArgs e)
    {
        LoadUserProfile();
    }
    
    private void LoadUserProfile()
    {
        var user = SessionManager.CurrentUser;
        if (user != null)
        {
            txtUsername.Text = user.Username;
            txtEmail.Text = user.Email;
            txtFullName.Text = user.FullName;
            txtPhoneNumber.Text = user.PhoneNumber;
            txtAddress.Text = user.Address;
        }
    }
    
    private void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (!ValidateInputs())
                return;
            
            var user = SessionManager.CurrentUser;
            if (user != null)
            {
                user.Email = txtEmail.Text.Trim();
                user.FullName = txtFullName.Text.Trim();
                user.PhoneNumber = txtPhoneNumber.Text.Trim();
                user.Address = txtAddress.Text.Trim();
                
                if (_userRepository.UpdateUser(user))
                {
                    SessionManager.CurrentUser = user;
                    MessageBox.Show("Profile updated successfully!", "Success", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to update profile.", "Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error updating profile: {ex.Message}", "Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    
    private bool ValidateInputs()
    {
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
}
