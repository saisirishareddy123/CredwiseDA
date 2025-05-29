using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CredWise.Models
{
    public class BankStatement
    {
        public string CustomerId { get; set; }
        public string LoanApplicationId { get; set; }
        public List<BankTransaction> Transactions { get; set; } = new List<BankTransaction>();
    }

    public class BankTransaction
    {
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; } // "Credit" or "Debit"
        public string Description { get; set; }
    }
}

