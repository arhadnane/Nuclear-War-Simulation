namespace NuclearWarSimulation.Models
{
    public class SimulationResult
    {
        public string TargetCity { get; set; } = string.Empty;
        public double BombYield { get; set; }
        public DetonationType DetonationType { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int PopulationDensity { get; set; }
        
        // Blast effect radii (in meters)
        public double FireballRadius { get; set; }
        public double RadiationRadius { get; set; }
        public double AirBlastRadius { get; set; }
        public double ThermalRadiationRadius { get; set; }
        public double LightBlastRadius { get; set; }
        
        // Casualty estimates
        public int EstimatedDeaths { get; set; }
        public int EstimatedInjuries { get; set; }
        public int TotalAffected { get; set; }
        
        // Environmental effects
        public double FalloutRadius { get; set; }
        public string RadiationLevel { get; set; } = string.Empty;
        public bool FirestormProbability { get; set; }
        
        public DateTime SimulationDate { get; set; } = DateTime.Now;
    }
}
