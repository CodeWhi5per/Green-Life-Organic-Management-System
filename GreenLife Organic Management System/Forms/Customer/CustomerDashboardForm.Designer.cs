namespace GreenLife_Organic_Management_System.Forms.Customer;

partial class CustomerDashboardForm
{
    private System.ComponentModel.IContainer components = null;
    private Label lblWelcome;
    private DataGridView dgvProducts;
    private TextBox txtSearch;
    private ComboBox cmbCategory;
    private TextBox txtMinPrice;
    private TextBox txtMaxPrice;
    private Button btnSearch;
    private TextBox txtQuantity;
    private Button btnAddToCart;
    private Button btnViewCart;
    private Button btnMyOrders;
    private Button btnProfile;
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
        this.lblWelcome = new Label();
        this.dgvProducts = new DataGridView();
        this.txtSearch = new TextBox();
        this.cmbCategory = new ComboBox();
        this.txtMinPrice = new TextBox();
        this.txtMaxPrice = new TextBox();
        this.btnSearch = new Button();
        this.txtQuantity = new TextBox();
        this.btnAddToCart = new Button();
        this.btnViewCart = new Button();
        this.btnMyOrders = new Button();
        this.btnProfile = new Button();
        this.btnLogout = new Button();
        ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
        this.SuspendLayout();
        
        // lblWelcome
        this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
        this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(34, 139, 34);
        this.lblWelcome.Location = new System.Drawing.Point(20, 15);
        this.lblWelcome.Size = new System.Drawing.Size(600, 35);
        this.lblWelcome.Text = "Welcome, Customer!";
        
        // Search controls
        this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.txtSearch.Location = new System.Drawing.Point(20, 60);
        this.txtSearch.PlaceholderText = "Search products...";
        this.txtSearch.Size = new System.Drawing.Size(250, 25);
        
        this.cmbCategory.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.cmbCategory.Location = new System.Drawing.Point(280, 60);
        this.cmbCategory.Size = new System.Drawing.Size(150, 25);
        this.cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
        
        this.txtMinPrice.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.txtMinPrice.Location = new System.Drawing.Point(440, 60);
        this.txtMinPrice.PlaceholderText = "Min Price";
        this.txtMinPrice.Size = new System.Drawing.Size(90, 25);
        
        this.txtMaxPrice.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.txtMaxPrice.Location = new System.Drawing.Point(540, 60);
        this.txtMaxPrice.PlaceholderText = "Max Price";
        this.txtMaxPrice.Size = new System.Drawing.Size(90, 25);
        
        this.btnSearch.BackColor = System.Drawing.Color.FromArgb(34, 139, 34);
        this.btnSearch.FlatStyle = FlatStyle.Flat;
        this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.btnSearch.ForeColor = System.Drawing.Color.White;
        this.btnSearch.Location = new System.Drawing.Point(640, 58);
        this.btnSearch.Size = new System.Drawing.Size(100, 30);
        this.btnSearch.Text = "Search";
        this.btnSearch.Click += new EventHandler(this.btnSearch_Click);
        
        // dgvProducts
        this.dgvProducts.AllowUserToAddRows = false;
        this.dgvProducts.AllowUserToDeleteRows = false;
        this.dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvProducts.BackgroundColor = System.Drawing.Color.White;
        this.dgvProducts.Location = new System.Drawing.Point(20, 100);
        this.dgvProducts.ReadOnly = true;
        this.dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        this.dgvProducts.Size = new System.Drawing.Size(960, 400);
        
        // Cart controls
        this.txtQuantity.Font = new System.Drawing.Font("Segoe UI", 11F);
        this.txtQuantity.Location = new System.Drawing.Point(20, 520);
        this.txtQuantity.Size = new System.Drawing.Size(80, 27);
        this.txtQuantity.Text = "1";
        this.txtQuantity.TextAlign = HorizontalAlignment.Center;
        
        this.btnAddToCart.BackColor = System.Drawing.Color.FromArgb(34, 139, 34);
        this.btnAddToCart.FlatStyle = FlatStyle.Flat;
        this.btnAddToCart.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
        this.btnAddToCart.ForeColor = System.Drawing.Color.White;
        this.btnAddToCart.Location = new System.Drawing.Point(110, 515);
        this.btnAddToCart.Size = new System.Drawing.Size(150, 35);
        this.btnAddToCart.Text = "Add to Cart";
        this.btnAddToCart.Click += new EventHandler(this.btnAddToCart_Click);
        
        // Navigation buttons
        this.btnViewCart.BackColor = System.Drawing.Color.FromArgb(255, 193, 7);
        this.btnViewCart.FlatStyle = FlatStyle.Flat;
        this.btnViewCart.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
        this.btnViewCart.Location = new System.Drawing.Point(650, 15);
        this.btnViewCart.Size = new System.Drawing.Size(150, 35);
        this.btnViewCart.Text = "View Cart (0)";
        this.btnViewCart.Click += new EventHandler(this.btnViewCart_Click);
        
        this.btnMyOrders.BackColor = System.Drawing.Color.FromArgb(70, 130, 180);
        this.btnMyOrders.FlatStyle = FlatStyle.Flat;
        this.btnMyOrders.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
        this.btnMyOrders.ForeColor = System.Drawing.Color.White;
        this.btnMyOrders.Location = new System.Drawing.Point(280, 515);
        this.btnMyOrders.Size = new System.Drawing.Size(150, 35);
        this.btnMyOrders.Text = "My Orders";
        this.btnMyOrders.Click += new EventHandler(this.btnMyOrders_Click);
        
        this.btnProfile.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
        this.btnProfile.FlatStyle = FlatStyle.Flat;
        this.btnProfile.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
        this.btnProfile.ForeColor = System.Drawing.Color.White;
        this.btnProfile.Location = new System.Drawing.Point(450, 515);
        this.btnProfile.Size = new System.Drawing.Size(150, 35);
        this.btnProfile.Text = "My Profile";
        this.btnProfile.Click += new EventHandler(this.btnProfile_Click);
        
        this.btnLogout.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
        this.btnLogout.FlatStyle = FlatStyle.Flat;
        this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
        this.btnLogout.ForeColor = System.Drawing.Color.White;
        this.btnLogout.Location = new System.Drawing.Point(810, 15);
        this.btnLogout.Size = new System.Drawing.Size(170, 35);
        this.btnLogout.Text = "Logout";
        this.btnLogout.Click += new EventHandler(this.btnLogout_Click);
        
        // CustomerDashboardForm
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.FromArgb(240, 255, 240);
        this.ClientSize = new System.Drawing.Size(1000, 570);
        this.Controls.Add(this.lblWelcome);
        this.Controls.Add(this.txtSearch);
        this.Controls.Add(this.cmbCategory);
        this.Controls.Add(this.txtMinPrice);
        this.Controls.Add(this.txtMaxPrice);
        this.Controls.Add(this.btnSearch);
        this.Controls.Add(this.dgvProducts);
        this.Controls.Add(this.txtQuantity);
        this.Controls.Add(this.btnAddToCart);
        this.Controls.Add(this.btnViewCart);
        this.Controls.Add(this.btnMyOrders);
        this.Controls.Add(this.btnProfile);
        this.Controls.Add(this.btnLogout);
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;
        this.Name = "CustomerDashboardForm";
        this.StartPosition = FormStartPosition.CenterScreen;
        this.Text = "GreenLife Organic Store - Shop";
        this.Load += new EventHandler(this.CustomerDashboardForm_Load);
        ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();
    }
}
