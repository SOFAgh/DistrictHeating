using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DistrictHeating
{
    internal class HexSubdevision
    {
        readonly double sqrt3 = Math.Sqrt(3);
        readonly double sin30 = Math.Sin(Math.PI / 6.0);
        readonly double cos30 = Math.Cos(Math.PI / 6.0);
        private double[,] temperature;
        private int numRings; // from i, j to index in temperature
        double dist;
        double Length = 100; // hardcoded 100m borehole deepth
        double HeatCapacity;
        double TransferPower = 10; // hardcoded property for the heat exchange between pipe and soil, i.e. 50 W/m at deltaT 10K in W/(m*K)
        public HexSubdevision(double dist, int numRings, double initialTemperature)
        {
            this.numRings = numRings + 1; // one more ring, the outer hexagons are for heat transfer into the surrounding big hexagons
            temperature = new double[this.numRings * 2 + 1, this.numRings * 2 + 1];
            int numHexagons = numRings * (numRings + 1) / 2 * 6 + 1; // without the outer ring
            this.dist = dist / Math.Sqrt(numHexagons); // so that the sum of the area of all inner hexagons is equal to the area of the full hexagon
            for (int i = 0; i < this.numRings * 2 + 1; i++)
            {
                for (int j = 0; j < this.numRings * 2 + 1; j++)
                {
                    temperature[i, j] = initialTemperature;
                }
            }
        }
        public void Init(double initialTemperature, double centerTemperature)
        {
            for (int i = 0; i < numRings * 2 + 1; i++)
            {
                for (int j = 0; j < numRings * 2 + 1; j++)
                {
                    temperature[i, j] = initialTemperature;
                }
            }
            temperature[numRings, numRings] = centerTemperature;
        }
        private double temp(int i, int j)
        {
            return temperature[i + numRings, j + numRings];
        }
        /// <summary>
        ///  Returns the temperature for the provided index pair: if inside this set the value of the hexagon is returned
        ///  if outside, the value of the corresponding side is returned or the mean value of two adjacend sides
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="sides"></param>
        /// <returns></returns>
        private double temp(int i, int j, double[] sides)
        {
            double t = 0.0;
            int n = 0;
            if (i == -numRings - 1)
            {
                t += sides[0];
                ++n;
            }
            if (j == numRings + 1)
            {
                t += sides[1];
                ++n;
            }
            if (i + j == numRings + 1)
            {
                t += sides[2];
                ++n;
            }
            if (i == numRings + 1)
            {
                t += sides[3];
                ++n;
            }
            if (j == -numRings - 1)
            {
                t += sides[4];
                ++n;
            }
            if (i + j == -numRings - 1)
            {
                t += sides[5];
                ++n;
            }
            if (n > 0) return t / n;
            return temperature[i + numRings, j + numRings];
        }
        /// <summary>
        /// Returns an array of the temperature values at the provided <paramref name="side"/>.
        /// <paramref name="side"/> is in the range 0..5, where 0 is the lower right side, 1 the upper right, 2 the top and so on
        /// counterclockwise around the sides of the outer hexagon
        /// </summary>
        /// <param name="side"></param>
        /// <returns></returns>
        public double[] GetSide(int side)
        {
            System.Diagnostics.Debug.Assert(side >= 0 && side < 6);
            double[] res = new double[numRings + 1];
            switch (side)
            {
                case 0:
                    for (int i = 0; i < numRings + 1; i++)
                    {
                        res[i] = temp(-numRings, i);
                    }
                    break;
                case 1:
                    for (int i = 0; i < numRings + 1; i++)
                    {
                        res[i] = temp(i - numRings, numRings);
                    }
                    break;
                case 2:
                    for (int i = 0; i < numRings + 1; i++)
                    {
                        res[i] = temp(i, numRings - i);
                    }
                    break;
                case 3:
                    for (int i = 0; i < numRings + 1; i++)
                    {
                        res[i] = temp(-i, numRings);
                    }
                    break;
                case 4:
                    for (int i = 0; i < numRings + 1; i++)
                    {
                        res[i] = temp(numRings - i, -numRings);
                    }
                    break;
                case 5:
                    for (int i = 0; i < numRings + 1; i++)
                    {
                        res[i] = temp(-i, -numRings + i);
                    }
                    break;
            }
            return res;
        }
        /// <summary>
        ///  Advacnce one step of <paramref name="dt"/> seconds in the simulation. The temperatures of the adjacent sides are provided in 
        ///  the parameter <paramref name="sides"/> beginning with the lower right side counterclockwise
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="sides"></param>
        /// 
        public void Step(double Lambda, double HeatCapacity, double dt, double inTemperature, double flowRate, out double outTemperature)
        {
            this.HeatCapacity = HeatCapacity;
            double alpha = Lambda / HeatCapacity;
            // dt /= (numRings + 1); // we make more steps since the hexagon is also subdevided
            double cvg = alpha * dt / (dist * dist); // must be less than 0.25
            if (cvg > 0.2)
            {
                double ot = 0.0;
                Step(Lambda, HeatCapacity, dt / 2.0, inTemperature, flowRate, out ot);
                Step(Lambda, HeatCapacity, dt / 2.0, inTemperature, flowRate, out ot);
                outTemperature = ot;
                return;
            }
            double area = Math.Sqrt(3) * dist * dist / 2;
            outTemperature = inTemperature;
            if (flowRate != 0.0)
            {   // add or remove energy from the central hexagon

                double waterVolume = Math.Abs(flowRate * dt); // volume of the water pumped through the borehole in this time step, in m³. 
                double waterEnergy = inTemperature * waterVolume * 4200000; // energy of the water in J relative to 0 K,  4.2 kJ/(kg*K) or 4200000 J/(m³*K)
                double currentWaterTemperature = inTemperature; // will decrease (or increase) from borehole to borehole
                double heatCapacityPerHexPrism = area * HeatCapacity * Length; // volume * HeatCapacity in m³ * J/(m³*K) = J/K
                double deltaT = currentWaterTemperature - temp(0, 0); // temperature difference between the water in the borehole and the surrounding soil
                double power = deltaT * TransferPower * Length; // this is the power that will be transferred from the water to the HexPrism (positive or negative)
                double hexPrismEnergy = heatCapacityPerHexPrism * temp(0, 0); // current energy (J) of the HexPrism relative to absolute 0
                double energyToTransfer = power * dt;
                if (((waterEnergy - energyToTransfer) / (waterVolume * 4200000) - (hexPrismEnergy + energyToTransfer) / heatCapacityPerHexPrism) * deltaT < 0 ||
                    dt > 3600) // condition must be improved!
                {   // the energy which goes from the water to the soil (or vice versa) is too much. The soil would become hotter than the water,
                    // which is not possible. So we make smaller steps
                    double tm = (waterVolume * 4200000 * currentWaterTemperature + heatCapacityPerHexPrism * temp(0, 0)) / (waterVolume * 4200000 + heatCapacityPerHexPrism);
                    temperature[numRings, numRings] = tm;
                    outTemperature = tm;
                    // verify that the temperature tm is corret:
                    //energyToTransfer = heatCapacityPerHexPrism * tm - hexPrismEnergy;
                    //double dbgTempCnt = (hexPrismEnergy + energyToTransfer) / heatCapacityPerHexPrism;
                    //double dbgTempWater = (waterEnergy - energyToTransfer) / (waterVolume * 4200000);
                    return;
                }
                else
                {
                    hexPrismEnergy += energyToTransfer;
                    // now we modify the temperature of the hexagon so that the new prismEnergy represents hexPrismEnergy += energyToTransfer
                    temperature[numRings, numRings] = hexPrismEnergy / heatCapacityPerHexPrism; // the central hexagons new temperature
                    waterEnergy -= energyToTransfer;
                    outTemperature = waterEnergy / (waterVolume * 4200000); // the resulting water temperature
                }
            }
            double[,] newTemperature = new double[numRings * 2 + 1, numRings * 2 + 1];
            Parallel.For(-numRings, numRings + 1, i =>
            //for (int i = -numRings; i <= numRings; i++)
            {
                for (int j = -numRings; j <= numRings; j++)
                {
                    int k = -i - j;
                    if (Math.Abs(i) + Math.Abs(j) + Math.Abs(k) > (numRings + 1) * 2 - 1) continue;
                    // the hexagons at the border behave isolated, no energy transport to or from the outside in this step
                    double tsum = 0.0;
                    double tcenter = temp(i, j);
                    foreach ((int ii, int jj) in BoreHoleField.surrounding(i, j))
                    {
                        // first check, whether this surrounding hexagon is outside of the field
                        if (ii == -numRings - 1)
                        {
                            tsum += tcenter;
                        }
                        else if (jj == numRings + 1)
                        {
                            tsum += tcenter;
                        }
                        else if (ii + jj == numRings + 1)
                        {
                            tsum += tcenter;
                        }
                        else if (ii == numRings + 1)
                        {
                            tsum += tcenter;
                        }
                        else if (jj == -numRings - 1)
                        {
                            tsum += tcenter;
                        }
                        else if (ii + jj == -numRings - 1)
                        {
                            tsum += tcenter;
                        }
                        else tsum += temp(ii, jj); // normal case: hexagon is surrounded by 6 hexagons
                    }
                    newTemperature[i + numRings, j + numRings] = alpha * 2 / 3 * (tsum - 6 * tcenter) / (dist * dist) * dt + tcenter;
                }
            });
            temperature = newTemperature;
        }

        private (double x, double y) fromHexCoord(int i, int j, int k)
        {   // hexagons are oriented so that two of the edges are horizontal
            // the (smaller) y-diameter is dist, the (larger) x-diameter is dist*2/sqrt(3)
            // but in the subdevision everything is rotated 30° counterclockwise
            double yd = dist;
            double xd = yd * 2 / sqrt3;
            double l = xd / 2; // length of side of hexagon
            Debug.Assert(k == -i - j);
            double x = j * xd * 0.75;
            double y = (i + i + j) * yd / 2.0;
            return (x * cos30 - y * sin30, x * sin30 + y * cos30);
        }
        internal void WriteToCsvFile(StreamWriter outputFile)
        {
            for (int i = -numRings; i <= numRings; i++)
            {
                for (int j = -numRings; j <= numRings; j++)
                {
                    int k = -i - j;
                    if (Math.Abs(i) + Math.Abs(j) + Math.Abs(k) > (numRings + 1) * 2 - 1) continue; // outside the hexagon
                    (double x, double y) = fromHexCoord(i, j, k);
                    outputFile.WriteLine(x.ToString("F4", CultureInfo.InvariantCulture) + ", " + y.ToString("F4", CultureInfo.InvariantCulture) + ", " + temperature[i + numRings, j + numRings].ToString("F5", CultureInfo.InvariantCulture));
                }
            }
        }
        public void Connect(int side, ref double bigTemperature, double bigArea)
        {
            (int i, int j)[] indices = new (int i, int j)[numRings];
            switch (side)
            {
                case 0:
                    for (int k = 0; k < numRings; k++) indices[k] = (-numRings, k);
                    break;
                case 1:
                    for (int k = 0; k < numRings; k++) indices[k] = (-numRings + k, numRings);
                    break;
                case 2:
                    for (int k = 0; k < numRings; k++) indices[k] = (k, numRings - k);
                    break;
                case 3:
                    for (int k = 0; k < numRings; k++) indices[k] = (numRings, -k);
                    break;
                case 4:
                    for (int k = 0; k < numRings; k++) indices[k] = (numRings - k, -numRings);
                    break;
                case 5:
                    for (int k = 0; k < numRings; k++) indices[k] = (-k, -numRings + k);
                    break;
            }
            double area = Math.Sqrt(3) * dist * dist / 2;
            double ta = bigTemperature * bigArea;
            for (int k = 0; k < numRings; k++)
            {
                ta += temp(indices[k].i, indices[k].j) * area;
            }
            bigTemperature = ta / (bigArea + area * numRings);
            // this is the new temperature of both te big hexagon and the small hexagons which overlap with the big one
            for (int k = 0; k < numRings; k++)
            {
                temperature[numRings + indices[k].i, numRings + indices[k].j] = bigTemperature;
            }
        }

        internal double GetTotalEnergy(double baseTemperature)
        {
            double area = Math.Sqrt(3) * dist * dist / 2;
            double res = 0.0;
            // only the inner hexagons
            for (int i = -numRings + 1; i <= numRings - 1; i++)
            {
                for (int j = -numRings + 1; j <= numRings - 1; j++)
                {
                    int k = -i - j;
                    if (Math.Abs(i) + Math.Abs(j) + Math.Abs(k) > (numRings + 1) * 2 - 1) continue;
                    res += area * (temp(i, j) - baseTemperature);
                }
            }
            return res * Length * HeatCapacity;
        }
        internal double MeanTemperature
        {
            get
            {
                double t = 0.0;
                int n = 0;
                for (int i = -numRings + 1; i < numRings; i++)
                {
                    for (int j = -numRings + 1; j < numRings; j++)
                    {
                        int k = -i - j;
                        if (Math.Abs(i) + Math.Abs(j) + Math.Abs(k) > (numRings + 1) * 2 - 1) continue;
                        t += temp(i, j);
                        ++n;
                    }
                }
                return t / n;
            }
        }

        public double TotalEnergy
        {
            get
            {
                double sum = 0;
                double area = Math.Sqrt(3) * dist * dist / 2;
                for (int i = -numRings; i <= numRings; i++)
                {
                    for (int j = -numRings; j <= numRings; j++)
                    {
                        int k = -i - j;
                        if (Math.Abs(i) + Math.Abs(j) + Math.Abs(k) > (numRings + 1) * 2 - 1) continue;
                        sum += (temp(i, j) - 283.15) * area * Length * HeatCapacity; // relative to 0°C for more precision
                    }
                }
                return sum;
            }
        }
    }
}
