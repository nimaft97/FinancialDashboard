﻿using FinancialDashboard.Models;
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

        private void AddRecord(object sender, RoutedEventArgs e)
        {
            // retrieve inputs from UI
            decimal value;
            if (!decimal.TryParse(ValueInput.Text, out value))
            {
                ResultOutput.Text = "Invalid value. Please enter a valid number";
                return;
            }

            string description = DescriptionInput.Text;
            Category selectedCategory = (Category)CategoryDropdown.SelectedItem;
            DateTime date = DateInput.SelectedDate ?? DateTime.Now;

            string result = _queryService.AddRecord(value, description, selectedCategory, date);

            ResultOutput.Text = result;
        }

        private void ExecuteQuery(object sender, RoutedEventArgs e)
        {
            string sqlQuery = QueryInput.Text;
            string result = _queryService.ExecuteSql(sqlQuery);

            ResultOutput.Text = result;
        }
    }
}
