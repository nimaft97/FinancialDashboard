using FinancialDashboard.Models;
using Microsoft.EntityFrameworkCore;

namespace FinancialDashboard.Services
{
    internal class AppDbContext : DbContext
    {
        public DbSet<Transaction> Transactions { get; set; }
        public string _connectionString = "Data Source=FinancialDashboard.db";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configure SQLite connection string
            optionsBuilder.UseSqlite(_connectionString);
        }
    }
}
