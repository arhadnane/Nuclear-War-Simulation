using System.ComponentModel.DataAnnotations;

namespace NuclearWarSimulation.Models
{
    public class SimulationModel
    {
        [Required]
        [Display(Name = "Target City")]
        public string TargetCity { get; set; } = string.Empty;

        [Required]
        [Range(0.1, 100000, ErrorMessage = "Bomb yield must be between 0.1 and 100,000 kilotons")]
        [Display(Name = "Bomb Yield (Kilotons)")]
        public double BombYield { get; set; }

        [Required]
        [Display(Name = "Detonation Type")]
        public DetonationType DetonationType { get; set; }

        [Required]
        [Range(-90, 90, ErrorMessage = "Latitude must be between -90 and 90")]
        public double Latitude { get; set; }

        [Required]
        [Range(-180, 180, ErrorMessage = "Longitude must be between -180 and 180")]
        public double Longitude { get; set; }

        [Display(Name = "Population Density (per km²)")]
        public int PopulationDensity { get; set; } = 1000;
    }

    public enum DetonationType
    {
        [Display(Name = "Air Burst")]
        AirBurst,
        [Display(Name = "Surface Burst")]
        SurfaceBurst
    }
}
