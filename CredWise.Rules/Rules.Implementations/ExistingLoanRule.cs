using CredWise.Models.Root;
using CredWise.Rules.Interface;

namespace CredWise.Rules.Rules.Implementations
{
    public class ExistingLoanRule : ILoanRule
    {
        public LoanDecisionResponse Evaluate(LoanApplicationRequest request, List<BankTransaction> bankStatements)
        {
            if (request.ExistingLoan != null && request.ExistingLoan.IsActive)
            {
                return new LoanDecisionResponse
                {
                    Status = "Rejected",
                    Message = "Customer already has an existing loan."
                };
            }

            return null;
        }
    }
}
