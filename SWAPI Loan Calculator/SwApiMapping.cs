using Microsoft.Ajax.Utilities;
using StarWarsApiCSharp;
using SWAPI_Loan_Calculator.Models;
using System;
using System.Runtime;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SWAPI_Loan_Calculator
{
    public class SwApiMapping
    {
        public static SwVehicle MapVehicle(Vehicle vehicle)
        {
            //Create SwVehicle
            SwVehicle swVehicle = new SwVehicle();
            decimal CostinCreditsOutParameter;

            if (vehicle == null) {
                swVehicle.Name = "error";
                return swVehicle;
                    };

                //Map properties
                swVehicle.Name = vehicle.Name;
            swVehicle.Model = vehicle.Model;
            swVehicle.VehicleClass = vehicle.VehicleClass;
            swVehicle.Manufacturer = vehicle.Manufacturer;
            swVehicle.Length = vehicle.Length;

            bool parseCost = decimal.TryParse(vehicle.CostInCredits, out CostinCreditsOutParameter);

            if (parseCost) swVehicle.CostInCredits = CostinCreditsOutParameter;
            else swVehicle.CostInCredits = 0;

            swVehicle.MaxAtmospheringSpeed = vehicle.MaxAtmospheringSpeed;
            swVehicle.CargoCapacity = vehicle.CargoCapacity;
            swVehicle.Id = GetFilmId(vehicle.Url,true);
            //swVehicle.ImageURL = GetImageURL();

            

            return swVehicle;

        }

        public static SwStarship MapStarship(Starship starship)
        {
            //Create SwStarship
            SwStarship swStarship = new SwStarship();
            decimal CostinCreditsOutParameter;

            if (starship == null)
            {
                swStarship.Name = "error";
                return swStarship;
            };

            //Map properties
            swStarship.Name = starship.Name;
            swStarship.Model = starship.Model;
            swStarship.Manufacturer = starship.Manufacturer;
            swStarship.Length = starship.Length;

            bool parseCost = decimal.TryParse(starship.CostInCredits, out CostinCreditsOutParameter);

            if (parseCost) swStarship.CostInCredits = CostinCreditsOutParameter;
            else swStarship.CostInCredits = 0;

            swStarship.MaxAtmospheringSpeed = starship.MaxAtmospheringSpeed;
            swStarship.CargoCapacity = starship.CargoCapacity;
            swStarship.Id = GetFilmId(starship.Url,false);

            //swStarship.ImageURL = GetImageURL();



            return swStarship;

        }

        private static int GetFilmId(string filmUrl, bool isVehicle)
        {
            //// filmUrl = https://swapi.dev/api/films/<Id>/

            //// TODO: will not work if the Id has two digits.
            int lastNumber = filmUrl.Length - 1;
            int indexOfId = isVehicle ? 30 : 31;
            int result = int.Parse(filmUrl.Substring(indexOfId,lastNumber-indexOfId).ToString());
            return result;
        }
    }
}
