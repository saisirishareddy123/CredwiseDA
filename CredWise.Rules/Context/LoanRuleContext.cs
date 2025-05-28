using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CredWise.Models.Root;
using CredWise.Rules.Interface;
using System.Collections.Generic;

namespace CredWise.Rules.Context
{
    public class LoanRuleContext
    {
        private readonly List<ILoanRule> _rules;

        public LoanRuleContext(List<ILoanRule> rules)
        {
            _rules = rules;
        }

        public LoanDecisionResponse Evaluate(LoanApplicationRequest request, List<BankTransaction> statements)
        {
            foreach (var rule in _rules)
            {
                var result = rule.Evaluate(request, statements);
                if (result != null && result.Status == "Rejected")
                    return result;

                if (result != null && result.Status == "Partially Approved")
                    return result;
            }

            return new LoanDecisionResponse
            {
                Status = "Approved",
                Message = "All checks passed, loan approved.",
                ApprovedAmount = request.RequestedAmount
            };
        }

        public LoanDecisionResponse Evaluate(LoanApplicationRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
