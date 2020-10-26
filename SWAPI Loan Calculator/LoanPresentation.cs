using SWAPI_Loan_Calculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SWAPI_Loan_Calculator
{
    public class LoanPresentation
    {
        public static LoanDetails GetLoanDetails(decimal loanAmount, decimal termsInMonths, decimal interestRate)
        {
            //Create instance of Loan Detail class that will hold critical information
            LoanDetails loanDetails = new LoanDetails();

            //Convert strings to necessary decimals, place in loanDetail properties

            loanDetails.LoanAmount = loanAmount;
            loanDetails.TermsInMonths = termsInMonths;
            loanDetails.InterestRate = interestRate / 100;

            //RRRR, Calculate r, discount factor, and monthly payments
            loanDetails.CalculateLoanParameters();

            for (int i = 1; i <= Decimal.ToInt32(loanDetails.TermsInMonths); i++)
            {
                MonthlyBreakdown month = new MonthlyBreakdown();
                month.MonthNumber = i;
                LoanCalculations.DetermineMonth(month, i);

                if (i == Decimal.ToInt32(loanDetails.TermsInMonths)){
                    LoanCalculations.CalculateLastMonthDetailed(month, loanDetails);
                }
                else
                { 
                    LoanCalculations.CalculateMonthDetailed(month, loanDetails); 
                }
                loanDetails.TotalLoanDetailsByMonth.Add(month);
            }

            return loanDetails;



        }




   

 
    }
}