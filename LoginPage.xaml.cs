using System;
using System.Windows;

namespace ATMApplication_WPF.UI
{
    public partial class LoginPage : Window
    {
        private BankAccountManager bankManager;

        public LoginPage(BankAccountManager bankManager)
        {
            InitializeComponent();
            this.bankManager = bankManager;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(AccountNumberTextBox.Text, out int accountNumber))
            {
                MessageBox.Show("Invalid Account Number!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var account = bankManager.RetrieveAccount(accountNumber);
            if (account == null)
            {
                MessageBox.Show("Account not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            AccountPage accountPage = new AccountPage(account);
            accountPage.Show();
            this.Close();
        }
    }
}
