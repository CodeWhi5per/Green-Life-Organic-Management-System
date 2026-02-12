namespace GreenLife_Organic_Management_System.Forms.Customer;

partial class MyOrdersForm
{
    private System.ComponentModel.IContainer components = null;
    private DataGridView dgvOrders;
    private TextBox txtOrderDetails;
    private Label lblTotalOrders;
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
        this.dgvOrders = new DataGridView();
        this.txtOrderDetails = new TextBox();
        this.lblTotalOrders = new Label();
        this.btnClose = new Button();
        ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
        this.SuspendLayout();
        
        // lblTotalOrders
        this.lblTotalOrders.AutoSize = true;
        this.lblTotalOrders.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
        this.lblTotalOrders.ForeColor = System.Drawing.Color.FromArgb(34, 139, 34);
        this.lblTotalOrders.Location = new System.Drawing.Point(20, 20);
        this.lblTotalOrders.Text = "Total Orders: 0";
        
        // dgvOrders
        this.dgvOrders.AllowUserToAddRows = false;
        this.dgvOrders.AllowUserToDeleteRows = false;
        this.dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvOrders.BackgroundColor = System.Drawing.Color.White;
        this.dgvOrders.Location = new System.Drawing.Point(20, 55);
        this.dgvOrders.ReadOnly = true;
        this.dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        this.dgvOrders.Size = new System.Drawing.Size(560, 400);
        this.dgvOrders.SelectionChanged += new EventHandler(this.dgvOrders_SelectionChanged);
        
        // txtOrderDetails
        this.txtOrderDetails.BackColor = System.Drawing.Color.White;
        this.txtOrderDetails.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.txtOrderDetails.Location = new System.Drawing.Point(600, 55);
        this.txtOrderDetails.Multiline = true;
        this.txtOrderDetails.ReadOnly = true;
        this.txtOrderDetails.ScrollBars = ScrollBars.Vertical;
        this.txtOrderDetails.Size = new System.Drawing.Size(350, 400);
        
        // btnClose
        this.btnClose.BackColor = System.Drawing.Color.Gray;
        this.btnClose.FlatStyle = FlatStyle.Flat;
        this.btnClose.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
        this.btnClose.ForeColor = System.Drawing.Color.White;
        this.btnClose.Location = new System.Drawing.Point(800, 470);
        this.btnClose.Size = new System.Drawing.Size(150, 40);
        this.btnClose.Text = "Close";
        this.btnClose.Click += new EventHandler(this.btnClose_Click);
        
        // MyOrdersForm
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.FromArgb(240, 255, 240);
        this.ClientSize = new System.Drawing.Size(970, 530);
        this.Controls.Add(this.lblTotalOrders);
        this.Controls.Add(this.dgvOrders);
        this.Controls.Add(this.txtOrderDetails);
        this.Controls.Add(this.btnClose);
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "MyOrdersForm";
        this.StartPosition = FormStartPosition.CenterParent;
        this.Text = "My Orders - GreenLife";
        this.Load += new EventHandler(this.MyOrdersForm_Load);
        ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();
    }
}
