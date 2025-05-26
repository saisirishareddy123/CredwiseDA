using CredWise.Models;
using CredWise.Models.Root;

namespace CredWise.Services.Interface
{
    public interface ILoanDecisionService
    {
        LoanDecisionResponse EvaluateLoan(LoanApplicationRequest request);
    }
}
