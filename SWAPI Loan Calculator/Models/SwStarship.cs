using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SWAPI_Loan_Calculator.Models
{
    public class SwStarship
    {

        public string Name { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public string Length { get; set; }
        public decimal CostInCredits { get; set; }
        public string MaxAtmospheringSpeed { get; set; }

        public string CargoCapacity { get; set; }
        public int Id { get; set; }
        public string ImageURL { get; set; }

    }
}