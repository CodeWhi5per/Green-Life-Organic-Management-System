using OfficeOpenXml;
using GreenLife_Organic_Management_System.Models;

namespace GreenLife_Organic_Management_System.Utilities;

public static class ExportHelper
{
    public static void ExportOrdersToExcel(List<Order> orders, string filePath)
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        
        using var package = new ExcelPackage();
        var worksheet = package.Workbook.Worksheets.Add("Orders");
        
        // Headers
        worksheet.Cells[1, 1].Value = "Order ID";
        worksheet.Cells[1, 2].Value = "Customer";
        worksheet.Cells[1, 3].Value = "Order Date";
        worksheet.Cells[1, 4].Value = "Status";
        worksheet.Cells[1, 5].Value = "Total Amount";
        worksheet.Cells[1, 6].Value = "Final Amount";
        
        // Style headers
        using (var range = worksheet.Cells[1, 1, 1, 6])
        {
            range.Style.Font.Bold = true;
            range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
        }
        
        // Data
        for (int i = 0; i < orders.Count; i++)
        {
            var order = orders[i];
            worksheet.Cells[i + 2, 1].Value = order.OrderId;
            worksheet.Cells[i + 2, 2].Value = order.CustomerName;
            worksheet.Cells[i + 2, 3].Value = order.OrderDate.ToString("yyyy-MM-dd HH:mm");
            worksheet.Cells[i + 2, 4].Value = order.Status.ToString();
            worksheet.Cells[i + 2, 5].Value = order.TotalAmount;
            worksheet.Cells[i + 2, 6].Value = order.FinalAmount;
        }
        
        worksheet.Cells.AutoFitColumns();
        
        var file = new FileInfo(filePath);
        package.SaveAs(file);
    }
    
    public static void ExportProductsToExcel(List<Product> products, string filePath)
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        
        using var package = new ExcelPackage();
        var worksheet = package.Workbook.Worksheets.Add("Products");
        
        // Headers
        worksheet.Cells[1, 1].Value = "Product ID";
        worksheet.Cells[1, 2].Value = "Name";
        worksheet.Cells[1, 3].Value = "Category";
        worksheet.Cells[1, 4].Value = "Price";
        worksheet.Cells[1, 5].Value = "Stock";
        worksheet.Cells[1, 6].Value = "Supplier";
        
        // Style headers
        using (var range = worksheet.Cells[1, 1, 1, 6])
        {
            range.Style.Font.Bold = true;
            range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
        }
        
        // Data
        for (int i = 0; i < products.Count; i++)
        {
            var product = products[i];
            worksheet.Cells[i + 2, 1].Value = product.ProductId;
            worksheet.Cells[i + 2, 2].Value = product.Name;
            worksheet.Cells[i + 2, 3].Value = product.Category;
            worksheet.Cells[i + 2, 4].Value = product.Price;
            worksheet.Cells[i + 2, 5].Value = product.StockQuantity;
            worksheet.Cells[i + 2, 6].Value = product.Supplier;
        }
        
        worksheet.Cells.AutoFitColumns();
        
        var file = new FileInfo(filePath);
        package.SaveAs(file);
    }
}
