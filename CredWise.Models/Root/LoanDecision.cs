using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CredWise.Models
{
    public class LoanDecision
    {
        public string Status { get; set; } // Approved / Rejected / PartiallyApproved
        public decimal ApprovedAmount { get; set; }
        public string Message { get; set; }
    }
}

