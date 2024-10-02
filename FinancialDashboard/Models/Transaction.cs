using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialDashboard.Models
{
    public enum Category
    {
        Food = 0,
        Accommodation,
        Entertainment,
        Transportation,
        Utilities,
        Other
    }
    public class Transaction
    {
        public int TransactionID { get; set; }
        public decimal Amout { get; set; }
        public Category Category { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
