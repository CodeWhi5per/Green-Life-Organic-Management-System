namespace GreenLife_Organic_Management_System.Forms.Admin;

partial class AdminDashboardForm
{
    private System.ComponentModel.IContainer components = null;
    private Label lblWelcome;
    private Label lblTitle;
    private Panel panelStats;
    private Label lblTotalProductsLabel;
    private Label lblTotalProducts;
    private Label lblLowStockLabel;
    private Label lblLowStock;
    private Label lblTotalOrdersLabel;
    private Label lblTotalOrders;
    private Label lblTotalSalesLabel;
    private Label lblTotalSales;
    private Button btnProducts;
    private Button btnCustomers;
    private Button btnOrders;
    private Button btnReports;
    private Button btnLogout;
    
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
        this.lblWelcome = new Label();
        this.panelStats = new Panel();
        this.lblTotalProductsLabel = new Label();
        this.lblTotalProducts = new Label();
        this.lblLowStockLabel = new Label();
        this.lblLowStock = new Label();
        this.lblTotalOrdersLabel = new Label();
        this.lblTotalOrders = new Label();
        this.lblTotalSalesLabel = new Label();
        this.lblTotalSales = new Label();
        this.btnProducts = new Button();
        this.btnCustomers = new Button();
        this.btnOrders = new Button();
        this.btnReports = new Button();
        this.btnLogout = new Button();
        this.panelStats.SuspendLayout();
        this.SuspendLayout();
        
        // lblTitle
        this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
        this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(34, 139, 34);
        this.lblTitle.Location = new System.Drawing.Point(20, 20);
        this.lblTitle.Name = "lblTitle";
        this.lblTitle.Size = new System.Drawing.Size(400, 45);
        this.lblTitle.Text = "Admin Dashboard";
        
        // lblWelcome
        this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 12F);
        this.lblWelcome.Location = new System.Drawing.Point(20, 70);
        this.lblWelcome.Name = "lblWelcome";
        this.lblWelcome.Size = new System.Drawing.Size(400, 25);
        this.lblWelcome.Text = "Welcome, Admin!";
        
        // panelStats
        this.panelStats.BackColor = System.Drawing.Color.White;
        this.panelStats.BorderStyle = BorderStyle.FixedSingle;
        this.panelStats.Controls.Add(this.lblTotalProductsLabel);
        this.panelStats.Controls.Add(this.lblTotalProducts);
        this.panelStats.Controls.Add(this.lblLowStockLabel);
        this.panelStats.Controls.Add(this.lblLowStock);
        this.panelStats.Controls.Add(this.lblTotalOrdersLabel);
        this.panelStats.Controls.Add(this.lblTotalOrders);
        this.panelStats.Controls.Add(this.lblTotalSalesLabel);
        this.panelStats.Controls.Add(this.lblTotalSales);
        this.panelStats.Location = new System.Drawing.Point(20, 120);
        this.panelStats.Name = "panelStats";
        this.panelStats.Size = new System.Drawing.Size(760, 120);
        
        // Statistics Labels
        this.lblTotalProductsLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.lblTotalProductsLabel.Location = new System.Drawing.Point(20, 20);
        this.lblTotalProductsLabel.Size = new System.Drawing.Size(150, 25);
        this.lblTotalProductsLabel.Text = "Total Products:";
        
        this.lblTotalProducts.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
        this.lblTotalProducts.ForeColor = System.Drawing.Color.FromArgb(34, 139, 34);
        this.lblTotalProducts.Location = new System.Drawing.Point(20, 45);
        this.lblTotalProducts.Size = new System.Drawing.Size(150, 40);
        this.lblTotalProducts.Text = "0";
        
        this.lblLowStockLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.lblLowStockLabel.Location = new System.Drawing.Point(210, 20);
        this.lblLowStockLabel.Size = new System.Drawing.Size(150, 25);
        this.lblLowStockLabel.Text = "Low Stock Alert:";
        
        this.lblLowStock.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
        this.lblLowStock.ForeColor = System.Drawing.Color.Orange;
        this.lblLowStock.Location = new System.Drawing.Point(210, 45);
        this.lblLowStock.Size = new System.Drawing.Size(150, 40);
        this.lblLowStock.Text = "0";
        
        this.lblTotalOrdersLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.lblTotalOrdersLabel.Location = new System.Drawing.Point(400, 20);
        this.lblTotalOrdersLabel.Size = new System.Drawing.Size(150, 25);
        this.lblTotalOrdersLabel.Text = "Total Orders:";
        
        this.lblTotalOrders.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
        this.lblTotalOrders.ForeColor = System.Drawing.Color.FromArgb(34, 139, 34);
        this.lblTotalOrders.Location = new System.Drawing.Point(400, 45);
        this.lblTotalOrders.Size = new System.Drawing.Size(150, 40);
        this.lblTotalOrders.Text = "0";
        
        this.lblTotalSalesLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.lblTotalSalesLabel.Location = new System.Drawing.Point(590, 20);
        this.lblTotalSalesLabel.Size = new System.Drawing.Size(150, 25);
        this.lblTotalSalesLabel.Text = "Total Sales:";
        
        this.lblTotalSales.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
        this.lblTotalSales.ForeColor = System.Drawing.Color.FromArgb(34, 139, 34);
        this.lblTotalSales.Location = new System.Drawing.Point(590, 45);
        this.lblTotalSales.Size = new System.Drawing.Size(150, 40);
        this.lblTotalSales.Text = "$0.00";
        
        // Buttons
        var buttonY = 270;
        this.btnProducts.BackColor = System.Drawing.Color.FromArgb(34, 139, 34);
        this.btnProducts.FlatStyle = FlatStyle.Flat;
        this.btnProducts.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
        this.btnProducts.ForeColor = System.Drawing.Color.White;
        this.btnProducts.Location = new System.Drawing.Point(20, buttonY);
        this.btnProducts.Name = "btnProducts";
        this.btnProducts.Size = new System.Drawing.Size(180, 60);
        this.btnProducts.Text = "Manage Products";
        this.btnProducts.Click += new EventHandler(this.btnProducts_Click);
        
        this.btnCustomers.BackColor = System.Drawing.Color.FromArgb(34, 139, 34);
        this.btnCustomers.FlatStyle = FlatStyle.Flat;
        this.btnCustomers.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
        this.btnCustomers.ForeColor = System.Drawing.Color.White;
        this.btnCustomers.Location = new System.Drawing.Point(220, buttonY);
        this.btnCustomers.Name = "btnCustomers";
        this.btnCustomers.Size = new System.Drawing.Size(180, 60);
        this.btnCustomers.Text = "Manage Customers";
        this.btnCustomers.Click += new EventHandler(this.btnCustomers_Click);
        
        this.btnOrders.BackColor = System.Drawing.Color.FromArgb(34, 139, 34);
        this.btnOrders.FlatStyle = FlatStyle.Flat;
        this.btnOrders.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
        this.btnOrders.ForeColor = System.Drawing.Color.White;
        this.btnOrders.Location = new System.Drawing.Point(420, buttonY);
        this.btnOrders.Name = "btnOrders";
        this.btnOrders.Size = new System.Drawing.Size(180, 60);
        this.btnOrders.Text = "Manage Orders";
        this.btnOrders.Click += new EventHandler(this.btnOrders_Click);
        
        this.btnReports.BackColor = System.Drawing.Color.FromArgb(70, 130, 180);
        this.btnReports.FlatStyle = FlatStyle.Flat;
        this.btnReports.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
        this.btnReports.ForeColor = System.Drawing.Color.White;
        this.btnReports.Location = new System.Drawing.Point(20, buttonY + 80);
        this.btnReports.Name = "btnReports";
        this.btnReports.Size = new System.Drawing.Size(280, 60);
        this.btnReports.Text = "Generate Reports";
        this.btnReports.Click += new EventHandler(this.btnReports_Click);
        
        this.btnLogout.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
        this.btnLogout.FlatStyle = FlatStyle.Flat;
        this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
        this.btnLogout.ForeColor = System.Drawing.Color.White;
        this.btnLogout.Location = new System.Drawing.Point(320, buttonY + 80);
        this.btnLogout.Name = "btnLogout";
        this.btnLogout.Size = new System.Drawing.Size(280, 60);
        this.btnLogout.Text = "Logout";
        this.btnLogout.Click += new EventHandler(this.btnLogout_Click);
        
        // AdminDashboardForm
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.FromArgb(240, 255, 240);
        this.ClientSize = new System.Drawing.Size(800, 500);
        this.Controls.Add(this.lblTitle);
        this.Controls.Add(this.lblWelcome);
        this.Controls.Add(this.panelStats);
        this.Controls.Add(this.btnProducts);
        this.Controls.Add(this.btnCustomers);
        this.Controls.Add(this.btnOrders);
        this.Controls.Add(this.btnReports);
        this.Controls.Add(this.btnLogout);
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;
        this.Name = "AdminDashboardForm";
        this.StartPosition = FormStartPosition.CenterScreen;
        this.Text = "Admin Dashboard - GreenLife Organic Store";
        this.Load += new EventHandler(this.AdminDashboardForm_Load);
        this.panelStats.ResumeLayout(false);
        this.ResumeLayout(false);
    }
}
