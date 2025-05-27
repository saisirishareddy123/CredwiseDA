using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CredWise.Models.Root;

namespace CredWise.Rules.Context
{
    // This class holds the shared data between rules during evaluation
    public class LoanRuleContext
    {
        public LoanApplicationRequest Request { get; }
        public bool IsApproved { get; set; } = true;
        public decimal MaxEligibleAmount { get; set; }
        public string? RejectionReason { get; set; } // Changed to nullable
        public List<string> CriteriaResults { get; } = new();

        public LoanRuleContext(LoanApplicationRequest request)
        {
            Request = request;
        }
    }
}
