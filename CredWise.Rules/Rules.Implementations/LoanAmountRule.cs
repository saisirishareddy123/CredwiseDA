using CredWise.Models;
using CredWise.Rules.Context;
using CredWise.Rules.Interface;

namespace CredWise.Rules.Rules.Implementations
{
    public class LoanAmountRule : ILoanRule
    {
        public void Evaluate(LoanRuleContext context)
        {
            if (context.Request.RequestedAmount < 5000)
            {
                context.IsApproved = false;
                context.RejectionReason = "Minimum loan amount is ₹5,000";
            }

            context.CriteriaResults.Add(
                $"Amount Check: {(context.IsApproved ? "Passed" : "Failed")}"
            );
        }
    }
}
