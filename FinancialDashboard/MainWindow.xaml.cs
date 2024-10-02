using FinancialDashboard.Models;
using FinancialDashboard.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FinancialDashboard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private QueryService _queryService;
        public MainWindow()
        {
            InitializeComponent();
            _queryService = new QueryService();

            // bind values of Category to the WPF dropddown menu
            CategoryDropdown.ItemsSource = Enum.GetValues(typeof(Category));
        }

        private void SubmitQuery(object sender, RoutedEventArgs e)
        {
            // get the query from text box
            string sqlQuery = QueryInput.Text;
            Category selectedCategory = (Category)CategoryDropdown.SelectedItem;

            // execute the query and return the result
            string result = _queryService.ExecuteSql(sqlQuery, selectedCategory);

            // display the calculated result
            ResultOutput.Text = result;
        }

        private string ExecuteQuery(string sqlQuery)
        {
            return $"You submitted: {sqlQuery}";
        }
    }
}
