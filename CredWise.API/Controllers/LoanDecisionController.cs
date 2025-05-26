using Microsoft.AspNetCore.Mvc;
using CredWise.Models;
using CredWise.Services.Interface;
using CredWise.Models.Root;

namespace CredWise.API.Controllers
{
    [ApiController]
    [Route("api/loan")]
    public class LoanDecisionController : ControllerBase
    {
        private readonly ILoanDecisionService _decisionService;

        public LoanDecisionController(ILoanDecisionService decisionService)
        {
            _decisionService = decisionService;
        }

        [HttpPost("evaluate")]
        public IActionResult EvaluateLoan([FromBody] LoanApplicationRequest request)
        {
            if (request?.BankStatements == null || !request.BankStatements.Any())
                return BadRequest("Bank statements are required");

            var response = _decisionService.EvaluateLoan(request);
            return Ok(response);
        }
    }
}
