using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CredWise.Models.Root
{
    public class LoanProduct
    {
        public int LoanProductId { get; set; }
        public string Title { get; set; }
        public decimal MaxLoanAmount { get; set; }
    }
}
