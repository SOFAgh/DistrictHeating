﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace DistrictHeating
{
    public class BoreHoleFieldOld
    {
        /// <summary>
        /// This class describes a hexagonal prism, which is the finite element for the simulation.
        /// </summary>
        private class HexagonPrism
        {
            public HexagonPrism(double t, int i, int j, int k)
            {
                this.t = t;
                this.dt = 0.0;
                connectedHexPrisms = new List<HexagonPrism>();
                this.i = i;
                this.j = j;
                this.k = k;
                ts = new double[1]; // normally a single value for the temperature, should later replace t. Multiple values for prisms with boreholes
                dts = new double[1]; // normally a single value, should later replace dt. Multiple values for prisms with boreholes
            }
            public double t; // the temperature
            public double dt; // the temperature difference, which is added after all hexagonal prism have been modified
            public int i, j, k; // the "coordinate" of this hexagon
            public List<HexagonPrism> connectedHexPrisms; // the neighbours
            public double[] dts; // one value for inner hexagonal prisms, multiple values for the hexagonal conentric rings of prisms with boreholes inside
            public double[] ts; // temperature: one value for inner hexagonal prisms, multiple values for the hexagonal conentric rings of prisms with boreholes inside
        }
        /// <summary>
        /// This class describes a mantle around the field of hexagonal prisms. It has the form of a hexagonal shell.
        /// Each mantle can be surrounded by a bigger mantle, the next shell. The deepth (length, height) of the mantle is the same for all
        /// and specified with the BoreHoleField.Length
        /// </summary>
        private class Mantle
        {
            public Mantle(double t, double innerRadius, double outerRadius)
            {
                this.t = t;
                this.dt = 0.0;
                this.innerRadius = innerRadius;
                this.outerRadius = outerRadius;
            }
            public double innerRadius; // radius of the inner hexagon, same as side length
            public double outerRadius; // radius of the outer hexagon, same as side length
            public double t; // the temperature
            public double dt; // the temperature difference, which is added after all hexagonal prism have been modified
            public double Area
            {
                get
                {
                    return 3.0 * Math.Sqrt(3) / 2.0 * (outerRadius * outerRadius - innerRadius * innerRadius);
                }
            }
            public double Thickness
            {
                get
                {
                    return outerRadius - innerRadius;
                }
            }
        }
        private double distance = 5;
        /// <summary>
        /// Distance between boreholes
        /// </summary>
        public double BoreHoleDistance
        {
            get { return distance; }
            set
            {
                distance = value;
            }
        }
        public int Grid
        {
            get { return grid; }
            set { grid = value; }
        }
        /// <summary>
        /// The distance between the centers of two hexagons, which have a common side or edge. 
        /// Is also the the smaller diameter of the hexagon.
        /// </summary>
        public double HexagonDistance
        {
            get { return distance / grid; }
        }
        double FaceArea
        {
            get
            {
                double l = distance / grid / Math.Sqrt(3.0); // length of side of hexagon
                return l * Length;
            }
        }
        public double HexagonArea
        {
            get
            {
                return (distance / grid) * (distance / grid) * Math.Sqrt(3.0) / 2.0;
            }
        }
        /// <summary>
        /// Length of the boreholes
        /// </summary>
        public double Length = 100;
        /// <summary>
        /// Volume of the water in the heat exchanging pipes
        /// </summary>
        public double PipeVolume { get; set; }
        /// <summary>
        /// Temperature of the undisturbed soil surrounding the borehole field
        /// </summary>
        public double AmbientTemperature { get; set; }
        /// <summary>
        /// Thermal conductivity in W/(m*K)
        /// </summary>
        public double Lambda = 2.3; // in W/(m*K) Sandstein Wikipedia
        /// <summary>
        /// Heat capacity in j/(m³*K)
        /// </summary>
        public double HeatCapacity = 700 * 2200; // J/(m³*K), Sandstein https://www.schweizer-fn.de/stoff/wkapazitaet/wkapazitaet_baustoff_erde.php
        public int NumberOfBoreHoles { get { return boreHoles.Count; } }
        /// <summary>
        /// The power (W) which will be transferred at a given temperature difference between the water in the pipe and the soil in W/K
        /// </summary>
        public double TransferPower { get; set; } = 5; // i.e. 50 W/m at deltaT 10K in W/(m*K)
        /// <summary>
        /// Start temperature in the center for the simulation
        /// </summary>
        public double startBoreholeFieldCenterTemperature = 10 + 273.15;
        /// <summary>
        /// Start temperature at the border for the simulation
        /// </summary>
        public double startBoreholeFieldBorderTemperature = 10 + 273.15;

        // internal representation of the field
        private Dictionary<Tuple<int, int, int>, HexagonPrism> temperatureAtHexCoord = new Dictionary<Tuple<int, int, int>, HexagonPrism>();
        private List<HexagonPrism> boreHoles = new List<HexagonPrism>();
        private List<HexagonPrism> borderPrisms = new List<HexagonPrism>();
        private List<Mantle> mantles = new List<Mantle>();
        private int grid = 6; // the grid segments between boreholes
        private int numRings;
        private double triangleArea;
        private double borderTemperature; // the mean temperature of a ring surrounding the field. Used to calculate the energy loss.
        private int numberOfBorderFaces; // number of points on the border
        private int maxHexCoordinate;
        private double size; // the distance of the most outside hexagon from the center (for grapfics display)
        public BoreHoleFieldOld(int numRings, double initialTemperature)
        {
            maxHexCoordinate = 0;
            size = 0;
            triangleArea = (distance / grid) * (distance / grid) * Math.Sqrt(3.0) / 4.0;
            this.numRings = numRings;

            // 1. create the hexagonal array of temperature points
            int dbgmaxi = 0;
            for (int i = -(numRings + 1) * 2 * grid; i <= (numRings + 1) * 2 * grid; i++)
            {
                for (int j = -(numRings + 1) * 2 * grid; j <= (numRings + 1) * 2 * grid; j++)
                {
                    int k = -i - j;
                    if (Math.Abs(i) + Math.Abs(j) + Math.Abs(k) > (numRings + 1) * 2 * grid - 1) continue; // outside the hexagon
                    (double x, double y) p1 = fromHexCoord(i, j, k);
                    size = Math.Max(size, p1.y);
                    HexagonPrism tpijk = new HexagonPrism(initialTemperature, i, j, k);
                    temperatureAtHexCoord[new Tuple<int, int, int>(i, j, k)] = tpijk;
                    maxHexCoordinate = Math.Max(Math.Max(maxHexCoordinate, Math.Abs(i)), Math.Max(Math.Abs(j), Math.Abs(k)));
                    if (Math.Abs(i) + Math.Abs(j) + Math.Abs(k) > (numRings + 1) * 2 * grid - 1) continue; // outside the hexagon
                    if ((Math.Abs(i) + Math.Abs(k)) % grid == 0 && (Math.Abs(i) + Math.Abs(j)) % grid == 0 && (Math.Abs(j) + Math.Abs(k)) % grid == 0)
                    {   // there are (grid-1) temperature points points in between the boreholes
                        boreHoles.Add(tpijk);
                        if (i > dbgmaxi) dbgmaxi = i;
                    }
                }
            }
            borderTemperature = initialTemperature;

            //(double x, double y) p1 = fromHexCoord(0, dbgmaxi, -dbgmaxi);
            //(double x, double y) p2 = fromHexCoord(0, -dbgmaxi, dbgmaxi);

            // sort the boreholes from inside out and counterclockwise
            boreHoles.Sort(delegate (HexagonPrism t1, HexagonPrism t2)
            {
                int c = (Math.Abs(t1.i) + Math.Abs(t1.j) + Math.Abs(t1.k)).CompareTo(Math.Abs(t2.i) + Math.Abs(t2.j) + Math.Abs(t2.k));
                if (c != 0) return c;
                (double x, double y) a = fromHexCoord(t1.i, t1.j, t1.k);
                (double x, double y) b = fromHexCoord(t2.i, t2.j, t2.k);
                return Math.Atan2(a.y, a.x).CompareTo(Math.Atan2(b.y, b.x));
            });
            foreach (KeyValuePair<Tuple<int, int, int>, HexagonPrism> item in temperatureAtHexCoord)
            {
                int i = item.Key.Item1;
                int j = item.Key.Item2;
                int k = item.Key.Item3;
                HexagonPrism? tp;
                if (temperatureAtHexCoord.TryGetValue(new Tuple<int, int, int>(i, j - 1, k + 1), out tp))
                {
                    item.Value.connectedHexPrisms.Add(tp);
                }
                if (temperatureAtHexCoord.TryGetValue(new Tuple<int, int, int>(i - 1, j, k + 1), out tp))
                {
                    item.Value.connectedHexPrisms.Add(tp);
                }
                if (temperatureAtHexCoord.TryGetValue(new Tuple<int, int, int>(i - 1, j + 1, k), out tp))
                {
                    item.Value.connectedHexPrisms.Add(tp);
                }
                if (temperatureAtHexCoord.TryGetValue(new Tuple<int, int, int>(i, j + 1, k - 1), out tp))
                {
                    item.Value.connectedHexPrisms.Add(tp);
                }
                if (temperatureAtHexCoord.TryGetValue(new Tuple<int, int, int>(i + 1, j, k - 1), out tp))
                {
                    item.Value.connectedHexPrisms.Add(tp);
                }
                if (temperatureAtHexCoord.TryGetValue(new Tuple<int, int, int>(i + 1, j - 1, k), out tp))
                {
                    item.Value.connectedHexPrisms.Add(tp);
                }
                numberOfBorderFaces += 6 - item.Value.connectedHexPrisms.Count;
                if (numberOfBorderFaces < 6) borderPrisms.Add(item.Value); // this is a prism at the outside of the field
            }
            double width = HexagonDistance;
            double innerRadius = size + HexagonDistance / 2.0;
            for (int i = 0; i < 10; i++)
            {   // we assume a certain amount of mantles, starting with the inner Mantle. Each following has the double width
                // as the next inner mantle
                mantles.Add(new Mantle(initialTemperature, innerRadius, innerRadius + width));
                innerRadius += width;
                width *= 2.0;
            }

        }
        private (double x, double y) fromHexCoord(int i, int j, int k)
        {   // hexagons are oriented so that two of the edges are horizontal
            // the (smaller) y-diameter is distance / grid, the (bigger) x-diameter is distance/grid*2/sqrt(3)
            double yd = distance / grid;
            double xd = yd * 2 / Math.Sqrt(3.0);
            double l = xd / 2; // length of side of hexagon
            Debug.Assert(i + j + k == 0);
            double x = j * xd * 0.75;
            double y = (i - k) * yd / 2.0;
            return (x, y);
        }
        /// <summary>
        /// Sets a linear temperature field from the center to the border. Used to initialize a certain state
        /// </summary>
        /// <param name="centerTemperature"></param>
        /// <param name="borderTemperature"></param>
        public void Initialize()
        {
            Parallel.ForEach(temperatureAtHexCoord.Keys, (Tuple<int, int, int> key) =>
            {
                int c = Math.Max(Math.Max(Math.Abs(key.Item1), Math.Abs(key.Item2)), Math.Abs(key.Item3));
                HexagonPrism itemValue = temperatureAtHexCoord[key];
                double f = (maxHexCoordinate - c) / (double)maxHexCoordinate; // 1: center, 0: border
                itemValue.t = startBoreholeFieldBorderTemperature + f * (startBoreholeFieldCenterTemperature - startBoreholeFieldBorderTemperature);
            });
        }
        private IEnumerable<Tuple<int, int, int>> shell(Tuple<int, int, int> loc, int orbit)
        {
            int x = loc.Item1 + orbit;
            int y = loc.Item2 - orbit;
            int z = loc.Item3;
            yield return Tuple.Create(x, y, z);
            for (int i = 0; i < orbit; i++)
            {
                y += 1;
                z -= 1;
                yield return Tuple.Create(x, y, z);
            }
            for (int i = 0; i < orbit; i++)
            {
                x -= 1;
                y += 1;
                yield return Tuple.Create(x, y, z);
            }
            for (int i = 0; i < orbit; i++)
            {
                x -= 1;
                z += 1;
                yield return Tuple.Create(x, y, z);
            }
            for (int i = 0; i < orbit; i++)
            {
                y -= 1;
                z += 1;
                yield return Tuple.Create(x, y, z);
            }
            for (int i = 0; i < orbit; i++)
            {
                x += 1;
                y -= 1;
                yield return Tuple.Create(x, y, z);
            }
            for (int i = 0; i < orbit; i++)
            {
                x += 1;
                z -= 1;
                yield return Tuple.Create(x, y, z);
            }
        }
        /// <summary>
        /// Trensfers energy from or to the borehole field
        /// </summary>
        /// <param name="volumeStream">the volume stream [m³/s]. positive: into the center, negative into the outer ring</param>
        /// <param name="inTemperature">the temperature [K] of the water flowing into the storage</param>
        /// <param name="outTemperature">the temperature [K] leaving the storage</param>
        /// <param name="duration">duration of the transfer [s]</param>
        public void TransferEnergie(double volumeStream, double inTemperature, out double outTemperature, double duration)
        {
            double waterVolume = Math.Abs(volumeStream * duration); // in m³
            double waterEnergy = inTemperature * waterVolume * 4200000; // in J relative to 0 K,  4.2 kJ/(kg*K) or 4200000 J/(m³*K)
            double currentWaterTemperature = inTemperature; // will decrease (or increase) from borehole to borehole
            double heatCapacityPerHexPrism = HexagonArea * HeatCapacity * Length; // to get the energy you have to multiply by deltaT
            if (volumeStream != 0.0)
            {
                for (int i = 0; i < boreHoles.Count; i++)
                {   // we assume all the water to stay in each borehole for the provided duration. It will be cooled (or heated) by the power (deltaT * TransferPower * Length)
                    // then we pass it on to the next borehole
                    int index = (volumeStream < 0) ? boreHoles.Count - i - 1 : i; // respecting direction of flow, from center to outside or reverse
                    double deltaT = currentWaterTemperature - boreHoles[index].t;
                    double power = deltaT * TransferPower * Length; // this is the power that will be transferred from the water to the HexPrism (positive or negative)
                    double hexPrismEnergy = heatCapacityPerHexPrism * boreHoles[index].t; // current energy of the HexPrism relative to absolute 0
                    double energyToTransfer = power * duration;
                    if (((waterEnergy - energyToTransfer) / (waterVolume * 4200000) - (hexPrismEnergy + energyToTransfer) / heatCapacityPerHexPrism) * deltaT < 0)
                    {   // with this amount of energyToTransfer we would overshoot the temperatures. Soe we calculate the amount of energy
                        // which results in a medium temperature, which both the water and the soil will get
                        double tm = (waterVolume * 4200000 * currentWaterTemperature + heatCapacityPerHexPrism * boreHoles[index].t) / (waterVolume * 4200000 + heatCapacityPerHexPrism);
                        energyToTransfer = heatCapacityPerHexPrism * tm - hexPrismEnergy;
                        // double dbg = (waterVolume * 4200000 * currentWaterTemperature) - (waterVolume * 4200000 * tm); // must be the same as energyToTransfer
                    }
                    hexPrismEnergy += energyToTransfer;
                    // now we modify the temperature of the hexagon so that the new prismEnergy represents hexPrismEnergy += energyToTransfer
                    boreHoles[index].t = hexPrismEnergy / heatCapacityPerHexPrism;
                    waterEnergy -= energyToTransfer;
                    currentWaterTemperature = waterEnergy / (waterVolume * 4200000);
                    // if ((currentWaterTemperature - boreHoles[index].t) * deltaT < 0) { }
                }
            }
            outTemperature = currentWaterTemperature; // this is the last water temperature afte leaving the last borehole
            // now we need to adapt each temperature point by the influence of its neighbours
            // in a first loop we keep the temperatures unchanged and calculate the deltaT for each point
            // in a second loop, we add deltaT to the temperature of each point
            double borderdt = 0.0;
            double capacity = Lambda * FaceArea * duration / HexagonDistance;
            double f = capacity / heatCapacityPerHexPrism;
            // Q = k * A * (T1 - T2) * t / d
            // where:
            // Q is the energy transferred(in Joules)
            // k is the thermal conductivity(in W / (m * K))
            // A is the area of the contacting faces(in m²)
            // T1 and T2 are the temperatures of the two adjacent hexagonal prisms(in K)
            // t is the duration of the time step(in seconds)
            // d is the distance between the center axis of the two hexagonal prisms(in meters)
            // foreach (Tuple<int,int,int> key in temperatureAtHexCoord.Keys) // seriel to debug
            Parallel.ForEach(temperatureAtHexCoord.Keys, (Tuple<int, int, int> key) =>
            {
                double dt = 0.0;
                HexagonPrism itemValue = temperatureAtHexCoord[key];
                double t0 = itemValue.t;

                double ff = 0.5;
                for (int i = 1; i < grid / 2 + 1; i++)
                {
                    foreach (Tuple<int, int, int> item in shell(key, i))
                    {
                        if (temperatureAtHexCoord.TryGetValue(item, out HexagonPrism? found))
                        {
                            dt += f * ff * (found.t - t0);
                        }
                        else
                        {
                            int outside = (Math.Abs(item.Item1) + Math.Abs(item.Item2) + Math.Abs(item.Item3) - ((numRings + 1) * 2 * grid - 1));
                        }
                    }
                    ff = 0.5 * ff;
                }

                //int cnt = itemValue.connectedHexPrisms.Count;
                //// here we assume that all points have the same distance and are regularly distributed around the central point (in 60° steps)
                //for (int l = 0; l < cnt; l++)
                //{
                //    dt += f * (itemValue.connectedHexPrisms[l].t - t0);
                //}
                //if (cnt < 6)
                //{
                //    dt += f * (mantles[0].t - t0); // an outer prism is also affected by the surrounding mantle
                //    mantles[0].dt += (6 - cnt) * capacity / (mantles[0].Area * HeatCapacity * Length) * (t0 - mantles[0].t);
                //    // the mantle beeing affected by this prism, capacity already respects one face area of the prism, but we have two or 3 faces as contact here
                //    // The HexagonDistance in capacity is correct, since the first mantle has this thickness
                //}
                itemValue.dt = dt; // save this value, the modification happens for all points simultaneously after this loop

            });
            // now update the mantle temperature changes (dt)
            // the innermost mantle has already been affected byt 
            for (int i = 0; i < mantles.Count; i++)
            {
                if (i > 0)
                {   // what we get from the next inner mantle
                    double contactArea = mantles[i].innerRadius * 6 * Length;
                    double distance = (mantles[i].Thickness + mantles[i - 1].Thickness) / 2.0;
                    double ff = Lambda * contactArea * duration / distance / (mantles[i].Area * HeatCapacity * Length);
                    mantles[i].dt += ff * (mantles[i - 1].t - mantles[i].t);
                }
                if (i < mantles.Count - 1)
                {   // what we get from the next outer mantle
                    double contactArea = mantles[i].outerRadius * 6 * Length;
                    double distance = (mantles[i].Thickness + mantles[i + 1].Thickness) / 2.0;
                    double ff = Lambda * contactArea * duration / distance / (mantles[i].Area * HeatCapacity * Length);
                    mantles[i].dt += ff * (mantles[i + 1].t - mantles[i].t);
                }
            }
            // now we change all temperatures
            borderTemperature -= borderdt;
            Parallel.ForEach(temperatureAtHexCoord.Keys, (Tuple<int, int, int> key) =>
            {
                HexagonPrism itemValue = temperatureAtHexCoord[key];
                itemValue.t += itemValue.dt;
                itemValue.dt = 0;
            });
            for (int i = 0; i < mantles.Count; i++)
            {
                mantles[i].t += mantles[i].dt;
                mantles[i].dt = 0.0;
            }
        }
        public double GetTotalEnergy(double baseTemperature)
        {
            double res = 0.0;
            foreach (KeyValuePair<Tuple<int, int, int>, HexagonPrism> item in temperatureAtHexCoord)
            {
                res += HexagonArea * (item.Value.t - baseTemperature);
            }
            return res * Length * HeatCapacity;
        }
        /// <summary>
        ///  Dumps the values to a text file in a simple csv format
        /// </summary>
        public void Dump(string filename)
        {
            double mintemp = double.MaxValue;
            double maxtemp = double.MinValue;
            using (FileStream fs = new FileStream(@"F:BoreHoleThermalHeatStorage\" + filename + ".txt", FileMode.OpenOrCreate))
            {
                Dictionary<Tuple<int, int, int>, int> hexIndexToLinearIndex = new Dictionary<Tuple<int, int, int>, int>();
                int counter = 0;
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    foreach (KeyValuePair<Tuple<int, int, int>, HexagonPrism> item in temperatureAtHexCoord)
                    {
                        hexIndexToLinearIndex[item.Key] = counter++;
                        (double x, double y) = fromHexCoord(item.Key.Item1, item.Key.Item2, item.Key.Item3);
                        sw.WriteLine(x.ToString(CultureInfo.InvariantCulture) + ", " + y.ToString(CultureInfo.InvariantCulture) + ", " + item.Value.t.ToString(CultureInfo.InvariantCulture));
                        if (item.Value.t > maxtemp) maxtemp = item.Value.t;
                        if (item.Value.t < mintemp) mintemp = item.Value.t;
                    }
                    sw.WriteLine(""); // the triangle indices:
                    foreach (KeyValuePair<Tuple<int, int, int>, HexagonPrism> item in temperatureAtHexCoord)
                    {
                        int i = item.Key.Item1;
                        int j = item.Key.Item2;
                        int k = item.Key.Item3;
                        int index0 = hexIndexToLinearIndex[new Tuple<int, int, int>(i, j, k)];
                        if (temperatureAtHexCoord.ContainsKey(new Tuple<int, int, int>(i, j - 1, k + 1)) && temperatureAtHexCoord.ContainsKey(new Tuple<int, int, int>(i - 1, j, k + 1)))
                        {
                            int index1 = hexIndexToLinearIndex[new Tuple<int, int, int>(i, j - 1, k + 1)];
                            int index2 = hexIndexToLinearIndex[new Tuple<int, int, int>(i - 1, j, k + 1)];
                            sw.WriteLine(index0.ToString() + ", " + index1.ToString() + ", " + index2.ToString());
                        }
                        if (temperatureAtHexCoord.ContainsKey(new Tuple<int, int, int>(i, j - 1, k + 1)) && temperatureAtHexCoord.ContainsKey(new Tuple<int, int, int>(i + 1, j - 1, k)))
                        {
                            int index1 = hexIndexToLinearIndex[new Tuple<int, int, int>(i, j - 1, k + 1)];
                            int index2 = hexIndexToLinearIndex[new Tuple<int, int, int>(i + 1, j - 1, k)];
                            sw.WriteLine(index0.ToString() + ", " + index1.ToString() + ", " + index2.ToString());
                        }
                    }
                    sw.Close();
                }
                fs.Close();
            }
        }
        public double CompareWith(BoreHoleFieldOld other)
        {
            double maxdist = 0.0;
            double maxTemp = 0.0, minTemp = double.MaxValue;
            double res = 0.0;
            foreach (KeyValuePair<Tuple<int, int, int>, HexagonPrism> item in temperatureAtHexCoord)
            {
                int i = item.Key.Item1;
                int j = item.Key.Item2;
                int k = item.Key.Item3;
                if (item.Value.t > maxTemp) maxTemp = item.Value.t;
                if (item.Value.t < minTemp) minTemp = item.Value.t;
                double d = Math.Abs(other.temperatureAtHexCoord[new Tuple<int, int, int>(i, j, k)].t - item.Value.t);
                if (d > maxdist) maxdist = d;
                res += d;
            }
            return res / temperatureAtHexCoord.Count;
        }
        public double GetTemperatureAt(int i, int j, int k)
        {
            return temperatureAtHexCoord[new Tuple<int, int, int>(i, j, k)].t;
        }
        public double GetTotalEnergy(double baseTemperature, int outside)
        {
            double volume = 0.0;
            double dbgTotalArea = 0.0;
            foreach (KeyValuePair<Tuple<int, int, int>, HexagonPrism> item in temperatureAtHexCoord)
            {
                int i = item.Key.Item1;
                int j = item.Key.Item2;
                int k = item.Key.Item3;
                if (Math.Abs(i) + Math.Abs(k) + Math.Abs(k) > outside)
                {
                    HexagonPrism? t1, t2;
                    if (temperatureAtHexCoord.TryGetValue(new Tuple<int, int, int>(i, j - 1, k + 1), out t1) && temperatureAtHexCoord.TryGetValue(new Tuple<int, int, int>(i - 1, j, k + 1), out t2))
                    {
                        volume += triangleArea * ((item.Value.t + t1.t + t2.t) / 3 - baseTemperature);
                        dbgTotalArea += triangleArea;
                    }
                    if (temperatureAtHexCoord.TryGetValue(new Tuple<int, int, int>(i, j - 1, k + 1), out t1) && temperatureAtHexCoord.TryGetValue(new Tuple<int, int, int>(i + 1, j - 1, k), out t2))
                    {
                        volume += triangleArea * ((item.Value.t + t1.t + t2.t) / 3 - baseTemperature);
                        dbgTotalArea += triangleArea;
                    }
                }
            }
            return volume * HeatCapacity * Length;
        }

        internal double GetColdEndTemperature(int ringNumber)
        {
            // no rings yet
            return boreHoles[boreHoles.Count - 1].t;
        }
        internal double GetHotEndTemperature(int ringNumber)
        {
            // no rings yet
            return boreHoles[0].t;
        }

        internal void Paint(Panel? panel)
        {
            if (panel == null) return;
            using (Graphics gr = panel.CreateGraphics())
            {
                gr.Clear(Color.White);
                int cntx = panel.Width / 2;
                int cnty = panel.Height / 2;
                double scaleFactor = Math.Min(panel.Width, panel.Height) / 2 / size;
                foreach (Tuple<int, int, int> pnt in temperatureAtHexCoord.Keys)
                {
                    (double x, double y) = fromHexCoord(pnt.Item1, pnt.Item2, pnt.Item3);
                    gr.DrawEllipse(Pens.Black, cntx + (float)(scaleFactor * x) - 2, cnty + (float)(scaleFactor * y) - 2, 4, 4);
                    // gr.DrawLine(Pens.Black, cntx + (float)(scaleFactor * x), cnty + (float)(scaleFactor * y), cntx + (float)(scaleFactor * x)+1, cnty + (float)(scaleFactor * y));
                }
                foreach (HexagonPrism tp in boreHoles)
                {
                    (double x, double y) = fromHexCoord(tp.i, tp.j, tp.k);
                    gr.FillEllipse(Brushes.Red, cntx + (float)(scaleFactor * x) - 3, cnty + (float)(scaleFactor * y) - 3, 6, 6);
                }

            }
        }
        internal void InitializeNew(int n)
        {
            Parallel.ForEach(temperatureAtHexCoord.Keys, (Tuple<int, int, int> key) =>
            {
                int c = Math.Max(Math.Max(Math.Abs(key.Item1), Math.Abs(key.Item2)), Math.Abs(key.Item3));
                HexagonPrism itemValue = temperatureAtHexCoord[key];
                double f = (maxHexCoordinate - c) / (double)maxHexCoordinate; // 1: center, 0: border
                itemValue.ts[0] = startBoreholeFieldBorderTemperature + f * (startBoreholeFieldCenterTemperature - startBoreholeFieldBorderTemperature);
            });
            // hier später alle boreholes
            HexagonPrism centerPrism = temperatureAtHexCoord[new Tuple<int, int, int>(0, 0, 0)];
            centerPrism.dts = new double[n];
            centerPrism.ts = new double[n];
            for (int i = 0; i < centerPrism.dts.Length; i++)
            {
                centerPrism.ts[i] = centerPrism.t;
            }
        }

        public void SomeDebugCode()
        {
            const int len = 81; // must be odd to have a center
            double[,] T = new double[len, len];
            double[,] dT = new double[len, len];
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    T[i, j] = 283.15; // all elements at 10°
                    dT[i, j] = 0.0;
                }
            }
            T[(len - 1) / 2, (len - 1) / 2] = 303.15; // the center element at 30°
            /*
                Δt: time step
                T(x,y,t): temperature at grid point and current time
                d, Δx, Δy: grid step, equal value
                α: thermal diffusivity, Lambda/HeatCapacity
                (T(x,y,t+Δt)−T(x,y,t))/Δt =α( T(x+Δx,y,t)−2T(x,y,t)+T(x−Δx,y,t) + T(x,y+Δy,t)−2T(x,y,t)+T(x,y−Δy,t) )/d² //finite difference method
                T(x,y,t+Δt)=α( T(x+Δx,y,t)−2T(x,y,t)+T(x−Δx,y,t) + T(x,y+Δy,t)−2T(x,y,t)+T(x,y−Δy,t) )/d²* Δt + T(x,y,t) 
                dT = α * (T(x+Δx,y,t)−2T(x,y,t)+T(x−Δx,y,t) + T(x,y+Δy,t)−2T(x,y,t)+T(x,y−Δy,t))/d² * Δt
                dT = α * (T(x+Δx,y,t) + T(x−Δx,y,t) + T(x,y+Δy,t) + T(x,y−Δy,t) − 4T(x,y,t))/d² * Δt
                dT = α * (T[i+1,j] + T[i-1,j] + T[i,j+1] + T[i,j-1] − 4*T[i,j])/d² * Δt
             */
            double d = 1.0; // grid distanc 1m
            double alpha = Lambda / HeatCapacity;
            double timeStep = 3600; // seconds

            double totEnergy = 0.0;
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    totEnergy += (T[i, j] - 283.15) * d * d;
                }
            }
            totEnergy *= Length * HeatCapacity;

            for (int k = 0; k < 1000; k++)
            {
                for (int i = 0; i < len; i++)
                {
                    for (int j = 0; j < len; j++)
                    {
                        double n1 = 283.15;
                        double n2 = 283.15;
                        double n3 = 283.15;
                        double n4 = 283.15;
                        if (i > 0) n1 = T[i - 1, j];
                        if (i < len - 1) n2 = T[i + 1, j];
                        if (j > 0) n3 = T[i, j - 1];
                        if (j < len - 1) n4 = T[i, j + 1];
                        dT[i, j] = alpha * (n1 + n2 + n3 + n4 - 4 * T[i, j]) / (d * d) * timeStep;
                    }
                }
                for (int i = 0; i < len; i++)
                {
                    for (int j = 0; j < len; j++)
                    {
                        T[i, j] += dT[i, j];
                        dT[i, j] = 0.0;
                    }
                }
            }

            totEnergy = 0.0;
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    totEnergy += (T[i, j] - 283.15) * d * d;
                }
            }
            totEnergy *= Length * HeatCapacity;

        }
        public void TransferEnergieTest(double volumeStream, double inTemperature, out double outTemperature, double duration)
        {
            // return (distance / grid) * (distance / grid) * Math.Sqrt(3.0) / 2.0;
            double s3 = Math.Sqrt(3);
            double smallDiameter = distance / grid;
            double hexagonSide = smallDiameter / s3;
            double hexagonArea = 3 * hexagonSide * hexagonSide * s3 / 2;
            double hexagonArea1 = smallDiameter * smallDiameter * s3 / 2;

            int numConcentricRings = 6;
            HexagonPrism centerPrism = temperatureAtHexCoord[new Tuple<int, int, int>(0, 0, 0)];
            numConcentricRings = centerPrism.dts.Length;
            // we subdevide the hexagon into n (=numConcentricRings) evenly spaced concentric rings, with a small hexagon in the center.
            // The central hexagon represents the borehole pipes containing the water, the remaining rings have different temperatures
            // The area of ring i is: ((i+1)*(sd/n))^2*sqrt(3)/2 - (i*(sd/n))^2*sqrt(3)/2
            // == ((i^2+2*i+1)*(sd/n)^2 - i^2*(sd/n)^2)*sqrt(3)/2 == (2*i+1)*(sd/n)^2*sqrt(3)/2
            double sai = 0.0; // debug the area
            // the following could be calculated once for this BoreHoleField
            double[] r = new double[numConcentricRings]; // small outer radii of hexagonal rings (inner is r[i-1]), maybe not evenly distributed
            double[] a = new double[numConcentricRings]; // area of rings
            double[] c = new double[numConcentricRings]; // outer circumference of the ring
            double[] hc = new double[numConcentricRings]; // heat capacity of the ring

            for (int i = 0; i < numConcentricRings; i++)
            {
                r[i] = (i + 1) * (smallDiameter / 2.0) / numConcentricRings;
                double innerRadius = 0.0;
                if (i > 0) innerRadius = r[i - 1];
                a[i] = 2 * r[i] * r[i] * s3 - 2 * innerRadius * innerRadius * s3;
                c[i] = 6 * 2 * r[i] / s3;
                hc[i] = a[i] * Length * HeatCapacity; // m³ * J / (m³*K) == J / K
                sai += a[i];
            }
            // The outer circumference of ring i is: 6 * (i+1)*(sd/n)/sqrt(3)
            double waterVolume = Math.Abs(volumeStream * duration); // in m³
            double waterEnergy = inTemperature * waterVolume * 4200000; // in J relative to 0 K,  4.2 kJ/(kg*K) or 4200000 J/(m³*K)
            double currentWaterTemperature = inTemperature; // will decrease (or increase) from borehole to borehole

            // first calculate temperature changes within the boreholes: the inner core is affected by the water in the pipe
            // parallel and serial must be considered
            // if the temperature difference is too big do it in several steps
            int numSteps = (int)Math.Ceiling((currentWaterTemperature - centerPrism.ts[0]) / 10);
            for (int k = 0; k < numSteps; k++)
            {
                double q0 = TransferPower * Length * (currentWaterTemperature - (centerPrism.ts[0] + centerPrism.dts[0])); // some magical TransferPower for the borehole, shape and geometry of the borehole is not respected
                                                                                                                           // q0 is the power in J
                double tre = q0 * duration / numSteps; // the amount of energy that goes from the water pipe of the borehole to the soil of the hexagonal prism
                centerPrism.dts[0] += tre / hc[0]; // for the temperature change devide the energy by volume*heat capacity
                waterEnergy -= tre;
                currentWaterTemperature = waterEnergy / (waterVolume * 4200000); // the new energy of the water defines the new water temperature
                                                                                 // now from the core of the borehole to the outer shell the energy is distributed
                                                                                 //double toten = 0.0; // debug total energy in the hex prism
                                                                                 //for (int i = 0; i < numConcentricRings; i++)
                                                                                 //{
                                                                                 //    toten += hc[i] * centerPrism.dts[i];
                                                                                 //}

                for (int i = 1; i < numConcentricRings; i++)
                {
                    double faceArea = c[i - 1] * Length; // size of the face area between the two shells
                    double dT = (centerPrism.ts[i - 1] + centerPrism.dts[i - 1] - centerPrism.ts[i] - centerPrism.dts[i]); // tempearure difference between the shells
                    double dist = (r[i] - r[i - 1]); // distance between the shells centers
                    double tr = Lambda * faceArea * dT * duration / numSteps / dist; // transferred energy (J) defined by contact area temp. difference duration and distance
                    centerPrism.dts[i] += tr / hc[i]; // J / (J/K) == K
                    centerPrism.dts[i - 1] -= tr / hc[i - 1];
                }

                //toten = 0.0;
                //for (int i = 0; i < numConcentricRings; i++)
                //{
                //    toten += hc[i] * centerPrism.dts[i];
                //}
            }
            // now we adjust the temperature of the rings
            for (int i = 0; i < numConcentricRings; i++)
            {
                centerPrism.ts[i] += centerPrism.dts[i];
                centerPrism.dts[i] = 0.0;
            }

            outTemperature = currentWaterTemperature; // this is the last water temperature after leaving the last borehole


            double heatCapacityPerHexPrism = HexagonArea * HeatCapacity * Length; // to get the energy you have to multiply by deltaT
            double heatCapacityPerOuterRing = a[numConcentricRings - 1] * HeatCapacity * Length; // to get the energy you have to multiply by deltaT

            // now we need to adapt each temperature point by the influence of its neighbours
            // in a first loop we keep the temperatures unchanged and calculate the deltaT for each point
            // in a second loop, we add deltaT to the temperature of each point
            // now distribute the energy between all hexagonal prisms for the given period of time
            double borderdt = 0.0;
            double energyToTransfer = Lambda * FaceArea * duration / HexagonDistance;
            double f = energyToTransfer / heatCapacityPerHexPrism;
            double fOuter = energyToTransfer / heatCapacityPerOuterRing;
            // Q = k * A * (T1 - T2) * t / d
            // where:
            // Q is the energy transferred(in Joules)
            // k is the thermal conductivity(in W / (m * K))
            // A is the area of the contacting faces(in m²)
            // T1 and T2 are the temperatures of the two adjacent hexagonal prisms(in K)
            // t is the duration of the time step(in seconds)
            // d is the distance between the center axis of the two hexagonal prisms(in meters)
            // foreach (Tuple<int,int,int> key in temperatureAtHexCoord.Keys) // seriel to debug
            Parallel.ForEach(temperatureAtHexCoord.Keys, (Tuple<int, int, int> key) =>
            {
                HexagonPrism itemValue = temperatureAtHexCoord[key];
                double t0 = itemValue.ts.Last(); // outer ring or total hexagon

                foreach (Tuple<int, int, int> item in shell(key, 1))
                {
                    if (temperatureAtHexCoord.TryGetValue(item, out HexagonPrism? found))
                    {
                        if (itemValue.ts.Length > 1) itemValue.dts[^1] += fOuter * (found.ts.Last() - t0);
                        else itemValue.dts[0] += f * (found.ts.Last() - t0);
                    }
                    else
                    {
                        int outside = (Math.Abs(item.Item1) + Math.Abs(item.Item2) + Math.Abs(item.Item3) - ((numRings + 1) * 2 * grid - 1));
                    }
                }
            });
            // now for the borehole hex prism we distribute the energy from the outer ring into the middle
            for (int i = numConcentricRings - 1; i > 0; --i)
            {
                double faceArea = c[i - 1] * Length; // size of the face area between the two shells
                double dT = (centerPrism.ts[i - 1] + centerPrism.dts[i - 1] - centerPrism.ts[i] - centerPrism.dts[i]); // tempearure difference between the shells
                double dist = (r[i] - r[i - 1]); // distance between the shells centers
                double tr = Lambda * faceArea * dT * duration / numSteps / dist; // transferred energy (J) defined by contact area temp. difference duration and distance
                centerPrism.dts[i] += tr / hc[i]; // J / (J/K) == K
                centerPrism.dts[i - 1] -= tr / hc[i - 1];
            }
            // now update the mantle temperature changes (dt)
            // the innermost mantle has already been affected byt 
            //for (int i = 0; i < mantles.Count; i++)
            //{
            //    if (i > 0)
            //    {   // what we get from the next inner mantle
            //        double contactArea = mantles[i].innerRadius * 6 * Length;
            //        double distance = (mantles[i].Thickness + mantles[i - 1].Thickness) / 2.0;
            //        double ff = Lambda * contactArea * duration / distance / (mantles[i].Area * HeatCapacity * Length);
            //        mantles[i].dt += ff * (mantles[i - 1].t - mantles[i].t);
            //    }
            //    if (i < mantles.Count - 1)
            //    {   // what we get from the next outer mantle
            //        double contactArea = mantles[i].outerRadius * 6 * Length;
            //        double distance = (mantles[i].Thickness + mantles[i + 1].Thickness) / 2.0;
            //        double ff = Lambda * contactArea * duration / distance / (mantles[i].Area * HeatCapacity * Length);
            //        mantles[i].dt += ff * (mantles[i + 1].t - mantles[i].t);
            //    }
            //}
            // now we change all temperatures
            borderTemperature -= borderdt;
            Parallel.ForEach(temperatureAtHexCoord.Keys, (Tuple<int, int, int> key) =>
            {
                HexagonPrism itemValue = temperatureAtHexCoord[key];
                for (int i = 0; i < itemValue.ts.Length; i++)
                {
                    itemValue.ts[i] += itemValue.dts[i];
                    itemValue.dts[i] = 0.0;
                }
                //itemValue.t += itemValue.dt;
                //itemValue.dt = 0;
            });
            //for (int i = 0; i < mantles.Count; i++)
            //{
            //    mantles[i].t += mantles[i].dt;
            //    mantles[i].dt = 0.0;
            //}
        }
    }
}
