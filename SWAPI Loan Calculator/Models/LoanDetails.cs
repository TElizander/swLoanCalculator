using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SWAPI_Loan_Calculator.Models
{
    public class LoanDetails
    {
        [Required]
        [Range(0.0, Double.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        public decimal LoanAmount { get; set; }
        [Required]

        public decimal TermsInMonths { get; set; }
        [Required]
        [Range(0.1,1)]
        public decimal InterestRate { get; set; }
        public decimal R { get; set; }
        public decimal DiscountFactor { get; set; }
        public decimal MonthlyPayment { get; set; }
        public decimal TotalInterest { get; set; }
        public decimal TotalPrincipal { get; set; }
        public decimal Balance { get; set; }
        public List<MonthlyBreakdown> TotalLoanDetailsByMonth { get; set; } = new List<MonthlyBreakdown>();

        public void CalculateLoanParameters()
        {
            this.R = InterestRate / 12;
            this.DiscountFactor = Convert.ToDecimal((Math.Pow((1 + decimal.ToDouble(R)), decimal.ToDouble(TermsInMonths)) - 1) / (Decimal.ToDouble(R) * Math.Pow(1 + Decimal.ToDouble(R), decimal.ToDouble(TermsInMonths))));
            this.MonthlyPayment = LoanAmount / DiscountFactor;
            this.TotalInterest = 0M;
            this.TotalPrincipal = 0M;
            this.Balance = LoanAmount;

        }

    }
}