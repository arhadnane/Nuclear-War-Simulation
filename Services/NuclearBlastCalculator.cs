using NuclearWarSimulation.Models;

namespace NuclearWarSimulation.Services
{
    public class NuclearBlastCalculator
    {
        /// <summary>
        /// Calculates the effects of a nuclear blast based on yield and detonation type
        /// </summary>
        /// <param name="model">Simulation input parameters</param>
        /// <returns>Calculated blast effects and casualty estimates</returns>
        public SimulationResult CalculateBlastEffects(SimulationModel model)
        {
            var result = new SimulationResult
            {
                TargetCity = model.TargetCity,
                BombYield = model.BombYield,
                DetonationType = model.DetonationType,
                Latitude = model.Latitude,
                Longitude = model.Longitude,
                PopulationDensity = model.PopulationDensity
            };

            // Convert yield to TNT equivalent in tons
            double yieldInTons = model.BombYield * 1000;
            
            // Calculate blast radii using scaling laws
            // These formulas are based on the Effects of Nuclear Weapons handbook
            result.FireballRadius = CalculateFireballRadius(yieldInTons);
            result.RadiationRadius = CalculateRadiationRadius(yieldInTons);
            result.AirBlastRadius = CalculateAirBlastRadius(yieldInTons, model.DetonationType);
            result.ThermalRadiationRadius = CalculateThermalRadiationRadius(yieldInTons);
            result.LightBlastRadius = CalculateLightBlastRadius(yieldInTons);
            
            // Calculate fallout for surface bursts
            if (model.DetonationType == DetonationType.SurfaceBurst)
            {
                result.FalloutRadius = CalculateFalloutRadius(yieldInTons);
                result.RadiationLevel = "High - Long-term contamination expected";
            }
            else
            {
                result.FalloutRadius = result.RadiationRadius * 0.3; // Minimal fallout for airbursts
                result.RadiationLevel = "Moderate - Short-term radiation effects";
            }
            
            // Calculate casualties
            CalculateCasualties(result);
            
            // Determine firestorm probability
            result.FirestormProbability = yieldInTons > 10000 && model.PopulationDensity > 500;
            
            return result;
        }

        private double CalculateFireballRadius(double yieldInTons)
        {
            // Fireball radius scales as yield^(1/3)
            return 90 * Math.Pow(yieldInTons / 1000, 1.0/3.0);
        }

        private double CalculateRadiationRadius(double yieldInTons)
        {
            // Lethal radiation radius (500 rem dose)
            return 1200 * Math.Pow(yieldInTons / 1000, 1.0/3.0);
        }

        private double CalculateAirBlastRadius(double yieldInTons, DetonationType detonationType)
        {
            // 5 psi overpressure radius (severe structural damage)
            double baseRadius = 2200 * Math.Pow(yieldInTons / 1000, 1.0/3.0);
            
            // Surface bursts have reduced air blast effect
            return detonationType == DetonationType.SurfaceBurst ? baseRadius * 0.8 : baseRadius;
        }

        private double CalculateThermalRadiationRadius(double yieldInTons)
        {
            // Third-degree burns radius
            return 3200 * Math.Pow(yieldInTons / 1000, 1.0/3.0);
        }

        private double CalculateLightBlastRadius(double yieldInTons)
        {
            // Light blast damage radius (1 psi overpressure)
            return 4500 * Math.Pow(yieldInTons / 1000, 1.0/3.0);
        }

        private double CalculateFalloutRadius(double yieldInTons)
        {
            // Fallout radius for surface burst (depends on wind patterns)
            // This is a simplified calculation
            return 8000 * Math.Pow(yieldInTons / 1000, 0.4);
        }

        private void CalculateCasualties(SimulationResult result)
        {
            // Calculate affected population in each zone
            double fireballArea = Math.PI * Math.Pow(result.FireballRadius / 1000, 2); // km²
            double radiationArea = Math.PI * Math.Pow(result.RadiationRadius / 1000, 2) - fireballArea;
            double airBlastArea = Math.PI * Math.Pow(result.AirBlastRadius / 1000, 2) - 
                                 Math.PI * Math.Pow(result.RadiationRadius / 1000, 2);
            double thermalArea = Math.PI * Math.Pow(result.ThermalRadiationRadius / 1000, 2) - 
                                Math.PI * Math.Pow(result.AirBlastRadius / 1000, 2);

            // Fatality rates by zone
            int fireballDeaths = (int)(fireballArea * result.PopulationDensity * 0.98); // 98% fatality
            int radiationDeaths = (int)(radiationArea * result.PopulationDensity * 0.50); // 50% fatality
            int airBlastDeaths = (int)(airBlastArea * result.PopulationDensity * 0.15); // 15% fatality
            int thermalDeaths = (int)(thermalArea * result.PopulationDensity * 0.05); // 5% fatality

            result.EstimatedDeaths = fireballDeaths + radiationDeaths + airBlastDeaths + thermalDeaths;

            // Injury calculations
            int radiationInjuries = (int)(radiationArea * result.PopulationDensity * 0.35);
            int airBlastInjuries = (int)(airBlastArea * result.PopulationDensity * 0.45);
            int thermalInjuries = (int)(thermalArea * result.PopulationDensity * 0.35);

            result.EstimatedInjuries = radiationInjuries + airBlastInjuries + thermalInjuries;

            // Total affected population
            double totalAffectedArea = Math.PI * Math.Pow(result.LightBlastRadius / 1000, 2);
            result.TotalAffected = (int)(totalAffectedArea * result.PopulationDensity);
        }
    }
}
