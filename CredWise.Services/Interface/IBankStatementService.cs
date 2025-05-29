using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CredWise.Models;

namespace CredWise.Services.Interface
{
    public interface IBankStatementService
    {
        Task<BankStatement> GetBankStatementAsync(string customerId, DateTime startDate, DateTime endDate);
    }
}