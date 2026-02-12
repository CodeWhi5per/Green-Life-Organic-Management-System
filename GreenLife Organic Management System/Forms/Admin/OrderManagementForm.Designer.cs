namespace GreenLife_Organic_Management_System.Forms.Admin;

partial class OrderManagementForm
{
    private System.ComponentModel.IContainer components = null;
    private DataGridView dgvOrders;
    private DataGridView dgvOrderItems;
    private Label lblOrderInfo;
    private ComboBox cmbStatusFilter;
    private ComboBox cmbNewStatus;
    private Button btnUpdateStatus;
    private Button btnClose;
    private GroupBox grpOrderDetails;
    
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
        this.dgvOrders = new DataGridView();
        this.dgvOrderItems = new DataGridView();
        this.lblOrderInfo = new Label();
        this.cmbStatusFilter = new ComboBox();
        this.cmbNewStatus = new ComboBox();
        this.btnUpdateStatus = new Button();
        this.btnClose = new Button();
        this.grpOrderDetails = new GroupBox();
        ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.dgvOrderItems)).BeginInit();
        this.grpOrderDetails.SuspendLayout();
        this.SuspendLayout();
        
        // cmbStatusFilter
        this.cmbStatusFilter.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.cmbStatusFilter.Location = new System.Drawing.Point(20, 20);
        this.cmbStatusFilter.Size = new System.Drawing.Size(200, 25);
        this.cmbStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList;
        this.cmbStatusFilter.SelectedIndexChanged += new EventHandler(this.cmbStatusFilter_SelectedIndexChanged);
        
        // dgvOrders
        this.dgvOrders.AllowUserToAddRows = false;
        this.dgvOrders.AllowUserToDeleteRows = false;
        this.dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvOrders.BackgroundColor = System.Drawing.Color.White;
        this.dgvOrders.Location = new System.Drawing.Point(20, 60);
        this.dgvOrders.ReadOnly = true;
        this.dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        this.dgvOrders.Size = new System.Drawing.Size(960, 250);
        this.dgvOrders.SelectionChanged += new EventHandler(this.dgvOrders_SelectionChanged);
        
        // grpOrderDetails
        this.grpOrderDetails.Controls.Add(this.lblOrderInfo);
        this.grpOrderDetails.Controls.Add(this.dgvOrderItems);
        this.grpOrderDetails.Controls.Add(this.cmbNewStatus);
        this.grpOrderDetails.Controls.Add(this.btnUpdateStatus);
        this.grpOrderDetails.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.grpOrderDetails.Location = new System.Drawing.Point(20, 330);
        this.grpOrderDetails.Size = new System.Drawing.Size(960, 280);
        this.grpOrderDetails.Text = "Order Details";
        
        // lblOrderInfo
        this.lblOrderInfo.AutoSize = false;
        this.lblOrderInfo.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.lblOrderInfo.Location = new System.Drawing.Point(15, 30);
        this.lblOrderInfo.Size = new System.Drawing.Size(500, 80);
        
        // dgvOrderItems
        this.dgvOrderItems.AllowUserToAddRows = false;
        this.dgvOrderItems.AllowUserToDeleteRows = false;
        this.dgvOrderItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvOrderItems.BackgroundColor = System.Drawing.Color.White;
        this.dgvOrderItems.Location = new System.Drawing.Point(15, 120);
        this.dgvOrderItems.ReadOnly = true;
        this.dgvOrderItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        this.dgvOrderItems.Size = new System.Drawing.Size(930, 100);
        
        // cmbNewStatus
        this.cmbNewStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.cmbNewStatus.Location = new System.Drawing.Point(15, 235);
        this.cmbNewStatus.Size = new System.Drawing.Size(200, 25);
        this.cmbNewStatus.DropDownStyle = ComboBoxStyle.DropDownList;
        
        // btnUpdateStatus
        this.btnUpdateStatus.BackColor = System.Drawing.Color.FromArgb(34, 139, 34);
        this.btnUpdateStatus.FlatStyle = FlatStyle.Flat;
        this.btnUpdateStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.btnUpdateStatus.ForeColor = System.Drawing.Color.White;
        this.btnUpdateStatus.Location = new System.Drawing.Point(225, 230);
        this.btnUpdateStatus.Size = new System.Drawing.Size(150, 35);
        this.btnUpdateStatus.Text = "Update Status";
        this.btnUpdateStatus.Click += new EventHandler(this.btnUpdateStatus_Click);
        
        // btnClose
        this.btnClose.BackColor = System.Drawing.Color.Gray;
        this.btnClose.FlatStyle = FlatStyle.Flat;
        this.btnClose.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
        this.btnClose.ForeColor = System.Drawing.Color.White;
        this.btnClose.Location = new System.Drawing.Point(830, 625);
        this.btnClose.Size = new System.Drawing.Size(150, 40);
        this.btnClose.Text = "Close";
        this.btnClose.Click += new EventHandler(this.btnClose_Click);
        
        // OrderManagementForm
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.FromArgb(240, 255, 240);
        this.ClientSize = new System.Drawing.Size(1000, 680);
        this.Controls.Add(this.cmbStatusFilter);
        this.Controls.Add(this.dgvOrders);
        this.Controls.Add(this.grpOrderDetails);
        this.Controls.Add(this.btnClose);
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.Name = "OrderManagementForm";
        this.StartPosition = FormStartPosition.CenterScreen;
        this.Text = "Order Management - GreenLife";
        this.Load += new EventHandler(this.OrderManagementForm_Load);
        ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.dgvOrderItems)).EndInit();
        this.grpOrderDetails.ResumeLayout(false);
        this.ResumeLayout(false);
    }
}
