using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CredWise.Models.Root
{

    public class BankTransaction
    {
        public DateTime Date { get; set; }
        public string Type { get; set; } // CREDIT or DEBIT
        public decimal Amount { get; set; }
    }
}
