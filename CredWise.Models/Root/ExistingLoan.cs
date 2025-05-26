using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CredWise.Models.Root
{
    public class ExistingLoan
    {
        public string LoanId { get; set; }
        public decimal MonthlyEmi { get; set; }
        public bool IsActive { get; set; }
    }
}
