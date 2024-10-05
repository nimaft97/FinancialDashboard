using FinancialDashboard.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialDashboard.Services
{
    public class QueryService
    {
        private AppDbContext _context;

        public QueryService()
        {
            // initialize the database context
            _context = new AppDbContext();
            _context.Database.EnsureCreated();
        }

        public string AddRecord(decimal value, string description, Category category, DateTime date)
        {
            var transaction = new Transaction
            {
                Value = value,
                Description = description,
                Category = category,
                Date = date
            };

            // update db context
            _context.Transactions.Add(transaction);
            _context.SaveChanges();

            return $"Record added: value {value}, description {description}, category {category}, date {date.ToShortDateString()}";
        }

        public string ExecuteSql(string sql)
        {
            try
            {
                var result = _context.Transactions.FromSqlRaw(sql).ToList();
                return result.Count > 0 ? string.Join("\n", result.Select(r => $"{r.TransactionID}: {r.Description} - {r.Value}")) : "No records found.";
            }
            catch(Exception ex)
            {
                return $"Error executing query: {ex.Message}";
            }
        }
    }
}
