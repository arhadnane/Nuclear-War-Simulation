namespace NuclearWarSimulation.Models
{
    public class City
    {
        public string Name { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Population { get; set; }
        public int PopulationDensity { get; set; }
    }
}
