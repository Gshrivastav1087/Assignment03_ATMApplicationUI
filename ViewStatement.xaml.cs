using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ATMApplication_WPF
{
    public partial class ViewStatementPage : Window
    {
        public ViewStatementPage(List<Transaction> transactions)
        {
            InitializeComponent();

            // Bind transactions to the DataGrid
            TransactionDataGrid.ItemsSource = transactions;
        }
    }
}
