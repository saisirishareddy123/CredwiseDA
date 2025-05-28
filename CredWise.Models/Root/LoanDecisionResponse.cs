using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CredWise.Models.Root
{
    public class LoanDecisionResponse
    {
        public string Status { get; set; } // Approved, Rejected, Partially Approved
        public string Message { get; set; }
        public decimal? ApprovedAmount { get; set; }
    }
}
