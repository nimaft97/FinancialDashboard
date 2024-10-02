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
    }
}
