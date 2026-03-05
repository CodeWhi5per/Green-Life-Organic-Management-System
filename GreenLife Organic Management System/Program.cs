using GreenLife_Organic_Management_System.Data;
using GreenLife_Organic_Management_System.Forms;

namespace GreenLife_Organic_Management_System;

static class Program
{
    [STAThread]
    static void Main()
    {

        ApplicationConfiguration.Initialize();
        
        try
        {
            DatabaseContext.InitializeDatabase();
            
            Application.Run(new LoginForm());
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Failed to initialize application: {ex.Message}", 
                "Startup Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

