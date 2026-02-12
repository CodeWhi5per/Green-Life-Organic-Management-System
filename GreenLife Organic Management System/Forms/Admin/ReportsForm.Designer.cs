namespace GreenLife_Organic_Management_System.Forms.Admin;

partial class ReportsForm
{
    private System.ComponentModel.IContainer components = null;
    private DataGridView dgvReport;
    private DateTimePicker dtpStartDate;
    private DateTimePicker dtpEndDate;
    private Button btnGenerateSalesReport;
    private Button btnGenerateStockReport;
    private Button btnExportExcel;
    private Button btnClose;
    private TextBox txtReportSummary;
    private Label lblStartDate;
    private Label lblEndDate;
    
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
        this.dgvReport = new DataGridView();
        this.dtpStartDate = new DateTimePicker();
        this.dtpEndDate = new DateTimePicker();
        this.btnGenerateSalesReport = new Button();
        this.btnGenerateStockReport = new Button();
        this.btnExportExcel = new Button();
        this.btnClose = new Button();
        this.txtReportSummary = new TextBox();
        this.lblStartDate = new Label();
        this.lblEndDate = new Label();
        ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
        this.SuspendLayout();
        
        // lblStartDate
        this.lblStartDate.AutoSize = true;
        this.lblStartDate.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.lblStartDate.Location = new System.Drawing.Point(20, 20);
        this.lblStartDate.Text = "Start Date:";
        
        // dtpStartDate
        this.dtpStartDate.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.dtpStartDate.Location = new System.Drawing.Point(20, 45);
        this.dtpStartDate.Size = new System.Drawing.Size(200, 25);
        
        // lblEndDate
        this.lblEndDate.AutoSize = true;
        this.lblEndDate.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.lblEndDate.Location = new System.Drawing.Point(240, 20);
        this.lblEndDate.Text = "End Date:";
        
        // dtpEndDate
        this.dtpEndDate.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.dtpEndDate.Location = new System.Drawing.Point(240, 45);
        this.dtpEndDate.Size = new System.Drawing.Size(200, 25);
        
        // btnGenerateSalesReport
        this.btnGenerateSalesReport.BackColor = System.Drawing.Color.FromArgb(34, 139, 34);
        this.btnGenerateSalesReport.FlatStyle = FlatStyle.Flat;
        this.btnGenerateSalesReport.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.btnGenerateSalesReport.ForeColor = System.Drawing.Color.White;
        this.btnGenerateSalesReport.Location = new System.Drawing.Point(20, 90);
        this.btnGenerateSalesReport.Size = new System.Drawing.Size(200, 40);
        this.btnGenerateSalesReport.Text = "Generate Sales Report";
        this.btnGenerateSalesReport.Click += new EventHandler(this.btnGenerateSalesReport_Click);
        
        // btnGenerateStockReport
        this.btnGenerateStockReport.BackColor = System.Drawing.Color.FromArgb(70, 130, 180);
        this.btnGenerateStockReport.FlatStyle = FlatStyle.Flat;
        this.btnGenerateStockReport.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.btnGenerateStockReport.ForeColor = System.Drawing.Color.White;
        this.btnGenerateStockReport.Location = new System.Drawing.Point(240, 90);
        this.btnGenerateStockReport.Size = new System.Drawing.Size(200, 40);
        this.btnGenerateStockReport.Text = "Generate Stock Report";
        this.btnGenerateStockReport.Click += new EventHandler(this.btnGenerateStockReport_Click);
        
        // dgvReport
        this.dgvReport.AllowUserToAddRows = false;
        this.dgvReport.AllowUserToDeleteRows = false;
        this.dgvReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvReport.BackgroundColor = System.Drawing.Color.White;
        this.dgvReport.Location = new System.Drawing.Point(20, 150);
        this.dgvReport.ReadOnly = true;
        this.dgvReport.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        this.dgvReport.Size = new System.Drawing.Size(850, 350);
        
        // txtReportSummary
        this.txtReportSummary.BackColor = System.Drawing.Color.White;
        this.txtReportSummary.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.txtReportSummary.Location = new System.Drawing.Point(890, 150);
        this.txtReportSummary.Multiline = true;
        this.txtReportSummary.ReadOnly = true;
        this.txtReportSummary.Size = new System.Drawing.Size(250, 250);
        
        // btnExportExcel
        this.btnExportExcel.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
        this.btnExportExcel.FlatStyle = FlatStyle.Flat;
        this.btnExportExcel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.btnExportExcel.ForeColor = System.Drawing.Color.White;
        this.btnExportExcel.Location = new System.Drawing.Point(890, 420);
        this.btnExportExcel.Size = new System.Drawing.Size(250, 40);
        this.btnExportExcel.Text = "Export to Excel";
        this.btnExportExcel.Click += new EventHandler(this.btnExportExcel_Click);
        
        // btnClose
        this.btnClose.BackColor = System.Drawing.Color.Gray;
        this.btnClose.FlatStyle = FlatStyle.Flat;
        this.btnClose.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
        this.btnClose.ForeColor = System.Drawing.Color.White;
        this.btnClose.Location = new System.Drawing.Point(990, 520);
        this.btnClose.Size = new System.Drawing.Size(150, 40);
        this.btnClose.Text = "Close";
        this.btnClose.Click += new EventHandler(this.btnClose_Click);
        
        // ReportsForm
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.FromArgb(240, 255, 240);
        this.ClientSize = new System.Drawing.Size(1160, 580);
        this.Controls.Add(this.lblStartDate);
        this.Controls.Add(this.dtpStartDate);
        this.Controls.Add(this.lblEndDate);
        this.Controls.Add(this.dtpEndDate);
        this.Controls.Add(this.btnGenerateSalesReport);
        this.Controls.Add(this.btnGenerateStockReport);
        this.Controls.Add(this.dgvReport);
        this.Controls.Add(this.txtReportSummary);
        this.Controls.Add(this.btnExportExcel);
        this.Controls.Add(this.btnClose);
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.Name = "ReportsForm";
        this.StartPosition = FormStartPosition.CenterScreen;
        this.Text = "Reports - GreenLife";
        this.Load += new EventHandler(this.ReportsForm_Load);
        ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();
    }
}
