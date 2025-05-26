using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CredWise.Rules.Context;
using CredWise.Rules.Interface;

//namespace CredWise.Rules.Interface
namespace CredWise.API.Rules
{
    public class MinimumSalaryRule : ILoanRule
    {
        private const decimal MinSalary = 30000;

        public void Evaluate(LoanRuleContext context)
        {
            var salary = context.Request.BankStatements
                .Where(t => t.Type == "Credit" && t.Description.Contains("Salary"))
                .Sum(t => t.Amount);

            if (salary < MinSalary)
            {
                context.IsApproved = false;
                context.RejectionReason = $"Salary ({salary}) is below minimum required ({MinSalary})";
            }
            context.CriteriaResults.Add($"Salary Check: {(salary >= MinSalary ? "Passed" : "Failed")}");
        }
    }
}
