using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistrictHeating
{
    public interface IProsumer
    {
        void Initialize(Plant plant);
        void EnergyFlow(Plant plant, out double volumetricFlowRate, out double deltaT, out Pipe fromPipe, out Pipe toPipe, out double electricPower);
    }
}
