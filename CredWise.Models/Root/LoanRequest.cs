using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CredWise.Models
{
    public class LoanRequest
    {
        public string LoanApplicationId { get; set; }
        public string CustomerId { get; set; }
        public string LoanType { get; set; } // Home, Personal, Gold
        public decimal RequestedAmount { get; set; }
    }
}

