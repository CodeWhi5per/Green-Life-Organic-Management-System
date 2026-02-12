namespace GreenLife_Organic_Management_System.Forms.Customer;

partial class CheckoutForm
{
    private System.ComponentModel.IContainer components = null;
    private Label lblTitle;
    private Label lblShippingAddress;
    private TextBox txtShippingAddress;
    private Label lblNotes;
    private TextBox txtNotes;
    private Label lblOrderTotal;
    private Label lblFinalAmount;
    private Button btnPlaceOrder;
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
        this.lblShippingAddress = new Label();
        this.txtShippingAddress = new TextBox();
        this.lblNotes = new Label();
        this.txtNotes = new TextBox();
        this.lblOrderTotal = new Label();
        this.lblFinalAmount = new Label();
        this.btnPlaceOrder = new Button();
        this.btnCancel = new Button();
        this.SuspendLayout();
        
        // lblTitle
        this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
        this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(34, 139, 34);
        this.lblTitle.Location = new System.Drawing.Point(20, 20);
        this.lblTitle.Size = new System.Drawing.Size(400, 35);
        this.lblTitle.Text = "Checkout";
        
        // lblShippingAddress
        this.lblShippingAddress.AutoSize = true;
        this.lblShippingAddress.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.lblShippingAddress.Location = new System.Drawing.Point(20, 70);
        this.lblShippingAddress.Text = "Shipping Address:*";
        
        // txtShippingAddress
        this.txtShippingAddress.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.txtShippingAddress.Location = new System.Drawing.Point(20, 95);
        this.txtShippingAddress.Multiline = true;
        this.txtShippingAddress.Size = new System.Drawing.Size(460, 80);
        
        // lblNotes
        this.lblNotes.AutoSize = true;
        this.lblNotes.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.lblNotes.Location = new System.Drawing.Point(20, 190);
        this.lblNotes.Text = "Order Notes (Optional):";
        
        // txtNotes
        this.txtNotes.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.txtNotes.Location = new System.Drawing.Point(20, 215);
        this.txtNotes.Multiline = true;
        this.txtNotes.Size = new System.Drawing.Size(460, 80);
        
        // lblOrderTotal
        this.lblOrderTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
        this.lblOrderTotal.Location = new System.Drawing.Point(20, 320);
        this.lblOrderTotal.Size = new System.Drawing.Size(460, 25);
        this.lblOrderTotal.Text = "Order Total: $0.00";
        this.lblOrderTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        
        // lblFinalAmount
        this.lblFinalAmount.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
        this.lblFinalAmount.ForeColor = System.Drawing.Color.FromArgb(34, 139, 34);
        this.lblFinalAmount.Location = new System.Drawing.Point(20, 350);
        this.lblFinalAmount.Size = new System.Drawing.Size(460, 30);
        this.lblFinalAmount.Text = "Final Amount: $0.00";
        this.lblFinalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        
        // btnPlaceOrder
        this.btnPlaceOrder.BackColor = System.Drawing.Color.FromArgb(34, 139, 34);
        this.btnPlaceOrder.FlatStyle = FlatStyle.Flat;
        this.btnPlaceOrder.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
        this.btnPlaceOrder.ForeColor = System.Drawing.Color.White;
        this.btnPlaceOrder.Location = new System.Drawing.Point(20, 400);
        this.btnPlaceOrder.Size = new System.Drawing.Size(225, 45);
        this.btnPlaceOrder.Text = "Place Order";
        this.btnPlaceOrder.Click += new EventHandler(this.btnPlaceOrder_Click);
        
        // btnCancel
        this.btnCancel.BackColor = System.Drawing.Color.Gray;
        this.btnCancel.FlatStyle = FlatStyle.Flat;
        this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 12F);
        this.btnCancel.ForeColor = System.Drawing.Color.White;
        this.btnCancel.Location = new System.Drawing.Point(255, 400);
        this.btnCancel.Size = new System.Drawing.Size(225, 45);
        this.btnCancel.Text = "Cancel";
        this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
        
        // CheckoutForm
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.FromArgb(240, 255, 240);
        this.ClientSize = new System.Drawing.Size(500, 470);
        this.Controls.Add(this.lblTitle);
        this.Controls.Add(this.lblShippingAddress);
        this.Controls.Add(this.txtShippingAddress);
        this.Controls.Add(this.lblNotes);
        this.Controls.Add(this.txtNotes);
        this.Controls.Add(this.lblOrderTotal);
        this.Controls.Add(this.lblFinalAmount);
        this.Controls.Add(this.btnPlaceOrder);
        this.Controls.Add(this.btnCancel);
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "CheckoutForm";
        this.StartPosition = FormStartPosition.CenterParent;
        this.Text = "Checkout - GreenLife";
        this.Load += new EventHandler(this.CheckoutForm_Load);
        this.ResumeLayout(false);
        this.PerformLayout();
    }
}
