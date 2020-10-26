using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SWAPI_Loan_Calculator.Models
{
    public class SelectionViewModel
    {
        public string Selection { get; set; }
        public List<SwVehicle> SwVehicles { get; set; }
        public List<SwStarship> SwStarships { get; set; }
    }
}