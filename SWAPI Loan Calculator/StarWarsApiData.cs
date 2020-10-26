using StarWarsApiCSharp;
using SWAPI_Loan_Calculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SWAPI_Loan_Calculator
{
    public class StarWarsApiData
    {
        //Get all vehicles
        public static List<SwVehicle> GetSwVehicles()
        {
            //Hit API, get collection of vehicles in ambigous collection (var)

            IRepository<Vehicle> vehicleRepo = new Repository<Vehicle>();
            var vehicles = vehicleRepo.GetEntities(1, 40);
            List<SwVehicle> swVehicles = new List<SwVehicle>();

            foreach (Vehicle vehicle in vehicles)
            {
                
                SwVehicle swVehicle = SwApiMapping.MapVehicle(vehicle);
                //if (swVehicle.CostInCredits > 2147483647) swVehicle.CostInCredits = 2147483647.0M;
                if (swVehicle.CostInCredits > 20000) swVehicles.Add(swVehicle);
            }

            return swVehicles;

        }

        //Get all starships
        public static List<SwStarship> GetSwStarships()
        {
            //Hit API, get collection of starships in ambigous collection (var)

            IRepository<Starship> starshipRepo = new Repository<Starship>();
            var starships = starshipRepo.GetEntities(1, 40);
            List<SwStarship> swStarships = new List<SwStarship>();

            foreach (Starship starship in starships)
            {
                SwStarship swStarship = SwApiMapping.MapStarship(starship);
               // if (swStarship.CostInCredits > 2147483647) swStarship.CostInCredits = 2147483647.0M;
                if (swStarship.CostInCredits > 20000) swStarships.Add(swStarship);
            }

            return swStarships;

        }


            //Get vehicle details

       public static SwVehicle GetSwVehicleById(int id)
        {
            IRepository<Vehicle> vehicleRepo = new Repository<Vehicle>();
            Vehicle vehicle = vehicleRepo.GetById(id);

            SwVehicle swVehicle = SwApiMapping.MapVehicle(vehicle);
            if (swVehicle.CostInCredits > 2147483647) swVehicle.CostInCredits = 2147483647.0M;

            Dictionary<int, string> vehicleImageURLs = new Dictionary<int, string>();

            vehicleImageURLs.Add(76, "http://iconbug.com/data/e7/256/5cb4292eef9ceaefc144cac722a54143.png");

            if (vehicleImageURLs.ContainsKey(id))
            {
                swVehicle.ImageURL = vehicleImageURLs[id];
            }
            else
            {
                swVehicle.ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/7/75/Emblem_of_the_First_Galactic_Empire.svg/600px-Emblem_of_the_First_Galactic_Empire.svg.png";
            }

        

            return swVehicle;
        }

        //Get starship detailsl

        public static SwStarship GetSwStarshipById(int id)
        {
            IRepository<Starship> starshipRepo = new Repository<Starship>();
            Starship starship = starshipRepo.GetById(id);

       

            SwStarship swStarship = SwApiMapping.MapStarship(starship);
            if (swStarship.CostInCredits > 2147483647) swStarship.CostInCredits = 2147483647.0M;

            Dictionary<int, string> starshipImageURLs = new Dictionary<int, string>();
            starshipImageURLs.Add(100, "https://www.vhv.rs/file/max/27/271590_millennium-falcon-png.png");

            if (starshipImageURLs.ContainsKey(id))
            {
                swStarship.ImageURL = starshipImageURLs[id];
            }
            else
            {
                swStarship.ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/7/75/Emblem_of_the_First_Galactic_Empire.svg/600px-Emblem_of_the_First_Galactic_Empire.svg.png";
            }

            return swStarship;
        }



    }
}