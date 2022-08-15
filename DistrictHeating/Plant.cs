using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;

namespace DistrictHeating
{
    public enum Pipe { returnPipe, warmPipe, hotPipe };
    /// <summary>
    /// the plant: contains information about the current state of the heating system.
    /// 
    /// </summary>
    public class Plant
    {
        public static int HoursPerYear = 8760;
        public static double ZeroK = 273.15;
        //public Plant(int n)
        //{
        //    currentTime = 0;
        //    UseThreePipes = false;
        //    Climate = new Climate();
        //    SolarThermalCollector = new SolarThermalCollector() { Area = 3000 };
        //    JsonSerializer serializer = new JsonSerializer();
        //    serializer.Converters.Add(new JavaScriptDateTimeConverter());
        //    serializer.NullValueHandling = NullValueHandling.Ignore;

        //    using (StreamWriter sw = new StreamWriter(@"c:\Temp\jsontest.json"))
        //    using (JsonWriter writer = new JsonTextWriter(sw))
        //    {
        //        serializer.Serialize(writer, this);
        //    }
        //    using (StreamReader sr = new StreamReader(@"c:\Temp\jsontest.json"))
        //    {
        //        string jstr = sr.ReadToEnd();
        //        // the following works:
        //        Plant dbg = JsonConvert.DeserializeObject<Plant>(jstr);
        //    }
        //}
        public Plant()
        {
            currentTime = 0;
            UseThreePipes = false;
            Climate = new Climate();
            SolarThermalCollector = new SolarThermalCollector() { Area = 3000 };
            Heating = new List<IProsumer>();
            Heating.Add(HeatingConsumer.RadiatorHeating);
            Heating.Add(HeatingConsumer.UnderFloorHeating);
        }
        public double currentTime; // number of seconds since first of january of the simulation
        public double returnPipeTemp; // current temperature of the return pipe [K]
        public double returnPipeFlow; // current volume flow of the return pipe [l/s]
        public double warmPipeTemp; // current temperature of the warm pipe [K]
        public double warmPipeFlow; // current volume flow of the warm pipe [l/s]
        public double hotPipeTemp; // current temperature of the hot pipe [K]
        public double hotPipeFlow; // current volume flow of the hot pipe [l/s]
        public bool UseThreePipes { get; set; } = false; // use a three pipe system
        public double WarmPipeMinTemp { get; set; } = 40; // minimum temperature for the warm pipe
        public double HotPipeMinTemp { get; set; } = 50; // minimum temperature for the hot pipe
        public double[] HotPipeSupplyTemp { get; set; } = { 0, 38, 44, 50, 56, 62, 68, 72 }; // desired supply temperatures at 20°C, 15°C, ..., -15°C, -20°C ambient temperature
        public Climate Climate { get; set; }
        public SolarThermalCollector SolarThermalCollector;
        public List<IProsumer> Heating;

        internal double GetCurrentTemperature()
        {
            double currentHour = currentTime / 3600;
            int hourIndex = (int)Math.Floor(currentHour);
            return Climate.Temperature[hourIndex];
        }
        internal double GetMeanTemperature(int numHours)
        {
            if (numHours <= 0) return GetCurrentTemperature();
            double currentHour = currentTime / 3600;
            int hourIndex = (int)Math.Floor(currentHour);
            double res = 0;
            if (hourIndex < numHours)
            {
                for (int i = 0; i < numHours; i++)
                {
                    res += Climate.Temperature[(hourIndex - i + 8760) % 8760];
                }
            }
            else
            {
                for (int i = 0; i < numHours; i++)
                {
                    res += Climate.Temperature[(hourIndex - i) % 8760];
                }
            }
            return res / numHours;
        }

        public void Simulate()
        {
            FileStream fs = File.OpenRead(@"C:\Users\ghofm\source\repos\DistrictHeating\DistrictHeating\Weather\GiesenTemperatur.txt");
            Dictionary<int, double[]> tempPerYear = null;
            using (StreamReader reader = new StreamReader(fs))
            {
                tempPerYear = Climate.ReadDwdData(reader, "TT_TU");
            }
            for (int year = 2000; year < 2022; ++year)
            {
                if (tempPerYear.TryGetValue(year, out double[] tt))
                {
                    Climate.Temperature = tt;
                    SolarThermalCollector.Initialize(this);
                    foreach (IProsumer item in Heating)
                    {
                        item.Initialize(this);
                    }
                    this.warmPipeTemp = ZeroK + 90;
                    IProsumer radiator = Heating[0];
                    double totalEnergy = 0.0;
                    double totalElectricity = 0.0;
                    double[] KwhPerMonth = new double[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                    for (int i = 0; i < HoursPerYear; i++)
                    {   // 1 hour steps
                        currentTime = i * 3600.0;
                        int month = Climate.HourNumberToMonth(i);
                        radiator.Step(this, out double volumetricFlowRate, out double deltaT, out Pipe fromPipe, out Pipe toPipe, out double electricPower);
                        // water: 4.2 KJ/(kg*K), volumetricFlowRate in m³/s, (volumetricFlowRate * 1000) = number of kg in this step (1 hour)
                        double usedEnergy = (volumetricFlowRate * 1000 * 3600) * (-deltaT) * 4.2 * 1000; // Joule
                        totalEnergy += usedEnergy;
                        totalElectricity += electricPower * 3600;
                        KwhPerMonth[month] += usedEnergy;
                    }
                    double kWhTh = totalEnergy / 3600 / 1000; // J-> kWh
                    double kWhEl = totalElectricity / 3600 / 1000; // J-> kWh
                    for (int i = 0; i < 12; i++)
                    {
                        KwhPerMonth[i] /= totalEnergy;
                    }
                    System.Diagnostics.Trace.WriteLine(year.ToString() + ": " + (KwhPerMonth[0] * 100).ToString("0.#") + ", " + (KwhPerMonth[1] * 100).ToString("0.#") + ", " + (KwhPerMonth[2] * 100).ToString("0.#") + ", " + (KwhPerMonth[3] * 100).ToString("0.#") + ", " + (KwhPerMonth[4] * 100).ToString("0.#") + ", " + (KwhPerMonth[5] * 100).ToString("0.#") + ", " + (KwhPerMonth[6] * 100).ToString("0.#") + ", " + (KwhPerMonth[7] * 100).ToString("0.#") + ", " + (KwhPerMonth[8] * 100).ToString("0.#") + ", " + (KwhPerMonth[9] * 100).ToString("0.#") + ", " + (KwhPerMonth[10] * 100).ToString("0.#") + ", " + (KwhPerMonth[11] * 100).ToString("0.#"));
                }
            }
            /* Ergebnis
mit sqr:
2000: 18,8, 14,1, 11,8, 7,7, 3,1, 2,5, 2,6, 0,7, 3,9, 6,5, 11,5, 16,9
2001: 18,2, 13,9, 11,6, 8,6, 2,6, 3,2, 0,8, 0,8, 4,7, 4,6, 13,1, 18,1
2002: 18,9, 12,1, 12,2, 8,3, 4, 1,6, 1,3, 0,6, 4,8, 7,8, 11,1, 17,3
2003: 19, 18,6, 10,1, 7,8, 3,1, 0,8, 0,5, 0,5, 4, 9,3, 9,2, 17,1
2004: 16,6, 14, 12,9, 6,8, 4,5, 2,6, 1,5, 1, 3, 6, 12,4, 18,7
2005: 15,4, 19,1, 12,4, 6,4, 4,5, 2,3, 1,1, 1,5, 3,5, 5,4, 12,2, 16,2
2006: 22,6, 16,1, 16,5, 8,4, 3,7, 2,3, 0,1, 2,6, 2,2, 4,5, 8,1, 12,7
2007: 12,8, 13,9, 11,5, 5,9, 3,3, 2,1, 2, 1,9, 4,9, 8,7, 13,9, 19,2
2008: 13,8, 14, 13,1, 8,6, 2,9, 2,3, 1,2, 1,3, 5,2, 7,8, 12,1, 17,6
2009: 23,8, 14,9, 11,3, 5,1, 3,2, 3,5, 0,9, 0,8, 3,2, 7,8, 7,9, 17,7
2010: 19,1, 14,4, 11, 5,8, 4,8, 1,8, 0,5, 1,4, 3,9, 7,2, 10, 20,1
2011: 17,4, 15,9, 11,8, 5,4, 3,8, 2,5, 2,1, 1,4, 3,7, 8,3, 14, 13,6
2012: 14,9, 29, 7,8, 6,8, 2,8, 2,5, 1,5, 0,7, 3,9, 7,2, 10, 12,8
2013: 17,9, 16,9, 16,5, 7,3, 4,7, 2,6, 0,4, 1,1, 3,6, 5,3, 11,9, 11,9
2014: 16,1, 13,7, 11,7, 6,7, 5,1, 3,6, 0,8, 3, 3,3, 5,8, 12,6, 17,5
2015: 81,3, 3,8, 3, 1,9, 1,1, 0,5, 0,2, 0,2, 1, 2, 2,5, 2,5
2016: 15,8, 13,8, 13,3, 8,6, 3,5, 2,3, 1, 1, 2,3, 7, 13,6, 17,7
2017: 2,6, 1,6, 1, 1, 89,1, 0,2, 0,1, 0,1, 0,5, 0,7, 1,4, 1,6
2018: 13,4, 22,1, 16,2, 5,5, 2,3, 1,8, 0,4, 0,9, 4,1, 6,9, 11,5, 14,8
2019: 18,2, 14,7, 10,1, 7,5, 6,3, 1,1, 1,1, 1, 4,4, 7, 13, 15,5
2020: 16,6, 14,1, 12,3, 7,5, 5,8, 2,7, 0,9, 0,6, 4,2, 6,8, 13,3, 15,2
2021: 15,1, 17,1, 12,3, 10,8, 5,9, 1,3, 0,9, 1,8, 3, 7,4, 11,1, 13,5
ohne sqr
2000: 16, 13,1, 12,2, 8,2, 3,8, 2,8, 3,1, 0,8, 4,7, 8,2, 12,2, 14,8
2001: 15,6, 12,7, 12, 9,6, 3,3, 4, 1, 0,9, 6,3, 6, 13,1, 15,6
2002: 15,5, 12, 12,2, 9,3, 5,1, 1,5, 1,5, 0,7, 5,6, 9,5, 12, 15,1
2003: 16,3, 15,6, 10,9, 8,5, 4,3, 0,9, 0,6, 0,7, 4,9, 10,7, 10,8, 15,6
2004: 14,9, 12,8, 12,5, 7,9, 5,9, 3,1, 1,8, 1,2, 3,8, 7,7, 12,5, 15,9
2005: 14,6, 15,7, 11,8, 7,6, 5,5, 2,6, 1,4, 2, 4, 7, 12,4, 15,3
2006: 17,9, 14,4, 14,7, 9,6, 5,1, 2,8, 0,2, 3,6, 2,5, 6,1, 10, 13,2
2007: 12,6, 13, 11,9, 6,3, 4,2, 2,1, 2,5, 2,3, 6,1, 9,7, 13,4, 16
2008: 13,1, 12,8, 12,8, 9,8, 3,5, 2,3, 1,5, 1,4, 6,2, 9,1, 12,1, 15,4
2009: 18,1, 13,7, 12,2, 6,5, 4,5, 4,4, 1,1, 1,2, 3,9, 9, 9,9, 15,4
2010: 16, 12,9, 11,1, 7,3, 6,7, 2,3, 0,7, 2,1, 5,3, 8,6, 10,6, 16,5
2011: 15,2, 14,1, 11,8, 6,3, 4,5, 3, 2,6, 1,7, 4,6, 9,3, 13,3, 13,6
2012: 14,7, 15,8, 10, 8,8, 4,1, 3,3, 2, 1,1, 5,6, 9,3, 11,9, 13,5
2013: 15,3, 14,4, 14,7, 8,3, 6,3, 3,4, 0,5, 1,2, 4,6, 6,8, 12, 12,4
2014: 14,9, 13, 11,6, 7,3, 6,2, 3,8, 0,8, 3,4, 3,6, 7,2, 12,5, 15,6
2015: 24,4, 12,9, 11,4, 7,9, 5,3, 2,4, 1, 1, 4,8, 8,6, 9,8, 10,5
2016: 14,5, 12,9, 13,3, 9,8, 4,4, 2,5, 1,1, 1,2, 2,7, 9, 13,1, 15,5
2017: 13,8, 10, 7,7, 7,7, 26,7, 1,3, 1,1, 1,1, 4,1, 6,2, 9,6, 10,5
2018: 14,2, 17,6, 15,1, 6,5, 2,9, 2, 0,5, 1, 4,8, 8,5, 12,4, 14,4
2019: 15,8, 13,1, 11,1, 8,3, 7,4, 1,2, 1,3, 1,1, 5, 8,4, 12,9, 14,4
2020: 14,9, 13,1, 12,4, 8,1, 6,6, 2,6, 1,1, 0,8, 4,9, 8,6, 12,7, 14,4
2021: 14,2, 13,8, 12,2, 11,1, 7,2, 1,2, 0,9, 2,2, 3,6, 8,8, 11,8, 12,9

             */
        }
    }
}
