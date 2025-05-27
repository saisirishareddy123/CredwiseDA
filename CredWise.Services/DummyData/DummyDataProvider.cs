using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CredWise.Models.Root;

namespace CredWise.Services.DummyData
{

    public static class DummyDataProvider
    {
        public static List<LoanApplicationRequest> GetAllTestCases()
        {
            var testCases = new List<LoanApplicationRequest>();

            // Add all valid cases
            testCases.AddRange(GetValidTestCases());

            // Add all invalid cases
            testCases.AddRange(GetInvalidTestCases());

            // Add all edge cases
            testCases.AddRange(GetEdgeCases());

            return testCases;
        }

        public static List<LoanApplicationRequest> GetValidTestCases()
        {
            return new List<LoanApplicationRequest>
            {
                // Case 1: Ideal approved loan
                new() {
                    UserId = "cust1001",
                    RequestedAmount = 15000,
                    BankStatements = new List<BankTransaction>
                    {
                        new() {
                            Date = DateTime.Parse("2025-05-01"),
                            Amount = 45000,
                            Type = "CREDIT",
                            Description = "Monthly Salary"
                        },
                        new() {
                            Date = DateTime.Parse("2025-05-15"),
                            Amount = 2000,
                            Type = "DEBIT",
                            Description = "Rent Payment"
                        }
                    },
                    ExistingLoans = new List<ExistingLoan>()
                },

                // Case 2: Approved with inactive existing loan
                new() {
                    UserId = "cust1002",
                    RequestedAmount = 20000,
                    BankStatements = new List<BankTransaction>
                    {
                        new() {
                            Date = DateTime.Parse("2025-05-10"),
                            Amount = 60000,
                            Type = "CREDIT",
                            Description = "Freelance Income"
                        }
                    },
                    ExistingLoans = new List<ExistingLoan>
                    {
                        new() {
                            LoanId = "ln2024001",
                            MonthlyEmi = 5000,
                            IsActive = false
                        }
                    }
                }
            };
        }

        public static List<LoanApplicationRequest> GetInvalidTestCases()
        {
            return new List<LoanApplicationRequest>
            {
                // Case 3: Rejected - Active existing loan
                new() {
                    UserId = "cust1003",
                    RequestedAmount = 25000,
                    BankStatements = new List<BankTransaction>
                    {
                        new() {
                            Date = DateTime.Parse("2025-05-05"),
                            Amount = 50000,
                            Type = "CREDIT",
                            Description = "Salary"
                        }
                    },
                    ExistingLoans = new List<ExistingLoan>
                    {
                        new() {
                            LoanId = "ln2024002",
                            MonthlyEmi = 7000,
                            IsActive = true
                        }
                    }
                },

                // Case 4: Rejected - Low income
                new() {
                    UserId = "cust1004",
                    RequestedAmount = 10000,
                    BankStatements = new List<BankTransaction>
                    {
                        new() {
                            Date = DateTime.Parse("2025-05-20"),
                            Amount = 25000,
                            Type = "CREDIT",
                            Description = "Part-time Salary"
                        }
                    },
                    ExistingLoans = new List<ExistingLoan>()
                }
            };
        }

        public static List<LoanApplicationRequest> GetEdgeCases()
        {
            return new List<LoanApplicationRequest>
            {
                // Case 5: Minimum approvable amount
                new() {
                    UserId = "cust1005",
                    RequestedAmount = 5000,
                    BankStatements = new List<BankTransaction>
                    {
                        new() {
                            Date = DateTime.Parse("2025-05-01"),
                            Amount = 30000,
                            Type = "CREDIT",
                            Description = "Salary"
                        }
                    },
                    ExistingLoans = new List<ExistingLoan>()
                },

                // Case 6: Maximum values test
                new() {
                    UserId = "cust1006",
                    RequestedAmount = decimal.MaxValue,
                    BankStatements = new List<BankTransaction>
                    {
                        new() {
                            Date = DateTime.Parse("2025-05-01"),
                            Amount = decimal.MaxValue,
                            Type = "CREDIT",
                            Description = "Large Inheritance"
                        }
                    },
                    ExistingLoans = new List<ExistingLoan>()
                },

                // Case 7: Minimum required fields
                new() {
                    UserId = "min123",
                    RequestedAmount = 5001,
                    BankStatements = new List<BankTransaction>
                    {
                        new() {
                            Date = DateTime.Parse("2025-01-01"),
                            Amount = 30001,
                            Type = "CREDIT",
                            Description = "S"
                        }
                    },
                    ExistingLoans = new List<ExistingLoan>()
                }
            };
        }

        public static List<LoanDecisionResponse> GetSampleResponses()
        {
            return new List<LoanDecisionResponse>
            {
                new() {
                    IsApproved = true,
                    ApprovedAmount = 15000,
                    RejectionReason = null,
                    CriteriaResults = new List<string> { "All checks passed" }
                },
                new() {
                    IsApproved = false,
                    ApprovedAmount = 0,
                    RejectionReason = "Existing active loan",
                    CriteriaResults = new List<string> { "Active loan check failed" }
                }
            };
        }
    }
}
