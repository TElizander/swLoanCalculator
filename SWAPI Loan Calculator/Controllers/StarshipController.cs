using SWAPI_Loan_Calculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Web;
using System.Web.Mvc;

namespace SWAPI_Loan_Calculator.Controllers
{
    public class StarshipController : Controller
    {
        // GET: Starship
        public ActionResult Index(string selection)
        {
            SelectionViewModel SelectionModel = new SelectionViewModel();

            SelectionModel.Selection = selection;
            SelectionModel.SwVehicles = StarWarsApiData.GetSwVehicles();
            SelectionModel.SwStarships = StarWarsApiData.GetSwStarships();

            return View(SelectionModel);
        }



        //Get: Starship
        public ActionResult Detail(int? id)
        {
            if (id == null) return RedirectToAction("Index", "Starship");


            StarshipLoanDetailViewModel DetailModel = new StarshipLoanDetailViewModel();

                DetailModel.swStarship = StarWarsApiData.GetSwStarshipById((int)id);
       
            if(DetailModel.swStarship.Name == "error")
            {
                return RedirectToAction("Index", "Starship");
            }
            

            DetailModel.LoanAmount = (int)DetailModel.swStarship.CostInCredits;
            DetailModel.TermsInMonths = 180;
            DetailModel.InterestRate = 5.0M;

            return View(DetailModel);


        }

        [ActionName("Loan")]
        public ActionResult Loan()
        {


            return RedirectToAction("Index", "Starship");

        }

        // POST: Starship/Loan
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Loan")]
        [ValidateAntiForgeryToken]
        public ActionResult Loan([Bind(Include = "LoanAmount,TermsInMonths,InterestRate")] StarshipLoanDetailViewModel tempModel, int id)
        {

            StarshipLoanDetailViewModel starshipLoanDetailViewModel = new StarshipLoanDetailViewModel();

            starshipLoanDetailViewModel.LoanDetails = LoanPresentation.GetLoanDetails(Convert.ToDecimal(tempModel.LoanAmount), Convert.ToDecimal(tempModel.TermsInMonths), tempModel.InterestRate);
            starshipLoanDetailViewModel.LoanAmount = tempModel.LoanAmount;
            starshipLoanDetailViewModel.TermsInMonths = tempModel.TermsInMonths;
            starshipLoanDetailViewModel.InterestRate = tempModel.InterestRate;

            starshipLoanDetailViewModel.swStarship = StarWarsApiData.GetSwStarshipById(id);



            return View(starshipLoanDetailViewModel);
        }
    }
}