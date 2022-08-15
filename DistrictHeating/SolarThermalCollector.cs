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
            
        }
        public void Step(Plant plant, out double volumetricFlowRate, out double deltaT, out Pipe fromPipe, out Pipe toPipe, out double electricPower)
        {   // test implementation
            volumetricFlowRate = 1; // [m³/s]
            deltaT = 60; // [°K]
            fromPipe = Pipe.returnPipe;
            if (plant.UseThreePipes) toPipe = Pipe.hotPipe;
            else toPipe = Pipe.warmPipe;
            electricPower = 0;
        }
    }
}
