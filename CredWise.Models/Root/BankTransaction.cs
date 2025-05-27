using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CredWise.Models.Root
{

    public class BankTransaction
    {
        [Required(ErrorMessage = "Transaction date is required")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Amount is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be a positive number")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Transaction type is required")]
        [RegularExpression("^(CREDIT|DEBIT)$", ErrorMessage = "Type must be either CREDIT or DEBIT")]
        public string? Type { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string? Description { get; set; }
    }
}
