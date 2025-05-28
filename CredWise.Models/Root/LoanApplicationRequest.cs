using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CredWise.Models.Root
{
    public class LoanApplicationRequest
    {
        public string UserId { get; set; }
        public decimal RequestedAmount { get; set; }
        public int LoanProductId { get; set; }
        public ExistingLoan ExistingLoan { get; set; }
    }
}
