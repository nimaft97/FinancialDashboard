using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialDashboard.Models
{
    public enum Category
    {
        Restaurant = 0,
        Grocery,
        Accommodation,
        Entertainment,
        Transportation,
        Utilities,
        Other
    }
    public class Transaction
    {
        public int TransactionID { get; set; }
        public decimal Value { get; set; }
        public Category Category { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
