using Microsoft.AspNetCore.Mvc;
using CredWise.Models;
using CredWise.Services.Interface;
using CredWise.Models.Root;
//using CredWise.Services.DummyData;
using System.Net;
using Microsoft.Extensions.Logging;
 
namespace CredWise.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoanDecisionController : ControllerBase
    {
        private readonly ILoanDecisionService _loanService;

        public LoanDecisionController(ILoanDecisionService loanService)
        {
            _loanService = loanService;
        }

        [HttpPost("bankstatement")]
        public IActionResult UploadBankStatement(string userId, [FromBody] List<BankTransaction> transactions)
        {
            _loanService.UploadBankStatement(userId, transactions);
            return Ok("Bank statement uploaded.");
        }

        [HttpGet("bankstatement/{userId}")]
        public IActionResult GetBankStatement(string userId)
        {
            var data = _loanService.GetBankStatement(userId);
            return data.Any() ? Ok(data) : NotFound("No statement found.");
        }

        [HttpPost("evaluate")]
        public IActionResult EvaluateLoan([FromBody] LoanApplicationRequest request)
        {
            var result = _loanService.EvaluateLoan(request);
            return Ok(result);
        }
    }
}
