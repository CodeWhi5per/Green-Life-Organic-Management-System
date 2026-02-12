namespace GreenLife_Organic_Management_System.Forms.Customer;

partial class CartForm
{
    private System.ComponentModel.IContainer components = null;
    private DataGridView dgvCart;
    private Label lblTotal;
    private TextBox txtNewQuantity;
    private Button btnUpdateQuantity;
    private Button btnRemove;
    private Button btnClearCart;
    private Button btnCheckout;
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
        this.dgvCart = new DataGridView();
        this.lblTotal = new Label();
        this.txtNewQuantity = new TextBox();
        this.btnUpdateQuantity = new Button();
        this.btnRemove = new Button();
        this.btnClearCart = new Button();
        this.btnCheckout = new Button();
        this.btnClose = new Button();
        ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
        this.SuspendLayout();
        
        // dgvCart
        this.dgvCart.AllowUserToAddRows = false;
        this.dgvCart.AllowUserToDeleteRows = false;
        this.dgvCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvCart.BackgroundColor = System.Drawing.Color.White;
        this.dgvCart.Location = new System.Drawing.Point(20, 20);
        this.dgvCart.ReadOnly = true;
        this.dgvCart.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        this.dgvCart.Size = new System.Drawing.Size(660, 350);
        
        // lblTotal
        this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
        this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(34, 139, 34);
        this.lblTotal.Location = new System.Drawing.Point(450, 380);
        this.lblTotal.Size = new System.Drawing.Size(230, 35);
        this.lblTotal.Text = "Total: $0.00";
        this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        
        // txtNewQuantity
        this.txtNewQuantity.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.txtNewQuantity.Location = new System.Drawing.Point(20, 390);
        this.txtNewQuantity.Size = new System.Drawing.Size(70, 25);
        this.txtNewQuantity.Text = "1";
        this.txtNewQuantity.TextAlign = HorizontalAlignment.Center;
        
        // btnUpdateQuantity
        this.btnUpdateQuantity.BackColor = System.Drawing.Color.FromArgb(255, 193, 7);
        this.btnUpdateQuantity.FlatStyle = FlatStyle.Flat;
        this.btnUpdateQuantity.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.btnUpdateQuantity.Location = new System.Drawing.Point(100, 385);
        this.btnUpdateQuantity.Size = new System.Drawing.Size(130, 32);
        this.btnUpdateQuantity.Text = "Update Qty";
        this.btnUpdateQuantity.Click += new EventHandler(this.btnUpdateQuantity_Click);
        
        // btnRemove
        this.btnRemove.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
        this.btnRemove.FlatStyle = FlatStyle.Flat;
        this.btnRemove.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.btnRemove.ForeColor = System.Drawing.Color.White;
        this.btnRemove.Location = new System.Drawing.Point(240, 385);
        this.btnRemove.Size = new System.Drawing.Size(130, 32);
        this.btnRemove.Text = "Remove Item";
        this.btnRemove.Click += new EventHandler(this.btnRemove_Click);
        
        // btnClearCart
        this.btnClearCart.BackColor = System.Drawing.Color.Gray;
        this.btnClearCart.FlatStyle = FlatStyle.Flat;
        this.btnClearCart.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.btnClearCart.ForeColor = System.Drawing.Color.White;
        this.btnClearCart.Location = new System.Drawing.Point(20, 435);
        this.btnClearCart.Size = new System.Drawing.Size(150, 38);
        this.btnClearCart.Text = "Clear Cart";
        this.btnClearCart.Click += new EventHandler(this.btnClearCart_Click);
        
        // btnCheckout
        this.btnCheckout.BackColor = System.Drawing.Color.FromArgb(34, 139, 34);
        this.btnCheckout.FlatStyle = FlatStyle.Flat;
        this.btnCheckout.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
        this.btnCheckout.ForeColor = System.Drawing.Color.White;
        this.btnCheckout.Location = new System.Drawing.Point(390, 430);
        this.btnCheckout.Size = new System.Drawing.Size(290, 45);
        this.btnCheckout.Text = "Proceed to Checkout";
        this.btnCheckout.Click += new EventHandler(this.btnCheckout_Click);
        
        // btnClose
        this.btnClose.BackColor = System.Drawing.Color.Gray;
        this.btnClose.FlatStyle = FlatStyle.Flat;
        this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.btnClose.ForeColor = System.Drawing.Color.White;
        this.btnClose.Location = new System.Drawing.Point(180, 435);
        this.btnClose.Size = new System.Drawing.Size(150, 38);
        this.btnClose.Text = "Continue Shopping";
        this.btnClose.Click += new EventHandler(this.btnClose_Click);
        
        // CartForm
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.FromArgb(240, 255, 240);
        this.ClientSize = new System.Drawing.Size(700, 490);
        this.Controls.Add(this.dgvCart);
        this.Controls.Add(this.lblTotal);
        this.Controls.Add(this.txtNewQuantity);
        this.Controls.Add(this.btnUpdateQuantity);
        this.Controls.Add(this.btnRemove);
        this.Controls.Add(this.btnClearCart);
        this.Controls.Add(this.btnCheckout);
        this.Controls.Add(this.btnClose);
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "CartForm";
        this.StartPosition = FormStartPosition.CenterParent;
        this.Text = "Shopping Cart - GreenLife";
        this.Load += new EventHandler(this.CartForm_Load);
        ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();
    }
}
