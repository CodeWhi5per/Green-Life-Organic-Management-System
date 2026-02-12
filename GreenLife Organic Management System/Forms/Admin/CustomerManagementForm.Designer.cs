namespace GreenLife_Organic_Management_System.Forms.Admin;

partial class CustomerManagementForm
{
    private System.ComponentModel.IContainer components = null;
    private DataGridView dgvCustomers;
    private TextBox txtSearch;
    private Button btnSearch;
    private TextBox txtCustomerInfo;
    private Label lblTotalCustomers;
    private Button btnToggleStatus;
    private Button btnClose;
    
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
        this.dgvCustomers = new DataGridView();
        this.txtSearch = new TextBox();
        this.btnSearch = new Button();
        this.txtCustomerInfo = new TextBox();
        this.lblTotalCustomers = new Label();
        this.btnToggleStatus = new Button();
        this.btnClose = new Button();
        ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
        this.SuspendLayout();
        
        // txtSearch
        this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.txtSearch.Location = new System.Drawing.Point(20, 20);
        this.txtSearch.PlaceholderText = "Search by username, name, or email...";
        this.txtSearch.Size = new System.Drawing.Size(350, 25);
        
        // btnSearch
        this.btnSearch.BackColor = System.Drawing.Color.FromArgb(34, 139, 34);
        this.btnSearch.FlatStyle = FlatStyle.Flat;
        this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.btnSearch.ForeColor = System.Drawing.Color.White;
        this.btnSearch.Location = new System.Drawing.Point(380, 18);
        this.btnSearch.Size = new System.Drawing.Size(100, 30);
        this.btnSearch.Text = "Search";
        this.btnSearch.Click += new EventHandler(this.btnSearch_Click);
        
        // lblTotalCustomers
        this.lblTotalCustomers.AutoSize = true;
        this.lblTotalCustomers.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.lblTotalCustomers.ForeColor = System.Drawing.Color.FromArgb(34, 139, 34);
        this.lblTotalCustomers.Location = new System.Drawing.Point(500, 25);
        this.lblTotalCustomers.Text = "Total Customers: 0";
        
        // dgvCustomers
        this.dgvCustomers.AllowUserToAddRows = false;
        this.dgvCustomers.AllowUserToDeleteRows = false;
        this.dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvCustomers.BackgroundColor = System.Drawing.Color.White;
        this.dgvCustomers.Location = new System.Drawing.Point(20, 60);
        this.dgvCustomers.ReadOnly = true;
        this.dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        this.dgvCustomers.Size = new System.Drawing.Size(760, 400);
        this.dgvCustomers.SelectionChanged += new EventHandler(this.dgvCustomers_SelectionChanged);
        
        // txtCustomerInfo
        this.txtCustomerInfo.BackColor = System.Drawing.Color.White;
        this.txtCustomerInfo.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.txtCustomerInfo.Location = new System.Drawing.Point(800, 60);
        this.txtCustomerInfo.Multiline = true;
        this.txtCustomerInfo.ReadOnly = true;
        this.txtCustomerInfo.Size = new System.Drawing.Size(300, 300);
        
        // btnToggleStatus
        this.btnToggleStatus.BackColor = System.Drawing.Color.FromArgb(255, 193, 7);
        this.btnToggleStatus.FlatStyle = FlatStyle.Flat;
        this.btnToggleStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.btnToggleStatus.Location = new System.Drawing.Point(800, 380);
        this.btnToggleStatus.Size = new System.Drawing.Size(300, 40);
        this.btnToggleStatus.Text = "Activate/Deactivate";
        this.btnToggleStatus.Click += new EventHandler(this.btnToggleStatus_Click);
        
        // btnClose
        this.btnClose.BackColor = System.Drawing.Color.Gray;
        this.btnClose.FlatStyle = FlatStyle.Flat;
        this.btnClose.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
        this.btnClose.ForeColor = System.Drawing.Color.White;
        this.btnClose.Location = new System.Drawing.Point(950, 480);
        this.btnClose.Size = new System.Drawing.Size(150, 40);
        this.btnClose.Text = "Close";
        this.btnClose.Click += new EventHandler(this.btnClose_Click);
        
        // CustomerManagementForm
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.FromArgb(240, 255, 240);
        this.ClientSize = new System.Drawing.Size(1120, 540);
        this.Controls.Add(this.txtSearch);
        this.Controls.Add(this.btnSearch);
        this.Controls.Add(this.lblTotalCustomers);
        this.Controls.Add(this.dgvCustomers);
        this.Controls.Add(this.txtCustomerInfo);
        this.Controls.Add(this.btnToggleStatus);
        this.Controls.Add(this.btnClose);
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.Name = "CustomerManagementForm";
        this.StartPosition = FormStartPosition.CenterScreen;
        this.Text = "Customer Management - GreenLife";
        this.Load += new EventHandler(this.CustomerManagementForm_Load);
        ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();
    }
}
