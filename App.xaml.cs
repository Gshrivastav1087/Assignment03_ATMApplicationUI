using System;
using System.Windows;
using ATMApplication_WPF.UI;

namespace ATMApplication_WPF
{
    public partial class App : Application
    {
        // Override OnStartup to handle application startup
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            try
            {
                // Initialize the bank manager
                var bankManager = new BankAccountManager();

                // Pass the bank manager to the LoginPage constructor
                var loginPage = new LoginPage(bankManager);

                // Show the login page
                loginPage.Show();
            }
            catch (Exception ex)
            {
                // Log or display the error message
                MessageBox.Show($"An error occurred during application startup: {ex.Message}",
                                "Startup Error", MessageBoxButton.OK, MessageBoxImage.Error);

                // Shut down the application if startup fails
                Shutdown();
            }
        }
    }
}
