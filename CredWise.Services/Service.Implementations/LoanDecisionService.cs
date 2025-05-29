using CredWise.Models.Root;
using CredWise.Rules.Context;
using CredWise.Rules.Interface;
using CredWise.Services.Interface;
using System.Collections.Concurrent;
using CredWise.Models;
//using CredWise.Services.Interface;
using System.Threading.Tasks;

namespace CredWise.Services
{
    public class LoanDecisionService : ILoanDecisionService
    {
        public async Task<LoanDecision> ProcessLoanRequest(LoanRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.CustomerId))
            {
                return new LoanDecision
                {
                    Status = "Rejected",
                    ApprovedAmount = 0,
                    Message = "Invalid loan request"
                };
            }

            // Simple rules example (replace with your rule logic)
            if (request.RequestedAmount < 10000)
            {
                return new LoanDecision
                {
                    Status = "Approved",
                    ApprovedAmount = request.RequestedAmount,
                    Message = "Loan approved"
                };
            }
            else
            {
                return new LoanDecision
                {
                    Status = "PartiallyApproved",
                    ApprovedAmount = 10000,
                    Message = "Loan partially approved"
                };
            }
        }
    }
}
