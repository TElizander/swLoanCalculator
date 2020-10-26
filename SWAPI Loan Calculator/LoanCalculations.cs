using SWAPI_Loan_Calculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SWAPI_Loan_Calculator
{

        public static class LoanCalculations
        {
            public static void CalculateMonthDetailed(MonthlyBreakdown month, LoanDetails loanDetails)
            {
                month.StartingBalance = loanDetails.Balance;
                month.MonthlyPayment = loanDetails.MonthlyPayment; 
                month.PeriodInterest = month.StartingBalance * loanDetails.R;
                month.PeriodPrincipal = month.MonthlyPayment - month.PeriodInterest;
                month.EndingBalance = month.StartingBalance - month.PeriodPrincipal;
                loanDetails.Balance = month.EndingBalance;
                loanDetails.TotalInterest += month.PeriodInterest;
                month.TotalInterestToDate = loanDetails.TotalInterest;
                loanDetails.TotalPrincipal += month.PeriodPrincipal;

            }

        public static void CalculateLastMonthDetailed(MonthlyBreakdown month, LoanDetails loanDetails)
        {
            month.StartingBalance = loanDetails.Balance;
            month.PeriodInterest = month.StartingBalance * loanDetails.R;
            month.PeriodPrincipal =month.StartingBalance;
            month.MonthlyPayment = Math.Round(month.PeriodInterest,2) + Math.Round(month.PeriodPrincipal,2);
            month.EndingBalance = month.StartingBalance - month.PeriodPrincipal;
            loanDetails.Balance = month.EndingBalance;
            loanDetails.TotalInterest += month.PeriodInterest;
            month.TotalInterestToDate = loanDetails.TotalInterest;
            loanDetails.TotalPrincipal += month.PeriodPrincipal;

        }






        public static void DetermineMonth(MonthlyBreakdown month, int monthsOut)
            {
                DateTime today = DateTime.Now;
                string displayMonth = today.AddMonths(monthsOut).ToString("MMMM") + " " + today.AddMonths(monthsOut).Year.ToString();
                month.Month = displayMonth;
            }

        }
    
}