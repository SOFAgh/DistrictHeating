using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistrictHeating
{
    internal class SolarThermalCollector : IProsumer
    {
        public void Step(out double volumeFlow, out double flowTemperature, out Pipe fromPipe, out Pipe toPipe)
        {   // test implementation
            volumeFlow = 1; // [l/s]
            flowTemperature = 353; // [°K]
            fromPipe = Pipe.returnPipe;
            if (Plant.useThreePipes) toPipe = Pipe.hotPipe;
            else toPipe = Pipe.warmPipe;
        }
    }
}
