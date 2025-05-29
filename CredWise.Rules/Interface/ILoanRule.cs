using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CredWise.Models.Root;
using CredWise.Rules.Context;
using CredWise.Models;
//using CredWise.Models.Root;

namespace CredWise.Rules.Interface
{
    public interface ILoanRule
    {
        LoanDecisionResponse Evaluate(LoanApplicationRequest request, List<Models.BankTransaction> bankStatements);
        //LoanDecisionResponse Evaluate(LoanApplicationRequest request, List<Models.Root.BankTransaction> statements);
    }
}