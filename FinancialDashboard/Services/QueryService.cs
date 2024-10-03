using FinancialDashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialDashboard.Services
{
    public class QueryService
    {
        public string ExecuteSql(string sql)
        {
            return $"Executing: {sql}";
        }

        public string AddRecord(float value, string description, Category category, DateTime date)
        {
            return $"Record added with Value: {value}, Description: '{description}', Category: {category}, Date: {date.ToShortDateString()}";
        }
    }
}
