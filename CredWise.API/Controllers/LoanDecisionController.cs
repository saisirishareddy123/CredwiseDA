using Microsoft.AspNetCore.Mvc;
using CredWise.Models;
using CredWise.Services.Interface;

namespace CredWise.API.Controllers
{
    [ApiController]
    [Route("api/loan")]
    public class LoanController : ControllerBase
    {
        private readonly ILoanDecisionService _loanDecisionService;
        private readonly IBankStatementService _bankStatementService;

        public LoanController(
            ILoanDecisionService loanDecisionService,
            IBankStatementService bankStatementService)
        {
            _loanDecisionService = loanDecisionService;
            _bankStatementService = bankStatementService;
        }

        [HttpGet("bank-statements/{customerId}")]
        public async Task<ActionResult<BankStatement>> GetBankStatements(
            [FromRoute] string customerId,
            [FromQuery] string loanApplicationId,
            [FromQuery] DateTime? startDate = null,
            [FromQuery] DateTime? endDate = null)
        {
            try
            {
                if (string.IsNullOrEmpty(customerId))
                {
                    return BadRequest(new { error = "Customer ID is required" });
                }

                if (string.IsNullOrEmpty(loanApplicationId))
                {
                    return BadRequest(new { error = "Loan Application ID is required" });
                }

                var end = endDate ?? DateTime.Now;
                var start = startDate ?? end.AddMonths(-6);

                if (start > end)
                {
                    return BadRequest(new { error = "Start date must be before end date" });
                }

                var bankStatement = await _bankStatementService.GetBankStatementAsync(customerId, start, end);
                bankStatement.LoanApplicationId = loanApplicationId;
                return Ok(bankStatement);
            }
            catch (Exception)
            {
                return StatusCode(500, new { error = "Error retrieving bank statements" });
            }
        }

        [HttpPost("evaluate")]
        public async Task<ActionResult<LoanDecision>> EvaluateLoan([FromBody] LoanRequest request)
        {
            try
            {
                if (request == null)
                {
                    return BadRequest(new { error = "Invalid request" });
                }

                var decision = await _loanDecisionService.ProcessLoanRequest(request);
                return Ok(decision);
            }
            catch (Exception)
            {
                return StatusCode(500, new { error = "An error occurred while processing your request" });
            }
        }
    }
}
