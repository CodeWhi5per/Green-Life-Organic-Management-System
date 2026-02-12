namespace GreenLife_Organic_Management_System.Forms;

partial class LoginForm
{
    private System.ComponentModel.IContainer components = null;
    private TextBox txtUsername;
    private TextBox txtPassword;
    private Button btnLogin;
    private Button btnRegister;
    private Label lblTitle;
    private Label lblUsername;
    private Label lblPassword;
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
        this.txtUsername = new TextBox();
        this.txtPassword = new TextBox();
        this.btnLogin = new Button();
        this.btnRegister = new Button();
        this.lblTitle = new Label();
        this.lblUsername = new Label();
        this.lblPassword = new Label();
        this.chkShowPassword = new CheckBox();
        this.panelMain = new Panel();
        this.panelMain.SuspendLayout();
        this.SuspendLayout();
        
        // panelMain
        this.panelMain.BackColor = System.Drawing.Color.White;
        this.panelMain.BorderStyle = BorderStyle.FixedSingle;
        this.panelMain.Controls.Add(this.lblTitle);
        this.panelMain.Controls.Add(this.lblUsername);
        this.panelMain.Controls.Add(this.txtUsername);
        this.panelMain.Controls.Add(this.lblPassword);
        this.panelMain.Controls.Add(this.txtPassword);
        this.panelMain.Controls.Add(this.chkShowPassword);
        this.panelMain.Controls.Add(this.btnLogin);
        this.panelMain.Controls.Add(this.btnRegister);
        this.panelMain.Location = new System.Drawing.Point(50, 30);
        this.panelMain.Name = "panelMain";
        this.panelMain.Size = new System.Drawing.Size(400, 380);
        this.panelMain.TabIndex = 0;
        
        // lblTitle
        this.lblTitle.AutoSize = false;
        this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
        this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(34, 139, 34);
        this.lblTitle.Location = new System.Drawing.Point(20, 20);
        this.lblTitle.Name = "lblTitle";
        this.lblTitle.Size = new System.Drawing.Size(360, 50);
        this.lblTitle.TabIndex = 0;
        this.lblTitle.Text = "GreenLife Organic Store";
        this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        
        // lblUsername
        this.lblUsername.AutoSize = true;
        this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.lblUsername.Location = new System.Drawing.Point(40, 100);
        this.lblUsername.Name = "lblUsername";
        this.lblUsername.Size = new System.Drawing.Size(75, 19);
        this.lblUsername.TabIndex = 1;
        this.lblUsername.Text = "Username:";
        
        // txtUsername
        this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 11F);
        this.txtUsername.Location = new System.Drawing.Point(40, 125);
        this.txtUsername.Name = "txtUsername";
        this.txtUsername.Size = new System.Drawing.Size(320, 27);
        this.txtUsername.TabIndex = 2;
        
        // lblPassword
        this.lblPassword.AutoSize = true;
        this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.lblPassword.Location = new System.Drawing.Point(40, 170);
        this.lblPassword.Name = "lblPassword";
        this.lblPassword.Size = new System.Drawing.Size(70, 19);
        this.lblPassword.TabIndex = 3;
        this.lblPassword.Text = "Password:";
        
        // txtPassword
        this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 11F);
        this.txtPassword.Location = new System.Drawing.Point(40, 195);
        this.txtPassword.Name = "txtPassword";
        this.txtPassword.Size = new System.Drawing.Size(320, 27);
        this.txtPassword.TabIndex = 4;
        this.txtPassword.UseSystemPasswordChar = true;
        
        // chkShowPassword
        this.chkShowPassword.AutoSize = true;
        this.chkShowPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.chkShowPassword.Location = new System.Drawing.Point(40, 230);
        this.chkShowPassword.Name = "chkShowPassword";
        this.chkShowPassword.Size = new System.Drawing.Size(112, 19);
        this.chkShowPassword.TabIndex = 5;
        this.chkShowPassword.Text = "Show Password";
        this.chkShowPassword.UseVisualStyleBackColor = true;
        this.chkShowPassword.CheckedChanged += new EventHandler(this.chkShowPassword_CheckedChanged);
        
        // btnLogin
        this.btnLogin.BackColor = System.Drawing.Color.FromArgb(34, 139, 34);
        this.btnLogin.FlatStyle = FlatStyle.Flat;
        this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
        this.btnLogin.ForeColor = System.Drawing.Color.White;
        this.btnLogin.Location = new System.Drawing.Point(40, 270);
        this.btnLogin.Name = "btnLogin";
        this.btnLogin.Size = new System.Drawing.Size(320, 40);
        this.btnLogin.TabIndex = 6;
        this.btnLogin.Text = "Login";
        this.btnLogin.UseVisualStyleBackColor = false;
        this.btnLogin.Click += new EventHandler(this.btnLogin_Click);
        
        // btnRegister
        this.btnRegister.BackColor = System.Drawing.Color.White;
        this.btnRegister.FlatStyle = FlatStyle.Flat;
        this.btnRegister.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.btnRegister.ForeColor = System.Drawing.Color.FromArgb(34, 139, 34);
        this.btnRegister.Location = new System.Drawing.Point(40, 320);
        this.btnRegister.Name = "btnRegister";
        this.btnRegister.Size = new System.Drawing.Size(320, 35);
        this.btnRegister.TabIndex = 7;
        this.btnRegister.Text = "New Customer? Register Here";
        this.btnRegister.UseVisualStyleBackColor = false;
        this.btnRegister.Click += new EventHandler(this.btnRegister_Click);
        
        // LoginForm
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.FromArgb(240, 255, 240);
        this.ClientSize = new System.Drawing.Size(500, 450);
        this.Controls.Add(this.panelMain);
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;
        this.Name = "LoginForm";
        this.StartPosition = FormStartPosition.CenterScreen;
        this.Text = "GreenLife Organic Store - Login";
        this.Load += new EventHandler(this.LoginForm_Load);
        this.panelMain.ResumeLayout(false);
        this.panelMain.PerformLayout();
        this.ResumeLayout(false);
    }
}
