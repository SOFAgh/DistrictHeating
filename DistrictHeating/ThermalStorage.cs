using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistrictHeating
{
    internal class ThermalStorage
    {
        public double boreHoleLength; // length of a single borehole [m]. All boreholes have the same length.
        public double totalDiameter; // total diameter of the storage [m].
        public int numBoreHoles; // number of boreholes
        public double energyFlow; // in [W/(m*K)]
        public double heatCapacity; // heat capacity of the soil in [J/K]
    }
}
