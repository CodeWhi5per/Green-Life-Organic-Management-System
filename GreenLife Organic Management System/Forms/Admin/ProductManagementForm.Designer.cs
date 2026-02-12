namespace GreenLife_Organic_Management_System.Forms.Admin;

partial class ProductManagementForm
{
    private System.ComponentModel.IContainer components = null;
    private DataGridView dgvProducts;
    private TextBox txtSearch;
    private ComboBox cmbCategory;
    private Button btnSearch;
    private GroupBox grpProductDetails;
    private Label lblName;
    private TextBox txtName;
    private Label lblCategory;
    private TextBox txtCategory;
    private Label lblDescription;
    private TextBox txtDescription;
    private Label lblPrice;
    private TextBox txtPrice;
    private Label lblStock;
    private TextBox txtStock;
    private Label lblSupplier;
    private TextBox txtSupplier;
    private Label lblDiscount;
    private TextBox txtDiscount;
    private CheckBox chkActive;
    private Button btnAdd;
    private Button btnEdit;
    private Button btnSave;
    private Button btnDelete;
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
        this.dgvProducts = new DataGridView();
        this.txtSearch = new TextBox();
        this.cmbCategory = new ComboBox();
        this.btnSearch = new Button();
        this.grpProductDetails = new GroupBox();
        this.lblName = new Label();
        this.txtName = new TextBox();
        this.lblCategory = new Label();
        this.txtCategory = new TextBox();
        this.lblDescription = new Label();
        this.txtDescription = new TextBox();
        this.lblPrice = new Label();
        this.txtPrice = new TextBox();
        this.lblStock = new Label();
        this.txtStock = new TextBox();
        this.lblSupplier = new Label();
        this.txtSupplier = new TextBox();
        this.lblDiscount = new Label();
        this.txtDiscount = new TextBox();
        this.chkActive = new CheckBox();
        this.btnAdd = new Button();
        this.btnEdit = new Button();
        this.btnSave = new Button();
        this.btnDelete = new Button();
        this.btnClose = new Button();
        ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
        this.grpProductDetails.SuspendLayout();
        this.SuspendLayout();
        
        // dgvProducts
        this.dgvProducts.AllowUserToAddRows = false;
        this.dgvProducts.AllowUserToDeleteRows = false;
        this.dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvProducts.BackgroundColor = System.Drawing.Color.White;
        this.dgvProducts.Location = new System.Drawing.Point(20, 70);
        this.dgvProducts.Name = "dgvProducts";
        this.dgvProducts.ReadOnly = true;
        this.dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        this.dgvProducts.Size = new System.Drawing.Size(750, 300);
        
        // Search controls
        this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.txtSearch.Location = new System.Drawing.Point(20, 30);
        this.txtSearch.Name = "txtSearch";
        this.txtSearch.PlaceholderText = "Search products...";
        this.txtSearch.Size = new System.Drawing.Size(250, 25);
        
        this.cmbCategory.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.cmbCategory.Location = new System.Drawing.Point(280, 30);
        this.cmbCategory.Name = "cmbCategory";
        this.cmbCategory.Size = new System.Drawing.Size(180, 25);
        
        this.btnSearch.BackColor = System.Drawing.Color.FromArgb(34, 139, 34);
        this.btnSearch.FlatStyle = FlatStyle.Flat;
        this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.btnSearch.ForeColor = System.Drawing.Color.White;
        this.btnSearch.Location = new System.Drawing.Point(470, 28);
        this.btnSearch.Name = "btnSearch";
        this.btnSearch.Size = new System.Drawing.Size(100, 30);
        this.btnSearch.Text = "Search";
        this.btnSearch.Click += new EventHandler(this.btnSearch_Click);
        
        // grpProductDetails
        this.grpProductDetails.Controls.Add(this.lblName);
        this.grpProductDetails.Controls.Add(this.txtName);
        this.grpProductDetails.Controls.Add(this.lblCategory);
        this.grpProductDetails.Controls.Add(this.txtCategory);
        this.grpProductDetails.Controls.Add(this.lblDescription);
        this.grpProductDetails.Controls.Add(this.txtDescription);
        this.grpProductDetails.Controls.Add(this.lblPrice);
        this.grpProductDetails.Controls.Add(this.txtPrice);
        this.grpProductDetails.Controls.Add(this.lblStock);
        this.grpProductDetails.Controls.Add(this.txtStock);
        this.grpProductDetails.Controls.Add(this.lblSupplier);
        this.grpProductDetails.Controls.Add(this.txtSupplier);
        this.grpProductDetails.Controls.Add(this.lblDiscount);
        this.grpProductDetails.Controls.Add(this.txtDiscount);
        this.grpProductDetails.Controls.Add(this.chkActive);
        this.grpProductDetails.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.grpProductDetails.Location = new System.Drawing.Point(790, 30);
        this.grpProductDetails.Name = "grpProductDetails";
        this.grpProductDetails.Size = new System.Drawing.Size(310, 460);
        this.grpProductDetails.Text = "Product Details";
        
        // Product detail controls
        int yPos = 35;
        int spacing = 60;
        
        this.lblName.AutoSize = true;
        this.lblName.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.lblName.Location = new System.Drawing.Point(15, yPos);
        this.lblName.Text = "Name:*";
        
        this.txtName.Enabled = false;
        this.txtName.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.txtName.Location = new System.Drawing.Point(15, yPos + 20);
        this.txtName.Size = new System.Drawing.Size(280, 23);
        
        yPos += spacing;
        this.lblCategory.AutoSize = true;
        this.lblCategory.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.lblCategory.Location = new System.Drawing.Point(15, yPos);
        this.lblCategory.Text = "Category:*";
        
        this.txtCategory.Enabled = false;
        this.txtCategory.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.txtCategory.Location = new System.Drawing.Point(15, yPos + 20);
        this.txtCategory.Size = new System.Drawing.Size(280, 23);
        
        yPos += spacing;
        this.lblDescription.AutoSize = true;
        this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.lblDescription.Location = new System.Drawing.Point(15, yPos);
        this.lblDescription.Text = "Description:";
        
        this.txtDescription.Enabled = false;
        this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.txtDescription.Location = new System.Drawing.Point(15, yPos + 20);
        this.txtDescription.Multiline = true;
        this.txtDescription.Size = new System.Drawing.Size(280, 50);
        
        yPos += 80;
        this.lblPrice.AutoSize = true;
        this.lblPrice.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.lblPrice.Location = new System.Drawing.Point(15, yPos);
        this.lblPrice.Text = "Price:*";
        
        this.txtPrice.Enabled = false;
        this.txtPrice.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.txtPrice.Location = new System.Drawing.Point(15, yPos + 20);
        this.txtPrice.Size = new System.Drawing.Size(130, 23);
        
        this.lblStock.AutoSize = true;
        this.lblStock.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.lblStock.Location = new System.Drawing.Point(165, yPos);
        this.lblStock.Text = "Stock:*";
        
        this.txtStock.Enabled = false;
        this.txtStock.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.txtStock.Location = new System.Drawing.Point(165, yPos + 20);
        this.txtStock.Size = new System.Drawing.Size(130, 23);
        
        yPos += spacing;
        this.lblSupplier.AutoSize = true;
        this.lblSupplier.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.lblSupplier.Location = new System.Drawing.Point(15, yPos);
        this.lblSupplier.Text = "Supplier:";
        
        this.txtSupplier.Enabled = false;
        this.txtSupplier.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.txtSupplier.Location = new System.Drawing.Point(15, yPos + 20);
        this.txtSupplier.Size = new System.Drawing.Size(280, 23);
        
        yPos += spacing;
        this.lblDiscount.AutoSize = true;
        this.lblDiscount.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.lblDiscount.Location = new System.Drawing.Point(15, yPos);
        this.lblDiscount.Text = "Discount %:";
        
        this.txtDiscount.Enabled = false;
        this.txtDiscount.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.txtDiscount.Location = new System.Drawing.Point(15, yPos + 20);
        this.txtDiscount.Size = new System.Drawing.Size(130, 23);
        
        this.chkActive.Checked = true;
        this.chkActive.Enabled = false;
        this.chkActive.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.chkActive.Location = new System.Drawing.Point(165, yPos + 20);
        this.chkActive.Text = "Active";
        
        // Action buttons
        this.btnAdd.BackColor = System.Drawing.Color.FromArgb(34, 139, 34);
        this.btnAdd.FlatStyle = FlatStyle.Flat;
        this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.btnAdd.ForeColor = System.Drawing.Color.White;
        this.btnAdd.Location = new System.Drawing.Point(20, 390);
        this.btnAdd.Size = new System.Drawing.Size(120, 40);
        this.btnAdd.Text = "Add New";
        this.btnAdd.Click += new EventHandler(this.btnAdd_Click);
        
        this.btnEdit.BackColor = System.Drawing.Color.FromArgb(255, 193, 7);
        this.btnEdit.FlatStyle = FlatStyle.Flat;
        this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.btnEdit.Location = new System.Drawing.Point(150, 390);
        this.btnEdit.Size = new System.Drawing.Size(120, 40);
        this.btnEdit.Text = "Edit";
        this.btnEdit.Click += new EventHandler(this.btnEdit_Click);
        
        this.btnSave.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
        this.btnSave.Enabled = false;
        this.btnSave.FlatStyle = FlatStyle.Flat;
        this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.btnSave.ForeColor = System.Drawing.Color.White;
        this.btnSave.Location = new System.Drawing.Point(790, 500);
        this.btnSave.Size = new System.Drawing.Size(150, 40);
        this.btnSave.Text = "Save";
        this.btnSave.Click += new EventHandler(this.btnSave_Click);
        
        this.btnDelete.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
        this.btnDelete.FlatStyle = FlatStyle.Flat;
        this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.btnDelete.ForeColor = System.Drawing.Color.White;
        this.btnDelete.Location = new System.Drawing.Point(280, 390);
        this.btnDelete.Size = new System.Drawing.Size(120, 40);
        this.btnDelete.Text = "Delete";
        this.btnDelete.Click += new EventHandler(this.btnDelete_Click);
        
        this.btnClose.BackColor = System.Drawing.Color.Gray;
        this.btnClose.FlatStyle = FlatStyle.Flat;
        this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.btnClose.ForeColor = System.Drawing.Color.White;
        this.btnClose.Location = new System.Drawing.Point(950, 500);
        this.btnClose.Size = new System.Drawing.Size(150, 40);
        this.btnClose.Text = "Close";
        this.btnClose.Click += new EventHandler(this.btnClose_Click);
        
        // ProductManagementForm
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.FromArgb(240, 255, 240);
        this.ClientSize = new System.Drawing.Size(1120, 560);
        this.Controls.Add(this.dgvProducts);
        this.Controls.Add(this.txtSearch);
        this.Controls.Add(this.cmbCategory);
        this.Controls.Add(this.btnSearch);
        this.Controls.Add(this.grpProductDetails);
        this.Controls.Add(this.btnAdd);
        this.Controls.Add(this.btnEdit);
        this.Controls.Add(this.btnSave);
        this.Controls.Add(this.btnDelete);
        this.Controls.Add(this.btnClose);
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.Name = "ProductManagementForm";
        this.StartPosition = FormStartPosition.CenterScreen;
        this.Text = "Product Management - GreenLife";
        this.Load += new EventHandler(this.ProductManagementForm_Load);
        ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
        this.grpProductDetails.ResumeLayout(false);
        this.grpProductDetails.PerformLayout();
        this.ResumeLayout(false);
        this.PerformLayout();
    }
}
