using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistrictHeating
{
    internal interface IProsumer
    {
        void Step(out double volumeFlow, out double flowTemperature, out Pipe fromPipe, out Pipe toPipe, out double electricity);
    }
}
