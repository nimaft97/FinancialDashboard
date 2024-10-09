using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialDashboard.Services
{
    public class ExportService
    {
        private readonly QueryService _queryService;
        public ExportService(QueryService queryService)
        {
            _queryService = queryService;
        }

        public async Task ExportTransactionsToCsv(string filePath)
        {
            // Fetch all transactions from the database
            var transactions = await _queryService.GetAllTransactions();

            // Write data to the CSV file
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var transaction in transactions)
                {
                    writer.WriteLine($"{transaction.TransactionID},{transaction.Value},{transaction.Description},{transaction.Category},{transaction.Date}");
                }
            }
        }
    }
}
