using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CredWise.Models.Root
{
    public class LoanApplicationRequest
    {
        public string UserId { get; set; }
        public decimal RequestedAmount { get; set; }
        public List<BankTransaction> BankStatements { get; set; } = new();
        public List<ExistingLoan> ExistingLoans { get; set; } = new();
    }
}
