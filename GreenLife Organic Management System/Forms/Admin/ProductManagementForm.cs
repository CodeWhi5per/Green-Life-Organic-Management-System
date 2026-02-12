using GreenLife_Organic_Management_System.Data.Repositories;
using GreenLife_Organic_Management_System.Models;
using GreenLife_Organic_Management_System.Utilities;

namespace GreenLife_Organic_Management_System.Forms.Admin;

public partial class ProductManagementForm : Form
{
    private readonly ProductRepository _productRepository;
    private Product? _selectedProduct;
    
    public ProductManagementForm()
    {
        InitializeComponent();
        _productRepository = new ProductRepository();
    }
    
    private void ProductManagementForm_Load(object sender, EventArgs e)
    {
        LoadProducts();
        LoadCategories();
    }
    
    private void LoadProducts()
    {
        try
        {
            var products = _productRepository.GetAllProducts(true);
            dgvProducts.DataSource = products;
            
            // Format columns
            if (dgvProducts.Columns.Count > 0)
            {
                dgvProducts.Columns["ProductId"].HeaderText = "ID";
                dgvProducts.Columns["ProductId"].Width = 50;
                dgvProducts.Columns["Name"].Width = 150;
                dgvProducts.Columns["Category"].Width = 100;
                dgvProducts.Columns["Price"].DefaultCellStyle.Format = "C2";
                dgvProducts.Columns["StockQuantity"].HeaderText = "Stock";
                dgvProducts.Columns["Supplier"].Width = 120;
                dgvProducts.Columns["DiscountPercentage"].HeaderText = "Discount %";
                dgvProducts.Columns["DiscountPercentage"].DefaultCellStyle.Format = "N2";
                dgvProducts.Columns["DiscountedPrice"].HeaderText = "Final Price";
                dgvProducts.Columns["DiscountedPrice"].DefaultCellStyle.Format = "C2";
                dgvProducts.Columns["Description"].Visible = false;
                dgvProducts.Columns["CreatedAt"].Visible = false;
                dgvProducts.Columns["LastUpdated"].Visible = false;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading products: {ex.Message}", "Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    
    private void LoadCategories()
    {
        var categories = _productRepository.GetCategories();
        cmbCategory.Items.Clear();
        cmbCategory.Items.Add("All Categories");
        foreach (var category in categories)
        {
            cmbCategory.Items.Add(category);
        }
        cmbCategory.SelectedIndex = 0;
    }
    
    private void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            var searchTerm = txtSearch.Text.Trim();
            var category = cmbCategory.SelectedIndex > 0 ? cmbCategory.SelectedItem?.ToString() : null;
            
            var products = _productRepository.SearchProducts(searchTerm, category);
            dgvProducts.DataSource = products;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error searching products: {ex.Message}", "Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    
    private void btnAdd_Click(object sender, EventArgs e)
    {
        ClearFields();
        _selectedProduct = null;
        EnableFields(true);
        txtName.Focus();
    }
    
    private void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (!ValidateInputs())
                return;
            
            var product = new Product
            {
                Name = txtName.Text.Trim(),
                Category = txtCategory.Text.Trim(),
                Description = txtDescription.Text.Trim(),
                Price = decimal.Parse(txtPrice.Text),
                StockQuantity = int.Parse(txtStock.Text),
                Supplier = txtSupplier.Text.Trim(),
                DiscountPercentage = string.IsNullOrWhiteSpace(txtDiscount.Text) ? null : decimal.Parse(txtDiscount.Text),
                IsActive = chkActive.Checked
            };
            
            bool success;
            if (_selectedProduct == null)
            {
                success = _productRepository.CreateProduct(product);
                MessageBox.Show(success ? "Product added successfully!" : "Failed to add product.", 
                    success ? "Success" : "Error", MessageBoxButtons.OK, 
                    success ? MessageBoxIcon.Information : MessageBoxIcon.Error);
            }
            else
            {
                product.ProductId = _selectedProduct.ProductId;
                success = _productRepository.UpdateProduct(product);
                MessageBox.Show(success ? "Product updated successfully!" : "Failed to update product.", 
                    success ? "Success" : "Error", MessageBoxButtons.OK, 
                    success ? MessageBoxIcon.Information : MessageBoxIcon.Error);
            }
            
            if (success)
            {
                LoadProducts();
                LoadCategories();
                ClearFields();
                EnableFields(false);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error saving product: {ex.Message}", "Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    
    private void btnEdit_Click(object sender, EventArgs e)
    {
        if (dgvProducts.CurrentRow != null)
        {
            _selectedProduct = (Product)dgvProducts.CurrentRow.DataBoundItem;
            LoadProductToFields(_selectedProduct);
            EnableFields(true);
        }
        else
        {
            MessageBox.Show("Please select a product to edit.", "No Selection", 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
    
    private void btnDelete_Click(object sender, EventArgs e)
    {
        if (dgvProducts.CurrentRow == null)
        {
            MessageBox.Show("Please select a product to delete.", "No Selection", 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        
        var result = MessageBox.Show("Are you sure you want to delete this product?", "Confirm Delete", 
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        
        if (result == DialogResult.Yes)
        {
            var product = (Product)dgvProducts.CurrentRow.DataBoundItem;
            if (_productRepository.DeleteProduct(product.ProductId))
            {
                MessageBox.Show("Product deleted successfully!", "Success", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadProducts();
                ClearFields();
            }
            else
            {
                MessageBox.Show("Failed to delete product.", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    
    private bool ValidateInputs()
    {
        if (!Validator.IsNotEmpty(txtName.Text))
        {
            MessageBox.Show("Product name is required.", "Validation Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
        
        if (!Validator.IsNotEmpty(txtCategory.Text))
        {
            MessageBox.Show("Category is required.", "Validation Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
        
        if (!Validator.IsValidPrice(txtPrice.Text))
        {
            MessageBox.Show("Please enter a valid price.", "Validation Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
        
        if (!Validator.IsValidQuantity(txtStock.Text))
        {
            MessageBox.Show("Please enter a valid stock quantity.", "Validation Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
        
        if (!string.IsNullOrWhiteSpace(txtDiscount.Text) && !Validator.IsValidPrice(txtDiscount.Text))
        {
            MessageBox.Show("Please enter a valid discount percentage.", "Validation Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
        
        return true;
    }
    
    private void LoadProductToFields(Product product)
    {
        txtName.Text = product.Name;
        txtCategory.Text = product.Category;
        txtDescription.Text = product.Description;
        txtPrice.Text = product.Price.ToString("F2");
        txtStock.Text = product.StockQuantity.ToString();
        txtSupplier.Text = product.Supplier;
        txtDiscount.Text = product.DiscountPercentage?.ToString("F2") ?? "";
        chkActive.Checked = product.IsActive;
    }
    
    private void ClearFields()
    {
        txtName.Clear();
        txtCategory.Clear();
        txtDescription.Clear();
        txtPrice.Clear();
        txtStock.Clear();
        txtSupplier.Clear();
        txtDiscount.Clear();
        chkActive.Checked = true;
        _selectedProduct = null;
    }
    
    private void EnableFields(bool enabled)
    {
        txtName.Enabled = enabled;
        txtCategory.Enabled = enabled;
        txtDescription.Enabled = enabled;
        txtPrice.Enabled = enabled;
        txtStock.Enabled = enabled;
        txtSupplier.Enabled = enabled;
        txtDiscount.Enabled = enabled;
        chkActive.Enabled = enabled;
        btnSave.Enabled = enabled;
    }
    
    private void btnClose_Click(object sender, EventArgs e)
    {
        this.Close();
    }
}
