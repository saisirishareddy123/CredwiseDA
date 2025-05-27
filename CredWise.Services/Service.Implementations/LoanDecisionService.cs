using CredWise.Models;
using CredWise.Services.Interface;
using CredWise.Rules.Context;
using CredWise.Rules.Interface;
using CredWise.Models.Root;

namespace CredWise.Services.Service.Implementations
{
    public class LoanDecisionService : ILoanDecisionService
    {
        private readonly IEnumerable<ILoanRule> _rules;

        public LoanDecisionService(IEnumerable<ILoanRule> rules)
        {
            _rules = rules; 
        }

        public LoanDecisionResponse EvaluateLoan(LoanApplicationRequest request)
        {
            var context = new LoanRuleContext(request);

            foreach (var rule in _rules)
            {
                rule.Evaluate(context);
                if (!context.IsApproved) break;
            }

            return new LoanDecisionResponse
            {
                IsApproved = context.IsApproved,
                ApprovedAmount = context.IsApproved ? request.RequestedAmount : 0,
                RejectionReason = context.RejectionReason,
                CriteriaResults = context.CriteriaResults
            };
        }
    }
}
