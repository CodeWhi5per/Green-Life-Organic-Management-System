namespace GreenLife_Organic_Management_System.Forms;

partial class RegisterForm
{
    private System.ComponentModel.IContainer components = null;
    private TextBox txtUsername;
    private TextBox txtPassword;
    private TextBox txtConfirmPassword;
    private TextBox txtEmail;
    private TextBox txtFullName;
    private TextBox txtPhoneNumber;
    private TextBox txtAddress;
    private Button btnRegister;
    private Button btnCancel;
    private Label lblTitle;
    private Label lblUsername;
    private Label lblPassword;
    private Label lblConfirmPassword;
    private Label lblEmail;
    private Label lblFullName;
    private Label lblPhoneNumber;
    private Label lblAddress;
    private CheckBox chkShowPassword;
    private Panel panelMain;
    
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
        this.panelMain = new Panel();
        this.lblTitle = new Label();
        this.lblUsername = new Label();
        this.txtUsername = new TextBox();
        this.lblPassword = new Label();
        this.txtPassword = new TextBox();
        this.lblConfirmPassword = new Label();
        this.txtConfirmPassword = new TextBox();
        this.lblEmail = new Label();
        this.txtEmail = new TextBox();
        this.lblFullName = new Label();
        this.txtFullName = new TextBox();
        this.lblPhoneNumber = new Label();
        this.txtPhoneNumber = new TextBox();
        this.lblAddress = new Label();
        this.txtAddress = new TextBox();
        this.chkShowPassword = new CheckBox();
        this.btnRegister = new Button();
        this.btnCancel = new Button();
        this.panelMain.SuspendLayout();
        this.SuspendLayout();
        
        // panelMain
        this.panelMain.AutoScroll = true;
        this.panelMain.BackColor = System.Drawing.Color.White;
        this.panelMain.BorderStyle = BorderStyle.FixedSingle;
        this.panelMain.Controls.Add(this.lblTitle);
        this.panelMain.Controls.Add(this.lblUsername);
        this.panelMain.Controls.Add(this.txtUsername);
        this.panelMain.Controls.Add(this.lblPassword);
        this.panelMain.Controls.Add(this.txtPassword);
        this.panelMain.Controls.Add(this.lblConfirmPassword);
        this.panelMain.Controls.Add(this.txtConfirmPassword);
        this.panelMain.Controls.Add(this.lblEmail);
        this.panelMain.Controls.Add(this.txtEmail);
        this.panelMain.Controls.Add(this.lblFullName);
        this.panelMain.Controls.Add(this.txtFullName);
        this.panelMain.Controls.Add(this.lblPhoneNumber);
        this.panelMain.Controls.Add(this.txtPhoneNumber);
        this.panelMain.Controls.Add(this.lblAddress);
        this.panelMain.Controls.Add(this.txtAddress);
        this.panelMain.Controls.Add(this.chkShowPassword);
        this.panelMain.Controls.Add(this.btnRegister);
        this.panelMain.Controls.Add(this.btnCancel);
        this.panelMain.Location = new System.Drawing.Point(30, 20);
        this.panelMain.Name = "panelMain";
        this.panelMain.Size = new System.Drawing.Size(440, 610);
        this.panelMain.TabIndex = 0;
        
        // lblTitle
        this.lblTitle.AutoSize = false;
        this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
        this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(34, 139, 34);
        this.lblTitle.Location = new System.Drawing.Point(20, 15);
        this.lblTitle.Name = "lblTitle";
        this.lblTitle.Size = new System.Drawing.Size(380, 40);
        this.lblTitle.TabIndex = 0;
        this.lblTitle.Text = "Customer Registration";
        this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        
        // lblUsername
        this.lblUsername.AutoSize = true;
        this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.lblUsername.Location = new System.Drawing.Point(30, 70);
        this.lblUsername.Name = "lblUsername";
        this.lblUsername.Size = new System.Drawing.Size(75, 19);
        this.lblUsername.Text = "Username:*";
        
        // txtUsername
        this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.txtUsername.Location = new System.Drawing.Point(30, 92);
        this.txtUsername.Name = "txtUsername";
        this.txtUsername.Size = new System.Drawing.Size(370, 25);
        this.txtUsername.TabIndex = 1;
        
        // lblPassword
        this.lblPassword.AutoSize = true;
        this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.lblPassword.Location = new System.Drawing.Point(30, 130);
        this.lblPassword.Name = "lblPassword";
        this.lblPassword.Size = new System.Drawing.Size(70, 19);
        this.lblPassword.Text = "Password:*";
        
        // txtPassword
        this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.txtPassword.Location = new System.Drawing.Point(30, 152);
        this.txtPassword.Name = "txtPassword";
        this.txtPassword.Size = new System.Drawing.Size(370, 25);
        this.txtPassword.TabIndex = 2;
        this.txtPassword.UseSystemPasswordChar = true;
        
        // lblConfirmPassword
        this.lblConfirmPassword.AutoSize = true;
        this.lblConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.lblConfirmPassword.Location = new System.Drawing.Point(30, 190);
        this.lblConfirmPassword.Name = "lblConfirmPassword";
        this.lblConfirmPassword.Size = new System.Drawing.Size(130, 19);
        this.lblConfirmPassword.Text = "Confirm Password:*";
        
        // txtConfirmPassword
        this.txtConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.txtConfirmPassword.Location = new System.Drawing.Point(30, 212);
        this.txtConfirmPassword.Name = "txtConfirmPassword";
        this.txtConfirmPassword.Size = new System.Drawing.Size(370, 25);
        this.txtConfirmPassword.TabIndex = 3;
        this.txtConfirmPassword.UseSystemPasswordChar = true;
        
        // lblEmail
        this.lblEmail.AutoSize = true;
        this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.lblEmail.Location = new System.Drawing.Point(30, 250);
        this.lblEmail.Name = "lblEmail";
        this.lblEmail.Size = new System.Drawing.Size(50, 19);
        this.lblEmail.Text = "Email:*";
        
        // txtEmail
        this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.txtEmail.Location = new System.Drawing.Point(30, 272);
        this.txtEmail.Name = "txtEmail";
        this.txtEmail.Size = new System.Drawing.Size(370, 25);
        this.txtEmail.TabIndex = 4;
        
        // lblFullName
        this.lblFullName.AutoSize = true;
        this.lblFullName.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.lblFullName.Location = new System.Drawing.Point(30, 310);
        this.lblFullName.Name = "lblFullName";
        this.lblFullName.Size = new System.Drawing.Size(78, 19);
        this.lblFullName.Text = "Full Name:*";
        
        // txtFullName
        this.txtFullName.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.txtFullName.Location = new System.Drawing.Point(30, 332);
        this.txtFullName.Name = "txtFullName";
        this.txtFullName.Size = new System.Drawing.Size(370, 25);
        this.txtFullName.TabIndex = 5;
        
        // lblPhoneNumber
        this.lblPhoneNumber.AutoSize = true;
        this.lblPhoneNumber.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.lblPhoneNumber.Location = new System.Drawing.Point(30, 370);
        this.lblPhoneNumber.Name = "lblPhoneNumber";
        this.lblPhoneNumber.Size = new System.Drawing.Size(108, 19);
        this.lblPhoneNumber.Text = "Phone Number:";
        
        // txtPhoneNumber
        this.txtPhoneNumber.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.txtPhoneNumber.Location = new System.Drawing.Point(30, 392);
        this.txtPhoneNumber.Name = "txtPhoneNumber";
        this.txtPhoneNumber.Size = new System.Drawing.Size(370, 25);
        this.txtPhoneNumber.TabIndex = 6;
        
        // lblAddress
        this.lblAddress.AutoSize = true;
        this.lblAddress.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.lblAddress.Location = new System.Drawing.Point(30, 430);
        this.lblAddress.Name = "lblAddress";
        this.lblAddress.Size = new System.Drawing.Size(63, 19);
        this.lblAddress.Text = "Address:";
        
        // txtAddress
        this.txtAddress.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.txtAddress.Location = new System.Drawing.Point(30, 452);
        this.txtAddress.Multiline = true;
        this.txtAddress.Name = "txtAddress";
        this.txtAddress.Size = new System.Drawing.Size(370, 50);
        this.txtAddress.TabIndex = 7;
        
        // chkShowPassword
        this.chkShowPassword.AutoSize = true;
        this.chkShowPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.chkShowPassword.Location = new System.Drawing.Point(30, 510);
        this.chkShowPassword.Name = "chkShowPassword";
        this.chkShowPassword.Size = new System.Drawing.Size(112, 19);
        this.chkShowPassword.Text = "Show Password";
        this.chkShowPassword.CheckedChanged += new EventHandler(this.chkShowPassword_CheckedChanged);
        
        // btnRegister
        this.btnRegister.BackColor = System.Drawing.Color.FromArgb(34, 139, 34);
        this.btnRegister.FlatStyle = FlatStyle.Flat;
        this.btnRegister.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
        this.btnRegister.ForeColor = System.Drawing.Color.White;
        this.btnRegister.Location = new System.Drawing.Point(30, 545);
        this.btnRegister.Name = "btnRegister";
        this.btnRegister.Size = new System.Drawing.Size(180, 38);
        this.btnRegister.TabIndex = 8;
        this.btnRegister.Text = "Register";
        this.btnRegister.UseVisualStyleBackColor = false;
        this.btnRegister.Click += new EventHandler(this.btnRegister_Click);
        
        // btnCancel
        this.btnCancel.BackColor = System.Drawing.Color.LightGray;
        this.btnCancel.FlatStyle = FlatStyle.Flat;
        this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 11F);
        this.btnCancel.Location = new System.Drawing.Point(220, 545);
        this.btnCancel.Name = "btnCancel";
        this.btnCancel.Size = new System.Drawing.Size(180, 38);
        this.btnCancel.TabIndex = 9;
        this.btnCancel.Text = "Cancel";
        this.btnCancel.UseVisualStyleBackColor = false;
        this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
        
        // RegisterForm
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.FromArgb(240, 255, 240);
        this.ClientSize = new System.Drawing.Size(500, 650);
        this.Controls.Add(this.panelMain);
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "RegisterForm";
        this.StartPosition = FormStartPosition.CenterParent;
        this.Text = "Customer Registration";
        this.panelMain.ResumeLayout(false);
        this.panelMain.PerformLayout();
        this.ResumeLayout(false);
    }
}
