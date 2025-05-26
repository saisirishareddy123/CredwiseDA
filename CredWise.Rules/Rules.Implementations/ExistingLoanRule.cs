using System.Linq;
using CredWise.Rules.Context;
using CredWise.Rules.Interface;

namespace CredWise.Rules.Rules.Implementations
{
    // This rule checks if user has existing loans
    public class ExistingLoanRule : ILoanRule
    {
        public void Evaluate(LoanRuleContext context)
        {
            // Count active loans
            var activeLoans = context.Request.ExistingLoans.Count(loan => loan.IsActive);

            // Reject if any active loans exist
            if (activeLoans >= 1)
            {
                context.IsApproved = false;
                context.RejectionReason = "User already has an active loan";
            }

            // Record the result
            context.CriteriaResults.Add(
                $"Active Loans Check: {(activeLoans == 0 ? "Passed" : "Failed")}"
            );
        }
    }
}
