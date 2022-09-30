using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace DistrictHeating
{
    public class BoreHoleField
    {
        private class TempPoint
        {
            public TempPoint(double t, double dt, int i, int j, int k)
            {
                this.t = t;
                this.dt = dt;
                connectedPoints = new List<TempPoint>();
                connectedAngle = new List<double>();
                this.i = i;
                this.j = j;
                this.k = k;
            }
            public double t;
            public double dt;
            public int i, j, k;
            public List<TempPoint> connectedPoints;
            public List<double> connectedAngle;
        }
        private double distance = 5;
        /// <summary>
        /// Distance between boreholes
        /// </summary>
        public double Distance
        {
            get { return distance; }
            set
            {
                distance = value;
                triangleArea = (distance / 6) * (distance / 6) * Math.Sqrt(3.0) / 4.0;
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
        public double TransferPower { get; set; } = 5; // i.e. 50 W/m at deltaT 10K
        /// <summary>
        /// Start temperature in the center for the simulation
        /// </summary>
        public double startBoreholeFieldCenterTemperature = 40 + 273.15;
        /// <summary>
        /// Start temperature at the border for the simulation
        /// </summary>
        public double startBoreholeFieldBorderTemperature = 10 + 273.15;

        // internal representation of the field
        private Dictionary<Tuple<int, int, int>, TempPoint> temperatureAtHexCoord = new Dictionary<Tuple<int, int, int>, TempPoint>();
        private List<TempPoint> boreHoles = new List<TempPoint>();
        private const int grid = 6; // the grid segments between boreholes
        private double triangleArea;
        private double borderTemperature; // the mean temperature of a ring surrounding the field. Used to calculate the energy loss.
        private int numberOfBorderPoints; // number of points on the border
        private int maxHexCoordinate;
        public BoreHoleField(int numRings, double initialTemperature)
        {
            maxHexCoordinate = 0;
            triangleArea = (distance / 6) * (distance / 6) * Math.Sqrt(3.0) / 4.0;
            // 1. create the hexagonal array of temperature points
            int dbgmaxi = 0;
            for (int i = -(numRings + 1) * 2 * grid; i <= (numRings + 1) * 2 * grid; i++)
            {
                for (int j = -(numRings + 1) * 2 * grid; j <= (numRings + 1) * 2 * grid; j++)
                {
                    int k = -i - j;
                    if (Math.Abs(i) + Math.Abs(j) + Math.Abs(k) > (numRings + 1) * 2 * grid - 1) continue; // outside the hexagon
                    TempPoint tpijk = new TempPoint(initialTemperature, 0.0, i, j, k);
                    temperatureAtHexCoord[new Tuple<int, int, int>(i, j, k)] = tpijk;
                    maxHexCoordinate = Math.Max(Math.Max(maxHexCoordinate, Math.Abs(i)), Math.Max(Math.Abs(j), Math.Abs(k)));
                    if (Math.Abs(i) + Math.Abs(j) + Math.Abs(k) > (numRings + 1) * 2 * grid - 1) continue; // outside the hexagon
                    if ((Math.Abs(i) + Math.Abs(k)) % grid == 0 && (Math.Abs(i) + Math.Abs(j)) % grid == 0 && (Math.Abs(j) + Math.Abs(k)) % grid == 0)
                    {   // there are 5 temperature points points in between the boreholes
                        boreHoles.Add(tpijk);
                        if (i > dbgmaxi) dbgmaxi = i;
                    }
                }
            }
            borderTemperature = initialTemperature;

            (double x, double y) p1 = fromHexCoord(0, dbgmaxi, -dbgmaxi);
            (double x, double y) p2 = fromHexCoord(0, -dbgmaxi, dbgmaxi);

            // sort the boreholes from inside out and counterclockwise
            boreHoles.Sort(delegate (TempPoint t1, TempPoint t2)
            {
                int c = (Math.Abs(t1.i) + Math.Abs(t1.j) + Math.Abs(t1.k)).CompareTo(Math.Abs(t2.i) + Math.Abs(t2.j) + Math.Abs(t2.k));
                if (c != 0) return c;
                (double x, double y) a = fromHexCoord(t1.i, t1.j, t1.k);
                (double x, double y) b = fromHexCoord(t2.i, t2.j, t2.k);
                return Math.Atan2(a.y, a.x).CompareTo(Math.Atan2(b.y, b.x));
            });
            foreach (KeyValuePair<Tuple<int, int, int>, TempPoint> item in temperatureAtHexCoord)
            {
                int i = item.Key.Item1;
                int j = item.Key.Item2;
                int k = item.Key.Item3;
                TempPoint? tp;
                if (temperatureAtHexCoord.TryGetValue(new Tuple<int, int, int>(i, j - 1, k + 1), out tp))
                {
                    item.Value.connectedPoints.Add(tp);
                    item.Value.connectedAngle.Add(0);
                }
                if (temperatureAtHexCoord.TryGetValue(new Tuple<int, int, int>(i - 1, j, k + 1), out tp))
                {
                    item.Value.connectedPoints.Add(tp);
                    item.Value.connectedAngle.Add(1);
                }
                if (temperatureAtHexCoord.TryGetValue(new Tuple<int, int, int>(i - 1, j + 1, k), out tp))
                {
                    item.Value.connectedPoints.Add(tp); // 6
                    item.Value.connectedAngle.Add(2);
                }
                if (temperatureAtHexCoord.TryGetValue(new Tuple<int, int, int>(i, j + 1, k - 1), out tp))
                {
                    item.Value.connectedPoints.Add(tp);
                    item.Value.connectedAngle.Add(3);
                }
                if (temperatureAtHexCoord.TryGetValue(new Tuple<int, int, int>(i + 1, j, k - 1), out tp))
                {
                    item.Value.connectedPoints.Add(tp); // 4
                    item.Value.connectedAngle.Add(4);
                }
                if (temperatureAtHexCoord.TryGetValue(new Tuple<int, int, int>(i + 1, j - 1, k), out tp))
                {
                    item.Value.connectedPoints.Add(tp); // 5
                    item.Value.connectedAngle.Add(5);
                }
                numberOfBorderPoints += 6 - item.Value.connectedPoints.Count;
            }
        }
        private (double x, double y) fromHexCoord(int i, int j, int k)
        {
            const double a = 0.8660254037844386; // Math.Sqrt(3.0) / 2;
            Debug.Assert(i + j + k == 0);
            double x = j * 1.5;
            double y = (i - k) * a;
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
                TempPoint itemValue = temperatureAtHexCoord[key];
                double f = (maxHexCoordinate - c) / (double)maxHexCoordinate; // 1: center, 0: border
                itemValue.t = startBoreholeFieldBorderTemperature + f * (startBoreholeFieldCenterTemperature - startBoreholeFieldBorderTemperature);
            });
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
            double heatCapacityPerTriangle = triangleArea * HeatCapacity * Length; // to get the energy you have to multiply by deltaT
            if (volumeStream != 0.0)
            {
                for (int i = 0; i < boreHoles.Count; i++)
                {   // we assume all the water to stay in each borehole for the provided duration. It will be cooled (or heated) by the power (deltaT * TransferPower * Length)
                    // then we pass it on to the next borehole
                    int index = (volumeStream < 0) ? boreHoles.Count - i - 1 : i; // respecting direction of flow
                    double deltaT = currentWaterTemperature - boreHoles[index].t;
                    double power = deltaT * TransferPower * Length;
                    double meanTemp = 0.0; // 6 times the mean temperature of the surrounding points. There are always 6 triangles around the borehole
                    for (int j = 0; j < 6; j++)
                    {
                        meanTemp += boreHoles[index].connectedPoints[j].t;
                    }
                    // prismEnergy is the sum of the 6 triangle_prism_volums * HeatCapacity 
                    // double prismEnergy = 6 * heatCapacityPerTriangle * (6 * boreHoles[index].t + 2 * meanTemp) / 18;
                    // 6 * heatCapacityPerTriangle is the sum of the 6 triangles
                    // (6 * boreHoles[index].t + 2 * meanTemp) / 18 is the leveled temperature (meanTemp is the sum of 6 temperatures, so we have 18 temperatures here)
                    double prismEnergy = heatCapacityPerTriangle * (6 * boreHoles[index].t + 2 * meanTemp) / 3;
                    double energyToTransfer = power * duration;
                    double minimumWaterEnergy = (6 * boreHoles[index].t + 2 * meanTemp) / 18.0 * waterVolume * 4200000; // in J relative to prism temperature,  4.2 kJ/(kg*K) or 4200000 J/(m³*K)
                    // if (minimumWaterEnergy > waterEnergy - energyToTransfer) energyToTransfer = waterEnergy - minimumWaterEnergy; // water cannot become colder than the prism temperature
                    double maximumPrismEnergy = heatCapacityPerTriangle * (6 * currentWaterTemperature + 2 * meanTemp) / 3;
                    // if (maximumPrismEnergy < prismEnergy + energyToTransfer) energyToTransfer = maximumPrismEnergy - prismEnergy;
                    if ((minimumWaterEnergy > waterEnergy - energyToTransfer) || (maximumPrismEnergy < prismEnergy + energyToTransfer))
                    {   // if boundary conditions are not met, we use a intermediate temperature and calculate the energy transfer
                        // so both the water temperature and the boreHole temperature will be the same at the end, i.e. tm
                        double tm = (waterVolume * 4200000 * currentWaterTemperature + 2 * heatCapacityPerTriangle * boreHoles[index].t) / (waterVolume * 4200000 + 2 * heatCapacityPerTriangle);
                        energyToTransfer = heatCapacityPerTriangle * (6 * tm + 2 * meanTemp) / 3 - prismEnergy;
                        // double dbg = (waterVolume * 4200000 * currentInTemperature) - (waterVolume * 4200000 * tm); // must be the same as energyToTransfer
                    }
                    prismEnergy += energyToTransfer;
                    // now we modify the central temperature of the hexagon so that the new prismEnergy represents prismEnergy += energyToTransfer
                    boreHoles[index].t = (prismEnergy * 3.0 / (heatCapacityPerTriangle) - 2 * meanTemp) / 6.0;
                    waterEnergy -= energyToTransfer;
                    currentWaterTemperature = waterEnergy / (waterVolume * 4200000);
                }
            }
            outTemperature = currentWaterTemperature; // this is the last water temperature afte leaving the last borehole
            // now we need to adapt each temperature point by the influence of its neighbours
            // in a first loop we keep the temperatures unchanged and calculate the deltaT for each point
            // in a second loop, we add deltaT to the temperature of each point
            double borderdt = 0.0;
            double parameterToDetermin = Lambda / HeatCapacity; // maybe it should be: Lambda / HeatCapacity, which is 1.5*1e-6  // this parameter will depend on Lambda and maybe also on HeatCapacity
            double dbgf = parameterToDetermin * duration / (Distance / grid); // is this linear to the inverse of the distance? Distance / grid is the point distance, Distance ist the borehole distance
            // Let the temperature difference between two points be deltaT.
            // deltaT is shrinking in a time step of the simulation depending on 
            // - the distance between those two points (which is the same for all points)
            // - the Lambda (and HeatCapacity?) of the soil
            // - the duration (time step)
            // So we need a factor between 0 and 1, which performs that shrinkage (deltaT' = f*delatT). I choose
            // exp(-duration*s) as this factor, where "s" is some (positive) constant value to be determined
            // When duration is 0, the factor is 1: No change when time step is 0
            // When duration goes to infinity, the factor is 0: the temperature of the two points converges to the mean temperature of the two points
            // When applying a time step of duration1+duration2 the result must be the same as for first applying duration1 and then duration2:
            // exp(-(duration1+duration2)*s) * deltaT == exp(-duration1*s) * exp(-duration2*s) * deltaT
            // so using exp(-duration*s) seems to be a reasonable choice
            double s = 2.0 * grid * (Lambda / (HeatCapacity * Distance)); // Distance is between boreholes, Distance/grid is between grid points
            // when distance increases, s decreases and exp(-duration*s) gets closer to 1, i.e. less shrinkage of deltaT with increased distance
            // when Lambda increases, we get more shrinkage of deltaT 
            // factor 2.0 is experimental
            double fDt = (1.0 - Math.Exp(-duration * s)) / 2.0; // Math.Exp(-duration * s) is the factor, which shrinkes the deltaT, half of the shrinkage is added to each points temperature
            double bDt = (1.0 - Math.Exp(-duration * 4.0 * Lambda / (HeatCapacity * Distance))) / 2.0;
            double dbgorgbdt = parameterToDetermin * duration / (Distance / 2);
            Parallel.ForEach(temperatureAtHexCoord.Keys, (Tuple<int, int, int> key) =>
            {
                double dt = 0.0;
                TempPoint itemValue = temperatureAtHexCoord[key];
                double t0 = itemValue.t;
                double f = parameterToDetermin * duration / (Distance / grid); // is this linear to the inverse of the distance? Distance / grid is the point distance, Distance ist the borehole distance
                int cnt = itemValue.connectedPoints.Count;
                // here we assume that all points have the same distance and are regularly distributed around the central point (in 60° steps)
                for (int l = 0; l < cnt; l++)
                {
                    //dt += fDt * (itemValue.connectedPoints[l].t - t0);
                    dt += f * (itemValue.connectedPoints[l].t - t0);
                }
                if (cnt < 6)
                {
                    // this is a point at the border of the field. It is also influenced by the outside temperature. And it influences the outsid temperature
                    // I first tried to make the field much bigger (but no extra boreholes) so that the border almost remained unchanged. Then recorded the temperatures
                    // at the points where the border of the smaller field would be. then I adaptet the additional parameters here
                    // ((Distance / 2) and (24 * numberOfBorderPoints)) tho get a result with the small field at the border, which is similar to the respective points on the big field.
                    // Maybe we have to experiment with these two arbitrary parameters.
                    double bdt = parameterToDetermin * duration * (borderTemperature - t0) / (Distance / 2);
                    // double bdt = bDt * (borderTemperature - t0);
                    dt += (6 - cnt) * bdt;
                    borderdt += bdt / (24 * numberOfBorderPoints);
                }
                itemValue.dt = dt / 6; // save this value, the modification happens for all points simultaneously after this loop


                //double dt = 0.0;
                //TempPoint itemValue = temperatureAtHexCoord[key];
                //double t0 = itemValue.t;
                //double parameterToDetermin = Lambda / HeatCapacity; // maybe it should be: Lambda / HeatCapacity, which is 1.5*1e-6  // this parameter will depend on Lambda and maybe also on HeatCapacity
                //double f = parameterToDetermin * duration / (Distance / grid); // is this linear to the inverse of the distance? Distance / grid is the point distance, Distance ist the borehole distance
                //int cnt = itemValue.connectedPoints.Count;
                //// here we assume that all points have the same distance and are regularly distributed around the central point (in 60° steps)
                //for (int l = 0; l < cnt; l++)
                //{
                //    dt += f * (itemValue.connectedPoints[l].t - t0);
                //}
                //if (cnt < 6)
                //{
                //    // this is a point at the border of the field. It is also influenced by the outside temperature. And it influences the outsid temperature
                //    // I first tried to make the field much bigger (but no extra boreholes) so that the border almost remained unchanged. Then recorded the temperatures
                //    // at the points where the border of the smaller field would be. then I adaptet the additional parameters here
                //    // ((Distance / 2) and (24 * numberOfBorderPoints)) tho get a result with the small field at the border, which is similar to the respective points on the big field.
                //    // Maybe we have to experiment with these two arbitrary parameters.
                //    double bdt = parameterToDetermin * duration * (borderTemperature - t0) / (Distance / 2);
                //    dt += (6 - cnt) * bdt;
                //    borderdt += bdt / (24 * numberOfBorderPoints);
                //}
                //itemValue.dt = dt / 6; // save this value, the modification happens for all points simultaneously after this loop

            });
            // now we change all temperatures
            borderTemperature -= borderdt;
            Parallel.ForEach(temperatureAtHexCoord.Keys, (Tuple<int, int, int> key) =>
            {
                TempPoint itemValue = temperatureAtHexCoord[key];
                itemValue.t += itemValue.dt;
                itemValue.dt = 0;
            });
        }
        private double TriangleArea((double x, double y) p1, (double x, double y) p2, (double x, double y) p3)
        {
            double x1 = p1.x;
            double y1 = p1.y;
            double x2 = p2.x;
            double y2 = p2.y;
            double x3 = p3.x;
            double y3 = p3.y;
            return Math.Abs((x1 * (y2 - y3) + x2 * (y3 - y1) + x3 * (y1 - y2)) / 2.0);
        }
        private double GetVolume(double baseTemperature)
        {
            double volume = 0.0;
            double dbgTotalArea = 0.0;
            foreach (KeyValuePair<Tuple<int, int, int>, TempPoint> item in temperatureAtHexCoord)
            {
                int i = item.Key.Item1;
                int j = item.Key.Item2;
                int k = item.Key.Item3;
                TempPoint? t1, t2;
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
            return volume;
        }
        public double GetTotalEnergy(double baseTemperature)
        {
            return GetVolume(baseTemperature) * HeatCapacity * Length;
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
                    foreach (KeyValuePair<Tuple<int, int, int>, TempPoint> item in temperatureAtHexCoord)
                    {
                        hexIndexToLinearIndex[item.Key] = counter++;
                        (double x, double y) = fromHexCoord(item.Key.Item1, item.Key.Item2, item.Key.Item3);
                        sw.WriteLine(x.ToString(CultureInfo.InvariantCulture) + ", " + y.ToString(CultureInfo.InvariantCulture) + ", " + item.Value.t.ToString(CultureInfo.InvariantCulture));
                        if (item.Value.t > maxtemp) maxtemp = item.Value.t;
                        if (item.Value.t < mintemp) mintemp = item.Value.t;
                    }
                    sw.WriteLine(""); // the triangle indices:
                    foreach (KeyValuePair<Tuple<int, int, int>, TempPoint> item in temperatureAtHexCoord)
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
        public double CompareWith(BoreHoleField other)
        {
            double maxdist = 0.0;
            double maxTemp = 0.0, minTemp = double.MaxValue;
            double res = 0.0;
            foreach (KeyValuePair<Tuple<int, int, int>, TempPoint> item in temperatureAtHexCoord)
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
            foreach (KeyValuePair<Tuple<int, int, int>, TempPoint> item in temperatureAtHexCoord)
            {
                int i = item.Key.Item1;
                int j = item.Key.Item2;
                int k = item.Key.Item3;
                if (Math.Abs(i) + Math.Abs(k) + Math.Abs(k) > outside)
                {
                    TempPoint? t1, t2;
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
    }
}

