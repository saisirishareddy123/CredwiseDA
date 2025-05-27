using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CredWise.Models.Root
{
    public class LoanDecisionResponse
    {
        public bool IsApproved { get; set; }
        public decimal ApprovedAmount { get; set; }
        public string? RejectionReason { get; set; } // Changed to nullable
        public List<string> CriteriaResults { get; set; } = new();
        public string Status => IsApproved ? "APPROVED" : "REJECTED";
    }
}
