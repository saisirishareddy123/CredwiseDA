using CredWise.Models;
using CredWise.Models.Root;
using System.Collections.Generic;
using CredWise.Models.Root;
using CredWise.Models;
using System.Threading.Tasks;

namespace CredWise.Services.Interface
{
    public interface ILoanDecisionService
    {
        Task<LoanDecision> ProcessLoanRequest(LoanRequest request);
    }
}
