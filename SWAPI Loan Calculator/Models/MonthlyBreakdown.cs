using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SWAPI_Loan_Calculator.Models
{
    public class MonthlyBreakdown
    {
        public int MonthNumber { get; set; }
        public string Month { get; set; }

        public decimal StartingBalance { get; set; }
        public decimal MonthlyPayment { get; set; }
        public decimal PeriodInterest { get; set; }
        public decimal PeriodPrincipal { get; set; }
        public decimal EndingBalance { get; set; }
        public decimal TotalInterestToDate { get; set; }

    }
}