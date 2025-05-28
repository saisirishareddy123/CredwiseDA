using CredWise.Models.Root;
using CredWise.Rules.Context;
using CredWise.Rules.Interface;
using CredWise.Services.Interface;
using System.Collections.Concurrent;

namespace CredWise.Services.Service.Implementations
{
    public class LoanDecisionService : ILoanDecisionService
    {
        // ✅ Declare this at the class level
        private static readonly Dictionary<string, List<BankTransaction>> _userBankStatements = new();

        private readonly IEnumerable<ILoanRule> _rules;

        public LoanDecisionService(IEnumerable<ILoanRule> rules)
        {
            _rules = rules;
        }

        public void UploadBankStatement(string userId, List<BankTransaction> transactions)
        {
            if (_userBankStatements.ContainsKey(userId))
                _userBankStatements[userId] = transactions;
            else
                _userBankStatements.Add(userId, transactions);
        }

        public List<BankTransaction> GetBankStatement(string userId)
        {
            return _userBankStatements.ContainsKey(userId) ? _userBankStatements[userId] : new List<BankTransaction>();
        }

        public LoanDecisionResponse EvaluateLoan(LoanApplicationRequest request)
        {
            var context = new LoanRuleContext(_rules.ToList());
            return context.Evaluate(request);
        }
    }
}
