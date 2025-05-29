using CredWise.Models;
using CredWise.Models.Root;
using CredWise.Rules.Context;
using CredWise.Rules.Interface;

namespace CredWise.Rules.Rules.Implementations
{
    public class LoanAmountRule : ILoanRule
    {
        private readonly Dictionary<int, decimal> _loanProducts = new()
        {
            { 1, 5000000 }, // Home
            { 2, 1000000 }, // Personal
            { 3, 2000000 }  // Gold
        };

        public LoanDecisionResponse Evaluate(LoanApplicationRequest request, List<Models.BankTransaction> bankStatements)
        {
            if (!_loanProducts.ContainsKey(request.LoanProductId))
            {
                return new LoanDecisionResponse
                {
                    Status = "Rejected",
                    Message = "Invalid Loan Product ID"
                };
            }

            decimal maxLoan = _loanProducts[request.LoanProductId];
            decimal requested = request.RequestedAmount;

            // Assume EMI is 2% of loan per month (approximate)
            decimal expectedEMI = requested * 0.02m;

            // Calculate average credit over past 6 months
            var last6MonthsCredit = bankStatements
                .Where(tx => tx.Type == "CREDIT" && tx.Date >= DateTime.Now.AddMonths(-6))
                .GroupBy(tx => tx.Date.Month)
                .Select(g => g.Sum(t => t.Amount))
                .ToList();

            decimal avgMonthlyIncome = (decimal)(last6MonthsCredit.Count != 0 ? last6MonthsCredit.Average() : 0);

            if (avgMonthlyIncome >= expectedEMI)
            {
                return new LoanDecisionResponse
                {
                    Status = "Approved",
                    Message = "Loan fully approved.",
                    ApprovedAmount = requested
                };
            }
            else if (avgMonthlyIncome >= (expectedEMI * 0.5m))
            {
                decimal partialAmount = avgMonthlyIncome / 0.02m;
                return new LoanDecisionResponse
                {
                    Status = "Partially Approved",
                    Message = $"Income supports a lower amount. Approved partial loan.",
                    ApprovedAmount = Math.Round(partialAmount, 2)
                };
            }

            return new LoanDecisionResponse
            {
                Status = "Rejected",
                Message = "Income too low to support any loan."
            };
        }

        //public LoanDecisionResponse Evaluate(LoanApplicationRequest request, List<Models.Root.BankTransaction> statements)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
