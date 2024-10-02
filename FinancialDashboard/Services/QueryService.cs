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
        public string ExecuteSql(string sql, Category category)
        {
            return $"Executing: {sql} with category: {category}";
        }
    }
}
