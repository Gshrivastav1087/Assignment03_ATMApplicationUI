using System;
using System.Windows;

namespace ATMApplication_WPF.UI
{
    public partial class AccountPage : Window
    {
        private IBankAccountOperations account;

        public AccountPage(IBankAccountOperations account)
        {
            InitializeComponent();
            this.account = account;
            this.Title = $"Welcome, {account.AccountHolderName}";
        }

        private void DepositButton_Click(object sender, RoutedEventArgs e)
        {
            // Deposit Logic
            double depositAmount = 0;
            string input = Microsoft.VisualBasic.Interaction.InputBox("Enter Deposit Amount:", "Deposit", "0");

            // Validate input
            if (double.TryParse(input, out depositAmount))
            {
                // Ensure the deposit amount is positive
                if (depositAmount <= 0)
                {
                    MessageBox.Show("Deposit amount must be greater than zero.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                account.DepositMoney(depositAmount);
                MessageBox.Show($"Deposited {depositAmount:C}", "Deposit", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Invalid amount entered. Please enter a valid decimal number.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void WithdrawButton_Click(object sender, RoutedEventArgs e)
        {
            // Withdraw Logic
            double withdrawAmount = 0;
            string input = Microsoft.VisualBasic.Interaction.InputBox("Enter Withdrawal Amount:", "Withdraw", "0");

            // Validate input
            if (double.TryParse(input, out withdrawAmount))
            {
                // Ensure the withdraw amount is positive and not more than the available balance
                if (withdrawAmount <= 0)
                {
                    MessageBox.Show("Withdrawal amount must be greater than zero.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (withdrawAmount > account.Balance)
                {
                    MessageBox.Show("Insufficient funds. Please enter a valid withdrawal amount.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                account.WithdrawMoney(withdrawAmount);
                MessageBox.Show($"Withdrew {withdrawAmount:C}", "Withdraw", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Invalid amount entered. Please enter a valid decimal number.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        /*        private void StatementButton_Click(object sender, RoutedEventArgs e)
                {
                    // Display Account Statement
                    BankStatement.DisplayStatement(account);
                }*/

        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {
            // Log Out Logic
            MessageBox.Show("Logged out successfully.", "Logout", MessageBoxButton.OK, MessageBoxImage.Information);
            LoginPage loginPage = new LoginPage(new BankAccountManager());  // Initialize with your BankAccountManager instance
            loginPage.Show();
            this.Close();  // Close the current page
        }

        private void StatementButton_Click(object sender, RoutedEventArgs e)
        {
            // Fetch the statement details
            var statement = GenerateStatement();

            // Display the statement in the StatementTextBox
            StatementTextBox.Text = statement;
        }

        /// <summary>
        /// Generates the bank statement for the account.
        /// </summary>
        /// <returns>A formatted string representing the bank statement.</returns>
        private string GenerateStatement()
        {
            // Build the statement details
            var statementBuilder = new System.Text.StringBuilder();

            statementBuilder.AppendLine("*** Bank Statement ***");
            statementBuilder.AppendLine($"Account Holder: {account.AccountHolderName}");
            statementBuilder.AppendLine($"Account Number: {account.AccountNumber}");
            statementBuilder.AppendLine($"Balance: {account.Balance:C}");
            statementBuilder.AppendLine($"Interest Rate: {account.InterestRate * 100}%");  // Ensure interest rate is being fetched correctly
            statementBuilder.AppendLine("Transaction History:");

            foreach (var transaction in account.GetTransactionHistory())
            {
                statementBuilder.AppendLine(transaction);
            }

            // Show the interest applied to the balance
            double interestApplied = account.Balance * account.InterestRate;
            statementBuilder.AppendLine($"Interest Applied: {interestApplied:C}");

            return statementBuilder.ToString();
        }
    }
}
