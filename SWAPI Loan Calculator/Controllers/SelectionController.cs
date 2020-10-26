using SWAPI_Loan_Calculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SWAPI_Loan_Calculator.Controllers
{
    public class SelectionController : Controller
    {
        // GET: Selection
        public ActionResult Index(string selection)
        {
            SelectionViewModel SelectionModel = new SelectionViewModel();

            SelectionModel.Selection = selection;
            SelectionModel.SwVehicles = StarWarsApiData.GetSwVehicles();
            SelectionModel.SwStarships = StarWarsApiData.GetSwStarships();
           
            return View(SelectionModel);
        }
    }
}