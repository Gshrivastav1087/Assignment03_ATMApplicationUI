using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ATMApplication_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IBankAccountManager bank;

        public MainWindow()
        {
            InitializeComponent();
            bank = new BankAccountManager();

            // Run the ATM logic in a separate thread to avoid blocking the UI thread
            Task.Run(() =>
            {
                TransactionsManager atmApp = new TransactionsManager(bank);
                atmApp.Start();
            });
        }
    }
}