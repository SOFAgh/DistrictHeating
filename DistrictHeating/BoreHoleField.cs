using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DistrictHeating
{
    public class BoreHoleField
    {
        readonly double sqrt3 = Math.Sqrt(3.0);
        private double[,] temperature;
        private int numRings; // number of rings of hexagons (not boreholes)
        private int numBoreholeRings;
        private double[] boundaryRings;
        private const int numBoundaryRings = 100;
        double area;
        double alpha; // thermal diffusivity (m²/s)
        public double Lambda = 2.6; // in W/(m*K) Sandstein Wikipedia
        public double HeatCapacity = 900 * 2400; // J/(m³*K), Sandstein https://www.schweizer-fn.de/stoff/wkapazitaet/wkapazitaet_baustoff_erde.php
        public double Length = 100.0;
        public double startBoreholeFieldCenterTemperature = 10 + Plant.ZeroK;
        public double startBoreholeFieldBorderTemperature = 10 + Plant.ZeroK;
        public double boundaryTemperature = 10 + Plant.ZeroK;
        HexSubdevision[] Boreholes; // The boreholes are subdevided for better precision. Ordered from inside to outer rings
        Dictionary<(int, int), int> BoreHoleIndex;


        public int NumberOfBoreHoles { get; set; } = 61;
        public double BoreHoleDistance { get; set; } = 3.0;
        public int Grid { get; set; } = 6;
        public double TransferPower { get; set; } = 5; // W/(K*m) power of the heat exchange of the borehole per meter and per K temperature difference
        private double GridDistance
        {
            get
            {
                return BoreHoleDistance / Grid;
            }
        }
        public BoreHoleField(int numRings, double initialTemperature)
        {
            numBoreholeRings = numRings;
            this.numRings = numRings * Grid + 2 * Grid;
            alpha = Lambda / HeatCapacity;
            temperature = new double[2 * this.numRings + 1, 2 * this.numRings + 1];
            for (int i = 0; i < 2 * this.numRings + 1; i++)
            {
                for (int j = 0; j < 2 * this.numRings + 1; j++) temperature[i, j] = initialTemperature;
            }
            Boreholes = new HexSubdevision[0]; ;
        }

        private double this[int i, int j]
        {
            get { return temperature[i + numRings, j + numRings]; }
            set { temperature[i + numRings, j + numRings] = value; }
        }
        private IEnumerable<(int i, int j, int k)> BoreholeIndices
        {
            get
            {
                int k = 0;
                for (int n = 0; n <= numBoreholeRings; n++)
                {
                    foreach ((int i, int j) in Ring(n)) yield return (i * Grid, j * Grid, k++);
                }
            }
        }
        private static IEnumerable<(int i, int j)> Ring(int n)
        {
            if (n == 0)
            {
                yield return (0, 0);
                yield break;
            }

            int x = -n, y = n;
            var directions = new (int, int)[] { (1, 0), (1, -1), (0, -1), (-1, 0), (-1, 1), (0, 1) };

            foreach (var direction in directions)
            {
                for (int i = 0; i < n; i++)
                {
                    yield return (x, y);
                    x += direction.Item1;
                    y += direction.Item2;
                }
            }
        }
        /// <summary>
        /// Iterates all hexagons of a certain ring, corner==true when the hexagon is in the corner
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private static IEnumerable<(int i, int j, bool corner)> RingC(int n)
        {
            if (n == 0)
            {
                yield return (0, 0, true);
                yield break;
            }

            int x = -n, y = n;
            var directions = new (int, int)[] { (1, 0), (1, -1), (0, -1), (-1, 0), (-1, 1), (0, 1) };

            foreach (var direction in directions)
            {
                for (int i = 0; i < n; i++)
                {
                    yield return (x, y, i == 0);
                    x += direction.Item1;
                    y += direction.Item2;
                }
            }
        }
        public static IEnumerable<(int ii, int jj)> surrounding(int i, int j)
        {
            yield return (i - 1, j + 1);
            yield return (i, j + 1);
            yield return (i + 1, j);
            yield return (i + 1, j - 1);
            yield return (i, j - 1);
            yield return (i - 1, j);
        }
        private IEnumerable<(int i, int j)> AllIndices
        {
            get
            {
                for (int i = -numRings; i <= numRings; i++)
                {
                    for (int j = -numRings; j <= numRings; j++)
                    {
                        int k = -i - j;
                        if (Math.Abs(i) + Math.Abs(j) + Math.Abs(k) > (numRings + 1) * 2 - 1) continue;
                        yield return (i, j);
                    }
                }
            }
        }
        private IEnumerable<(int i, int j)> AllIndicesWithoutBoreholes
        {
            get
            {
                for (int i = -numRings; i <= numRings; i++)
                {
                    for (int j = -numRings; j <= numRings; j++)
                    {
                        if (i % Grid == 0 && j % Grid == 0)
                        {
                            if (Math.Abs(i / Grid) <= numBoreholeRings && Math.Abs(j / Grid) <= numBoreholeRings)
                            {
                                // System.Diagnostics.Trace.WriteLine("Skip: " + i.ToString() + ", " + j.ToString());
                                continue;
                            }
                        }
                        int k = -i - j;
                        if (Math.Abs(i) + Math.Abs(j) + Math.Abs(k) > (numRings + 1) * 2 - 1) continue;
                        yield return (i, j);
                    }
                }
            }
        }
        public enum hexagonPosition { inside, borehole, outside };
        /// <summary>
        /// Yields all indices of the hexagons surrounding (i, j). If a hexagon is outside the field or a borehole (i, j) is yielded.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        public IEnumerable<(int ii, int jj, hexagonPosition pos)> surroundingOrSelf(int i, int j)
        {
            foreach ((int m, int n) in surrounding(i, j))
            {
                int k = -m - n;
                if (Math.Abs(m) + Math.Abs(n) + Math.Abs(k) > (numRings + 1) * 2 - 1) yield return (i, j, hexagonPosition.outside); // outside the field
                else if (m % Grid == 0 && n % Grid == 0
                    && Math.Abs(m / Grid) <= numBoreholeRings && Math.Abs(n / Grid) <= numBoreholeRings) yield return (i, j, hexagonPosition.borehole); // a borehole
                else yield return (m, n, hexagonPosition.inside);
            }
        }
        internal void Initialize()
        {

            numRings = numBoreholeRings * Grid + 2 * Grid;
            alpha = Lambda / HeatCapacity;
            area = Math.Sqrt(3) * GridDistance * GridDistance / 2;
            temperature = new double[2 * numRings + 1, 2 * numRings + 1];
            for (int r = 0; r <= numRings; r++)
            {
                double temp = startBoreholeFieldCenterTemperature + ((double)r) / numRings * (startBoreholeFieldBorderTemperature - startBoreholeFieldCenterTemperature);
                foreach ((int i, int j) in Ring(r))
                {
                    this[i, j] = temp;
                }
            }
            boundaryRings = new double[numBoundaryRings];
            for (int i = 0; i < boundaryRings.Length; i++)
            {
                boundaryRings[i] = boundaryTemperature;
            }
            NumberOfBoreHoles = (numBoreholeRings * (numBoreholeRings + 1)) / 2 * 6 + 1;
            Boreholes = new HexSubdevision[NumberOfBoreHoles];
            BoreHoleIndex = new Dictionary<(int, int), int>();
            foreach ((int i, int j, int k) in BoreholeIndices)
            {
                Boreholes[k] = new HexSubdevision(GridDistance, 4, this[i, j], TransferPower); // hardcoded number of subdevision rings (4: 61 hexagons)
                BoreHoleIndex[(i, j)] = k;
                // System.Diagnostics.Trace.WriteLine("Borehole: " + i.ToString() + ", " + j.ToString());
            }
        }

        internal void TransferEnergie(double flowRate, double inTemperature, out double outTemperature, int step)
        {
            // Let the water flow through all boreholes from the inner borehole to the outer holes.
            // This cannot be done parallel, since the out temperature of one borehole is the in temperature for the next borehole
            for (int i = 0; i < Boreholes.Length; i++)
            {
                int index = i;
                if (flowRate < 0) index = Boreholes.Length - i - 1; // from outside to center when flow rate is negative
                Boreholes[index].Step(Lambda, HeatCapacity, step, inTemperature, flowRate, out inTemperature);
            }
            outTemperature = inTemperature;
            // Transfer the temperature change at the edge of the borehole[i,j] to the surrounding hexagons.
            // Also changes the temperature of the borehole
            Parallel.ForEach(BoreholeIndices, tuple =>
            {
                (int i, int j, int k) = tuple;
                int ei = 0;
                foreach ((int si, int sj) in surrounding(i, j))
                {
                    Boreholes[k].Connect(ei, ref temperature[si + numRings, sj + numRings], area);
                    ++ei;
                }
            });
            double[,] newTemperature = (double[,])temperature.Clone();
            Parallel.ForEach(AllIndicesWithoutBoreholes, tuple =>
            {
                (int i, int j) = tuple;
                //foreach ((int i, int j) in AllIndicesWithoutBoreholes)
                //{
                double tsum = 0.0;
                foreach ((int si, int sj, hexagonPosition pos) in surroundingOrSelf(i, j))
                {   // boundary condition:
                    // if the neighbour is a borehole, this hexagon is isolated, i.e. the own temperature is used. HexSubdevision.Connect transfers the energy later
                    // if the neighbour is outside we use the temperature of the boundary ring, which is assumed to be the same all around the field
                    if (pos == hexagonPosition.outside) tsum += boundaryRings[0]; // the first boundary ring
                    else tsum += this[si, sj];
                }
                newTemperature[i + numRings, j + numRings] = alpha * 2 / 3 * (tsum - 6 * this[i, j]) / (GridDistance * GridDistance) * step + this[i, j];
            });
            double tsum = 0.0;
            double[] newBoundaryRings = (double[])boundaryRings.Clone();
            foreach ((int i, int j, bool corner) in RingC(numRings))
            {
                if (corner) tsum += 3 * this[i, j]; // a corner hexagon has three connections to the next ring
                else tsum += 2 * this[i, j]; // the other hexagons have two connections
            }
            tsum += (6 * (numRings + 1)) * 2 * boundaryRings[0]; // the inner connections in the ring count twice
            tsum += ((numRings + 1) * 6 * 2 + 6) * boundaryRings[1]; // this is the number of connections to the next boundary ring
            double tdiff = (tsum - ((numRings + 1) * 6 * 6) * boundaryRings[0]); // temperature difference for all hexagons
            newBoundaryRings[0] = alpha * 2 / 3 * (tdiff / ((numRings + 1) * 6)) / (GridDistance * GridDistance) * step + boundaryRings[0];
            Parallel.For(1, newBoundaryRings.Length, i =>
            // for (int i = 1; i < newBoundaryRings.Length; i++)
            {   // boundaryRings[0] is (numRing+1) in the ring counting
                int nextRing = i + 1;
                if (i == newBoundaryRings.Length - 1) nextRing = i; // at the very end the area is isolated, not clamped to ZeroK+10
                double sum = ((numRings + i) * 6 * 2 + 6) * boundaryRings[i - 1]; // connections to the next inner ring
                sum += (numRings + i + 1) * 6 * 2 * boundaryRings[i]; // the inner connections to itself
                sum += ((numRings + i + 1) * 6 * 2 + 6) * boundaryRings[nextRing]; // connections to the next outer ring
                double diff = sum - ((numRings + i + 1) * 6 * 6) * boundaryRings[i]; // temperature difference for all hexagons in ring i
                newBoundaryRings[i] = alpha * 2 / 3 * (diff / ((numRings + i + 1) * 6)) / (GridDistance * GridDistance) * step + boundaryRings[i];
            });
            boundaryRings = newBoundaryRings;
            temperature = newTemperature;
        }

        internal double GetTotalEnergy(double baseTemperature)
        {
            double res = 0.0;
            foreach ((int i, int j) in AllIndicesWithoutBoreholes)
            {
                res += area * (this[i, j] - baseTemperature);
            }
            res *= Length * HeatCapacity;
            for (int i = 0; i < Boreholes.Length; i++)
            {
                res += Boreholes[i].GetTotalEnergy(baseTemperature);
            }
            return res;
        }

        internal double GetHotEndTemperature(int v)
        {
            return Boreholes[0].MeanTemperature;
        }

        internal double GetColdEndTemperature(int v)
        {
            // return this[numRings, 0];
            return Boreholes[Boreholes.Length - 1].MeanTemperature;
        }

        internal void Dump(string v)
        {
            throw new NotImplementedException();
        }

        internal object GetTemperatureAt(int v1, int v2, int v3)
        {
            throw new NotImplementedException();
        }

        internal void Paint(Panel? panel)
        {   // not implemented yet
        }

        internal double[] GetTemperatureProfile()
        {
            double[] res = new double[2 * numRings + 1 + 2 * boundaryRings.Length];
            for (int i = 0; i < boundaryRings.Length; i++)
            {
                res[i] = boundaryRings[boundaryRings.Length - 1 - i];
            }
            for (int i = 0; i < 2 * numRings + 1; i++)
            {
                if ((i - numRings) % Grid == 0 && BoreHoleIndex.ContainsKey((i - numRings, 0))) res[i + boundaryRings.Length] = Boreholes[BoreHoleIndex[(i - numRings, 0)]].MeanTemperature;
                else res[i + boundaryRings.Length] = temperature[i, numRings];
            }
            for (int i = 0; i < boundaryRings.Length; i++)
            {
                res[i + 2 * numRings + 1 + boundaryRings.Length] = boundaryRings[i];
            }
            return res;
        }
    }
}
