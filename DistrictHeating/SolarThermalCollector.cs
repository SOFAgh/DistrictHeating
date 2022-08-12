using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistrictHeating
{
    // Calculate sun direction from date and time: http://www.geoastro.de/SME/tk/index.htm

    internal class SolarThermalCollector : IProsumer
    {
        public double Area { get; set; } // the area on the ground of the solar collector. This is not the sum of the panels area, which are inclined and less.
        public void Step(out double volumeFlow, out double flowTemperature, out Pipe fromPipe, out Pipe toPipe, out double electricity)
        {   // test implementation
            volumeFlow = 1; // [l/s]
            flowTemperature = 353; // [°K]
            fromPipe = Pipe.returnPipe;
            if (DistrictHeating.plant.UseThreePipes) toPipe = Pipe.hotPipe;
            else toPipe = Pipe.warmPipe;
            electricity = 0;
        }
    }
}
