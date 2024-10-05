using FinancialDashboard.Models;
using Microsoft.EntityFrameworkCore;

namespace FinancialDashboard.Services
{
    internal class AppDbContext : DbContext
    {
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configure SQLite connection string
            optionsBuilder.UseSqlite("Data Source=FinancialDashboard.db");
        }
    }
}
