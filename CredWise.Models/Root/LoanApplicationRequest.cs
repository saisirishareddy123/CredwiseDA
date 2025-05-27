using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CredWise.Models.Root
{
    public class LoanApplicationRequest
    {
        [Required(ErrorMessage = "User ID is required")]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "User ID must contain only alphanumeric characters")]
        public string UserId { get; set; } = string.Empty; // Initialize with default

        [Required(ErrorMessage = "Requested amount is required")]
        [Range(1, double.MaxValue, ErrorMessage = "Requested amount must be a positive number")]
        public decimal RequestedAmount { get; set; }

        [Required(ErrorMessage = "At least one bank statement is required")]
        [MinLength(1, ErrorMessage = "At least one bank statement is required")]
        public List<BankTransaction> BankStatements { get; set; } = new();

        public List<ExistingLoan> ExistingLoans { get; set; } = new();
    }
}
