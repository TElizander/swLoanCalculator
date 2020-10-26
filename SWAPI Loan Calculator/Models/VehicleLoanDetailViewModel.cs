using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Web;

namespace SWAPI_Loan_Calculator.Models
{
    public class VehicleLoanDetailViewModel
    {
        public SwVehicle swVehicle { get; set; }
        public LoanDetails LoanDetails { get; set; }
        [Required]
        [Range(0, 2000000000,
        ErrorMessage = "Enter value between {1} and {2}.")]
        public int LoanAmount { get; set; }
        [Required]
        [Range(36, 480,
        ErrorMessage = "Enter value between {1} and {2}.")]
        public int TermsInMonths { get; set; }
        [Required]
        [Range(0, 100,
        ErrorMessage = "Enter value between {1} and {2}.")]
        public decimal InterestRate { get; set; }
    }
}