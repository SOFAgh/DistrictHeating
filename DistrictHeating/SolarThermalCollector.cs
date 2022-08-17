using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistrictHeating
{
    // Calculate sun direction from date and time: http://www.geoastro.de/SME/tk/index.htm

    public class SolarThermalCollector : IProsumer
    {
        public double Area { get; set; } // the area on the ground of the solar collector. This is not the sum of the panels area, which are inclined and less.
        public void Initialize(Plant plant)
        {
            double globalSolarRadiation = 0.0;
            double diffuseSolarRadiation = 0.0;
            for (int hour = 0; hour < Plant.HoursPerYear; hour++)
            {
                globalSolarRadiation += plant.Climate.GlobalSolarRadiation[hour];
                diffuseSolarRadiation += plant.Climate.DiffuseRadiation[hour];
            }
            // data is in J/cm², /3600: s->h, *10000: cm²->m²; / 1000: Wh->kWh
            double kWhPerSquareMeter = globalSolarRadiation / 3600 * 10000 / 1000;
        }
        public void EnergyFlow(Plant plant, out double volumetricFlowRate, out double deltaT, out Pipe fromPipe, out Pipe toPipe, out double electricPower)
        {
            double ambientTempDiff = plant.GetCurrentTemperature() + Plant.ZeroK - plant.returnPipeTemp;
            // double efficiency = Math.Max(Math.Min((45 + ambientTempDiff), 65), 25) / 100; // efficiency between 25% and 65% depending on supply temperature versus ambient temperature
            double efficiency = 0.5; // fixed efficiency, would need more data for the above formula.
            double powerGenerated = efficiency * (plant.Climate.GlobalSolarRadiation[plant.CurrentHourIndex] - 0.2 * plant.Climate.DiffuseRadiation[plant.CurrentHourIndex]) / 3600 * 10000 * Area; // current power in W
            // reduction by the diffuse radiation and the efficiency factor of 0.5 are guesses to result in a energy production of about 400 kWh/(m²*a) 
            deltaT = 80 + Plant.ZeroK - plant.returnPipeTemp; // deltaT to yield an output of 80°C
            volumetricFlowRate = powerGenerated / (4200 * deltaT) / 1000; // "/ 1000": kg (water) -> m³
            fromPipe = Pipe.returnPipe;
            if (plant.UseThreePipes) toPipe = Pipe.hotPipe;
            else toPipe = Pipe.warmPipe;
            electricPower = 0.0;
        }
    }
}
