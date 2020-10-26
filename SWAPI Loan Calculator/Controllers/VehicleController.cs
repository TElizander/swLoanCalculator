using SWAPI_Loan_Calculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Web;
using System.Web.Mvc;

namespace SWAPI_Loan_Calculator.Controllers
{
    public class VehicleController : Controller
    {
        // GET: Vehicle
        public ActionResult Index(string selection)
        {
            SelectionViewModel SelectionModel = new SelectionViewModel();

            SelectionModel.Selection = selection;
            SelectionModel.SwVehicles = StarWarsApiData.GetSwVehicles();
            SelectionModel.SwStarships = StarWarsApiData.GetSwStarships();

            return View(SelectionModel);
        }

 

        //Get: Vehicle
        public ActionResult Detail(int? id)
        {
            if(id == null) return RedirectToAction("Index", "Vehicle");


            VehicleLoanDetailViewModel DetailModel = new VehicleLoanDetailViewModel();

            DetailModel.swVehicle = StarWarsApiData.GetSwVehicleById((int)id);

            if (DetailModel.swVehicle.Name == "error")
            {
                return RedirectToAction("Index", "Starship");
            }

            DetailModel.LoanAmount = (int)DetailModel.swVehicle.CostInCredits;
                DetailModel.TermsInMonths = 180;
                DetailModel.InterestRate = 5.0M;

                 return View(DetailModel); 
           
            
        }
    
        [ActionName("Loan")]
        public ActionResult Loan()
        {

           
                return RedirectToAction("Index", "Vehicle");

        }

        // POST: Vehicle/Loan
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Loan")]
        [ValidateAntiForgeryToken]
        public ActionResult Loan([Bind(Include = "LoanAmount,TermsInMonths,InterestRate")] VehicleLoanDetailViewModel tempModel, int id)
        {

            VehicleLoanDetailViewModel vehicleLoanDetailViewModel = new VehicleLoanDetailViewModel();

            vehicleLoanDetailViewModel.LoanDetails = LoanPresentation.GetLoanDetails(Convert.ToDecimal(tempModel.LoanAmount), Convert.ToDecimal(tempModel.TermsInMonths), tempModel.InterestRate);
            vehicleLoanDetailViewModel.LoanAmount = tempModel.LoanAmount;
            vehicleLoanDetailViewModel.TermsInMonths = tempModel.TermsInMonths;
            vehicleLoanDetailViewModel.InterestRate = tempModel.InterestRate;

            vehicleLoanDetailViewModel.swVehicle = StarWarsApiData.GetSwVehicleById(id);



            return View(vehicleLoanDetailViewModel);
        }
    }
}