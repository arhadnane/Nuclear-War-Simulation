using Microsoft.AspNetCore.Mvc;
using NuclearWarSimulation.Models;
using NuclearWarSimulation.Services;

namespace NuclearWarSimulation.Controllers
{
    public class SimulationController : Controller
    {
        private readonly NuclearBlastCalculator _calculator;
        private readonly CityService _cityService;
        private readonly ILogger<SimulationController> _logger;

        public SimulationController(
            NuclearBlastCalculator calculator, 
            CityService cityService,
            ILogger<SimulationController> logger)
        {
            _calculator = calculator;
            _cityService = cityService;
            _logger = logger;
        }        public IActionResult Index()
        {
            ViewBag.Cities = _cityService.GetAllCities();
            
            // Initialize with default values (New York)
            var model = new SimulationModel
            {
                TargetCity = "New York",
                Latitude = 40.7128,
                Longitude = -74.0060,
                BombYield = 15,
                DetonationType = DetonationType.AirBurst,
                PopulationDensity = 11313
            };
            
            return View(model);
        }        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RunSimulation(SimulationModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Cities = _cityService.GetAllCities();
                return View("Index", model);
            }

            try
            {
                // Log input for debugging
                _logger.LogInformation($"Running simulation for {model.TargetCity} at ({model.Latitude}, {model.Longitude}) with {model.BombYield}kt {model.DetonationType}");
                
                var result = _calculator.CalculateBlastEffects(model);
                
                // Log results for debugging
                _logger.LogInformation($"Calculated results: Fireball={result.FireballRadius}m, Radiation={result.RadiationRadius}m, AirBlast={result.AirBlastRadius}m");
                
                return View("Results", result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error calculating blast effects");
                ModelState.AddModelError("", "An error occurred while calculating the simulation results.");
                ViewBag.Cities = _cityService.GetAllCities();
                return View("Index", model);
            }
        }

        [HttpGet]
        public IActionResult GetCityData(string cityName)
        {
            var city = _cityService.GetCityByName(cityName);
            if (city != null)
            {
                return Json(new
                {
                    latitude = city.Latitude,
                    longitude = city.Longitude,
                    populationDensity = city.PopulationDensity,
                    population = city.Population
                });
            }
            return Json(null);
        }

        public IActionResult Results(SimulationResult? result = null)
        {
            if (result == null)
            {
                return RedirectToAction("Index");
            }
            return View(result);
        }
    }
}
