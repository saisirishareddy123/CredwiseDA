using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CredWise.Models.Root
{   
    public class ExistingLoan
    {
        [Required(ErrorMessage = "Loan ID is required")]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Loan ID must contain only alphanumeric characters")]
        public string LoanId { get; set; } = string.Empty; // Initialize with default

        [Required(ErrorMessage = "Monthly EMI is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Monthly EMI must be a positive number")]
        public decimal MonthlyEmi { get; set; }

        [Required(ErrorMessage = "Please specify if the loan is active")]
        public bool IsActive { get; set; }
    }
}
