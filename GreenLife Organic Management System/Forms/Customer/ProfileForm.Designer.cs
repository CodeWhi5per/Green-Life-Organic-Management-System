namespace GreenLife_Organic_Management_System.Forms.Customer;

partial class ProfileForm
{
    private System.ComponentModel.IContainer components = null;
    private Label lblTitle;
    private Label lblUsername;
    private TextBox txtUsername;
    private Label lblEmail;
    private TextBox txtEmail;
    private Label lblFullName;
    private TextBox txtFullName;
    private Label lblPhoneNumber;
    private TextBox txtPhoneNumber;
    private Label lblAddress;
    private TextBox txtAddress;
    private Button btnSave;
    private Button btnCancel;
    
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }
    
    private void InitializeComponent()
    {
        this.lblTitle = new Label();
        this.lblUsername = new Label();
        this.txtUsername = new TextBox();
        this.lblEmail = new Label();
        this.txtEmail = new TextBox();
        this.lblFullName = new Label();
        this.txtFullName = new TextBox();
        this.lblPhoneNumber = new Label();
        this.txtPhoneNumber = new TextBox();
        this.lblAddress = new Label();
        this.txtAddress = new TextBox();
        this.btnSave = new Button();
        this.btnCancel = new Button();
        this.SuspendLayout();
        
        // lblTitle
        this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
        this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(34, 139, 34);
        this.lblTitle.Location = new System.Drawing.Point(20, 20);
        this.lblTitle.Size = new System.Drawing.Size(400, 35);
        this.lblTitle.Text = "My Profile";
        
        int yPos = 70;
        int spacing = 65;
        
        // lblUsername
        this.lblUsername.AutoSize = true;
        this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.lblUsername.Location = new System.Drawing.Point(30, yPos);
        this.lblUsername.Text = "Username:";
        
        // txtUsername
        this.txtUsername.Enabled = false;
        this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.txtUsername.Location = new System.Drawing.Point(30, yPos + 25);
        this.txtUsername.Size = new System.Drawing.Size(380, 25);
        
        yPos += spacing;
        this.lblEmail.AutoSize = true;
        this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.lblEmail.Location = new System.Drawing.Point(30, yPos);
        this.lblEmail.Text = "Email:*";
        
        this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.txtEmail.Location = new System.Drawing.Point(30, yPos + 25);
        this.txtEmail.Size = new System.Drawing.Size(380, 25);
        
        yPos += spacing;
        this.lblFullName.AutoSize = true;
        this.lblFullName.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.lblFullName.Location = new System.Drawing.Point(30, yPos);
        this.lblFullName.Text = "Full Name:*";
        
        this.txtFullName.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.txtFullName.Location = new System.Drawing.Point(30, yPos + 25);
        this.txtFullName.Size = new System.Drawing.Size(380, 25);
        
        yPos += spacing;
        this.lblPhoneNumber.AutoSize = true;
        this.lblPhoneNumber.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.lblPhoneNumber.Location = new System.Drawing.Point(30, yPos);
        this.lblPhoneNumber.Text = "Phone Number:";
        
        this.txtPhoneNumber.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.txtPhoneNumber.Location = new System.Drawing.Point(30, yPos + 25);
        this.txtPhoneNumber.Size = new System.Drawing.Size(380, 25);
        
        yPos += spacing;
        this.lblAddress.AutoSize = true;
        this.lblAddress.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.lblAddress.Location = new System.Drawing.Point(30, yPos);
        this.lblAddress.Text = "Address:";
        
        this.txtAddress.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.txtAddress.Location = new System.Drawing.Point(30, yPos + 25);
        this.txtAddress.Multiline = true;
        this.txtAddress.Size = new System.Drawing.Size(380, 70);
        
        // btnSave
        this.btnSave.BackColor = System.Drawing.Color.FromArgb(34, 139, 34);
        this.btnSave.FlatStyle = FlatStyle.Flat;
        this.btnSave.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
        this.btnSave.ForeColor = System.Drawing.Color.White;
        this.btnSave.Location = new System.Drawing.Point(30, 480);
        this.btnSave.Size = new System.Drawing.Size(180, 40);
        this.btnSave.Text = "Save Changes";
        this.btnSave.Click += new EventHandler(this.btnSave_Click);
        
        // btnCancel
        this.btnCancel.BackColor = System.Drawing.Color.Gray;
        this.btnCancel.FlatStyle = FlatStyle.Flat;
        this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 11F);
        this.btnCancel.ForeColor = System.Drawing.Color.White;
        this.btnCancel.Location = new System.Drawing.Point(230, 480);
        this.btnCancel.Size = new System.Drawing.Size(180, 40);
        this.btnCancel.Text = "Cancel";
        this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
        
        // ProfileForm
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.FromArgb(240, 255, 240);
        this.ClientSize = new System.Drawing.Size(440, 550);
        this.Controls.Add(this.lblTitle);
        this.Controls.Add(this.lblUsername);
        this.Controls.Add(this.txtUsername);
        this.Controls.Add(this.lblEmail);
        this.Controls.Add(this.txtEmail);
        this.Controls.Add(this.lblFullName);
        this.Controls.Add(this.txtFullName);
        this.Controls.Add(this.lblPhoneNumber);
        this.Controls.Add(this.txtPhoneNumber);
        this.Controls.Add(this.lblAddress);
        this.Controls.Add(this.txtAddress);
        this.Controls.Add(this.btnSave);
        this.Controls.Add(this.btnCancel);
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "ProfileForm";
        this.StartPosition = FormStartPosition.CenterParent;
        this.Text = "My Profile - GreenLife";
        this.Load += new EventHandler(this.ProfileForm_Load);
        this.ResumeLayout(false);
        this.PerformLayout();
    }
}
