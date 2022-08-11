using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistrictHeating
{
    internal class ThermalStorage
    {
        // It is currently assumed that the boreholes are arranged in a hexagonal pattern. There is a
        // central borehole, surrounded by 6 cells in the first ring, surrounded by 12 cells in the second ring etc.
        // parameters:
        public readonly double boreHoleLength; // length of a single borehole [m]. All boreholes have the same length.
        public readonly double boreHoleDistance; // distance of neighbouring boreholes[m]. 
        public readonly int numBoreholeRings; // number of borehole rings. 
        public readonly double energyFlow; // in [W/(m*K)]
        public readonly double heatCapacity; // heat capacity of the soil in [J/K]
        public readonly double pipeInnerDiameter; // inner diameter of the pipe containing the water
        // dependant parameters:
        public double totalDiameter; // total diameter of the storage [m].
        public int numBoreHoles; // number of boreholes
        /// <summary>
        /// Volume of the hexagonal prisma, which surrounds the borehole
        /// </summary>
        public double cellVolume { get; private set; } // volume of the hexagonal prisma, which surrounds the borehole
        /// <summary>
        /// Volume of the water inside the borehole (two pipes connected by a U-fitting)
        /// </summary>
        public double waterVolume { get { return pipeInnerDiameter * pipeInnerDiameter / 4.0 * Math.PI * boreHoleLength * 2.0; } } 
        // status:
        public double[] cellSoilTemperature; // [K], this should in a leter versionn be splitted into 7 areas: 6 trapezoids and a inner hexagon
        public double[] cellWaterTemperature; // [K]
    }
}
