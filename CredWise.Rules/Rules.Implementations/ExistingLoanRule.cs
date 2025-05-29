using CredWise.Models.Root;
using CredWise.Rules.Interface;
using CredWise.Models;

namespace CredWise.Rules.Rules.Implementations
{
    public class ExistingLoanRule : ILoanRule
    {
        public LoanDecisionResponse Evaluate(LoanApplicationRequest request, List<Models.BankTransaction> bankStatements)
        {
            if (request.ExistingLoan != null && request.ExistingLoan.IsActive)
            {
                return new LoanDecisionResponse
                {
                    Status = "Rejected",
                    Message = "Customer already has an existing loan."
                };
            }

            return new LoanDecisionResponse
            {
                Status = "Approved",
                Message = "No existing loan found."
            };
        }
    }
}
