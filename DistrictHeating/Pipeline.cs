using System;
using System.Collections.Generic;
using System.Text;

namespace DistrictHeating
{
    /// <summary>
    /// This class describes the pipeline system. It is used to calculate the heat loss
    /// </summary>
    public class Pipeline
    {
        public double length; // length of the pipeline in [m].
                              // Maybe we split this in different parts with different diameters etc. or use multiple pipeline objects later
        public double innerDiameter; // diameter of the pipes [m]
        public double insulationLambda; // lambda of the insulation material
        public double outerDiameter; // outer diameter of the insulated pipes [m]
        public int connections;
        public Pipeline(double PiplineLength = 3000, double PipeDiameter = 0.05, double PipeInsulationDiameter = 0.15, double InsulationLambda = 0.022, int NumConnections = 80)
        {
            length = PiplineLength;
            innerDiameter = PipeDiameter;
            insulationLambda = InsulationLambda;
            outerDiameter = PipeInsulationDiameter;
        }
        /// <summary>
        /// Calculates the temperature loss of the water in the pipes. Assuming constant temperature inside and outside of the pipe.
        /// The ambient temperature (of the soil) is fixed to 10°C. Temperature gradient in the soil is ignored, as well as pipe material and thickness.
        /// Only the pipe insulation is considered
        /// </summary>
        /// <param name="waterTemperature"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        public (double newTemperature, double energyLoss) TemperatureChange(double waterTemperature, double volumeStream, double duration)
        {
            if (volumeStream == 0.0) return (waterTemperature,0.0);
            double waterVolume = Math.Abs(volumeStream * duration); // in m³
            double heatFlow = insulationLambda * 2.0 * Math.PI * length / (Math.Log(outerDiameter) - Math.Log(innerDiameter)) * (waterTemperature - (Plant.ZeroK + 10));
            // power of the heat flow from the water in the pipes to the surrounding soil [W]
            double energy = heatFlow * duration; // [J]
            double dt = energy / (waterVolume * 4200000); // J / (m³*J/(m³*K)) = J * m³ * K/ (m³*J) = K, heat capacity of water: 4200000 J/(m³*K)
            return (waterTemperature - dt, energy); // in case of waterTempereature<10°C dt will be negative
        }
    }
}
