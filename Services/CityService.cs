using NuclearWarSimulation.Models;

namespace NuclearWarSimulation.Services
{
    public class CityService
    {
        private readonly List<City> _cities;

        public CityService()
        {
            _cities = InitializeCities();
        }

        public List<City> GetAllCities()
        {
            return _cities;
        }

        public City? GetCityByName(string name)
        {
            return _cities.FirstOrDefault(c => 
                c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        private List<City> InitializeCities()
        {
            return new List<City>
            {
                new City { Name = "New York", Country = "USA", Latitude = 40.7128, Longitude = -74.0060, Population = 8336817, PopulationDensity = 11313 },
                new City { Name = "Los Angeles", Country = "USA", Latitude = 34.0522, Longitude = -118.2437, Population = 3979576, PopulationDensity = 3198 },
                new City { Name = "Chicago", Country = "USA", Latitude = 41.8781, Longitude = -87.6298, Population = 2693976, PopulationDensity = 4593 },
                new City { Name = "Houston", Country = "USA", Latitude = 29.7604, Longitude = -95.3698, Population = 2320268, PopulationDensity = 1395 },
                new City { Name = "London", Country = "UK", Latitude = 51.5074, Longitude = -0.1278, Population = 9540576, PopulationDensity = 5666 },
                new City { Name = "Paris", Country = "France", Latitude = 48.8566, Longitude = 2.3522, Population = 2161000, PopulationDensity = 20545 },
                new City { Name = "Berlin", Country = "Germany", Latitude = 52.5200, Longitude = 13.4050, Population = 3669491, PopulationDensity = 4115 },
                new City { Name = "Tokyo", Country = "Japan", Latitude = 35.6762, Longitude = 139.6503, Population = 37435191, PopulationDensity = 6158 },
                new City { Name = "Beijing", Country = "China", Latitude = 39.9042, Longitude = 116.4074, Population = 21540000, PopulationDensity = 1313 },
                new City { Name = "Moscow", Country = "Russia", Latitude = 55.7558, Longitude = 37.6173, Population = 12537954, PopulationDensity = 4925 },
                new City { Name = "Mumbai", Country = "India", Latitude = 19.0760, Longitude = 72.8777, Population = 20411274, PopulationDensity = 31700 },
                new City { Name = "Delhi", Country = "India", Latitude = 28.7041, Longitude = 77.1025, Population = 32941308, PopulationDensity = 11320 },
                new City { Name = "São Paulo", Country = "Brazil", Latitude = -23.5505, Longitude = -46.6333, Population = 22429800, PopulationDensity = 7398 },
                new City { Name = "Mexico City", Country = "Mexico", Latitude = 19.4326, Longitude = -99.1332, Population = 21804515, PopulationDensity = 6000 },
                new City { Name = "Cairo", Country = "Egypt", Latitude = 30.0444, Longitude = 31.2357, Population = 20484965, PopulationDensity = 19376 },
                new City { Name = "Istanbul", Country = "Turkey", Latitude = 41.0082, Longitude = 28.9784, Population = 15462452, PopulationDensity = 2523 },
                new City { Name = "Sydney", Country = "Australia", Latitude = -33.8688, Longitude = 151.2093, Population = 5312163, PopulationDensity = 2058 },
                new City { Name = "Toronto", Country = "Canada", Latitude = 43.6532, Longitude = -79.3832, Population = 2794356, PopulationDensity = 4427 },                new City { Name = "Seoul", Country = "South Korea", Latitude = 37.5665, Longitude = 126.9780, Population = 9720846, PopulationDensity = 16154 },
                new City { Name = "Bangkok", Country = "Thailand", Latitude = 13.7563, Longitude = 100.5018, Population = 10156000, PopulationDensity = 5300 },
                
                // Middle East and Africa
                new City { Name = "Casablanca", Country = "Morocco", Latitude = 33.5731, Longitude = -7.5898, Population = 3359818, PopulationDensity = 1800 },
                new City { Name = "Rabat", Country = "Morocco", Latitude = 34.0209, Longitude = -6.8416, Population = 577827, PopulationDensity = 2380 },
                new City { Name = "Tehran", Country = "Iran", Latitude = 35.6892, Longitude = 51.3890, Population = 8693706, PopulationDensity = 11800 },
                new City { Name = "Isfahan", Country = "Iran", Latitude = 32.6546, Longitude = 51.6680, Population = 1961260, PopulationDensity = 2200 },
                new City { Name = "Riyadh", Country = "Saudi Arabia", Latitude = 24.7136, Longitude = 46.6753, Population = 7676654, PopulationDensity = 1500 },
                new City { Name = "Jeddah", Country = "Saudi Arabia", Latitude = 21.4858, Longitude = 39.1925, Population = 4697000, PopulationDensity = 2800 },
                new City { Name = "Tunis", Country = "Tunisia", Latitude = 36.8065, Longitude = 10.1815, Population = 638845, PopulationDensity = 2975 },
                new City { Name = "Sfax", Country = "Tunisia", Latitude = 34.7406, Longitude = 10.7603, Population = 330440, PopulationDensity = 1850 },
                new City { Name = "Tripoli", Country = "Libya", Latitude = 32.8872, Longitude = 13.1913, Population = 1126000, PopulationDensity = 4300 },
                new City { Name = "Benghazi", Country = "Libya", Latitude = 32.1165, Longitude = 20.0686, Population = 650629, PopulationDensity = 2100 },
                new City { Name = "Cape Town", Country = "South Africa", Latitude = -33.9249, Longitude = 18.4241, Population = 4618000, PopulationDensity = 1900 },
                new City { Name = "Johannesburg", Country = "South Africa", Latitude = -26.2041, Longitude = 28.0473, Population = 5635127, PopulationDensity = 3100 }
            };
        }
    }
}
