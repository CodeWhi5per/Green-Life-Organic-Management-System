using GreenLife_Organic_Management_System.Data;
using GreenLife_Organic_Management_System.Forms;

namespace GreenLife_Organic_Management_System;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        
        try
        {
            // Initialize database
            DatabaseContext.InitializeDatabase();
            
            // Start with login form
            Application.Run(new LoginForm());
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Failed to initialize application: {ex.Message}", 
                "Startup Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

