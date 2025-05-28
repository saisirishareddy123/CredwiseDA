using CredWise.Models;
using CredWise.Models.Root;
using System.Collections.Generic;
using CredWise.Models.Root;

namespace CredWise.Services.Interface
{
    public interface ILoanDecisionService
    {
        LoanDecisionResponse EvaluateLoan(LoanApplicationRequest request);
        List<BankTransaction> GetBankStatement(string userId);

        void UploadBankStatement(string userId, List<BankTransaction> transactions);
    }
}
