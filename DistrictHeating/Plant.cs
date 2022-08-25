using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;
using System.Globalization;

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

        public int CurrentHourIndex { get { return (int)Math.Floor(currentTime / 3600); } }
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
        public void StartSimulation()
        {
            SolarThermalCollector = new SolarThermalCollector() { Area = 3000 };
            SolarThermalCollector.Initialize(this);
            this.returnPipeTemp = 10 + ZeroK;
        }
        public void CheckBoreHoleFieldAndSolarConsistency()
        {
            SolarThermalCollector = new SolarThermalCollector() { Area = 3000 };
            SolarThermalCollector.Initialize(this);
            this.returnPipeTemp = 10 + ZeroK;
            double totalEnergy = 0.0; // accumulate thermal energy
            double excessEnergy = 0.0;
            BoreHoleField bhf = new BoreHoleField(4, ZeroK + 10);
            double dbgBhfBegin = bhf.GetTotalEnergy(ZeroK + 10);
            long tc0 = DateTime.Now.Ticks;
            int step = 3600; // step with 3600 seconds, i.e. one hour
            for (int i = 0; i < HoursPerYear * 3600 / step; i++)
            {
                currentTime = i * step;
                SolarThermalCollector.EnergyFlow(this, out double volumetricFlowRate, out double deltaT, out Pipe fromPipe, out Pipe toPipe, out double electricPower);
                // water: 4200 J/(kg*K), volumetricFlowRate in m³/s, (volumetricFlowRate * 1000 * 3600) = number of kg in this step (1 hour)
                double usedEnergy = volumetricFlowRate * 1000 * step * deltaT * 4200; // Joule produced in this hour by solarthermal collectors
                totalEnergy += usedEnergy;
                bhf.TransferEnergie(volumetricFlowRate, returnPipeTemp + deltaT, out double outTemp, step);
                if (volumetricFlowRate != 0)
                {
                    returnPipeTemp = outTemp;
                    // excessEnergy += (returnPipeTemp - outTemp) * volumetricFlowRate * step * 4200000 / 3600 / 1000;
                }
                // bhf.Dump(i.ToString("D4"));
            }
            long tc1 = DateTime.Now.Ticks;
            double sec = (tc1 - tc0) / 100000.0;
            double kWhTh = bhf.GetTotalEnergy(ZeroK + 10) / 3600 / 1000; // J -> kWh
            double kWhThSolar = totalEnergy / 3600 / 1000; // J -> kWh
            this.returnPipeTemp = 10 + ZeroK;
            totalEnergy = 0.0; // accumulate thermal energy
            excessEnergy = 0.0;
            BoreHoleField bhf1 = new BoreHoleField(4, ZeroK + 10);
            step = 60; // step with 69 seconds
            for (int i = 0; i < HoursPerYear * 3600 / step; i++)
            {
                currentTime = i * step;
                SolarThermalCollector.EnergyFlow(this, out double volumetricFlowRate, out double deltaT, out Pipe fromPipe, out Pipe toPipe, out double electricPower);
                // water: 4200 J/(kg*K), volumetricFlowRate in m³/s, (volumetricFlowRate * 1000 * 3600) = number of kg in this step (1 hour)
                double usedEnergy = volumetricFlowRate * 1000 * step * deltaT * 4200; // Joule produced in this hour by solarthermal collectors
                totalEnergy += usedEnergy;
                bhf1.TransferEnergie(volumetricFlowRate, returnPipeTemp + deltaT, out double outTemp, step);
                if (volumetricFlowRate != 0)
                {
                    excessEnergy += (returnPipeTemp - outTemp) * volumetricFlowRate * step * 4200000 / 3600 / 1000;
                }
                // bhf.Dump(i.ToString("D4"));
            }
            double diff = bhf1.CompareWith(bhf); // 0.035K average difference between all points of the grid, while temperature ranges from 10°C to 50°C. 3600s steps versus 60s steps
        }
        public void CheckBoreHoleFieldConsistency()
        {
            BoreHoleField bhf = new BoreHoleField(4, ZeroK + 10);
            for (int i = 0; i < HoursPerYear; i++)
            {
                bhf.TransferEnergie(0.001, ZeroK + 60, out double outTemp, 3600);
            }
            double kWhTh = bhf.GetTotalEnergy(ZeroK + 10) / 3600 / 1000; // J -> kWh
            bhf.Dump("consistency");
        }
        public void CheckSolarHeatConsitency()
        {
            SolarThermalCollector = new SolarThermalCollector() { Area = 3000 };
            SolarThermalCollector.Initialize(this);
            this.returnPipeTemp = 20 + ZeroK;

            double totalEnergy = 0.0; // accumulate thermal energy
            double[] EnergyPerMonth = new double[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            for (int i = 0; i < 60 * HoursPerYear; i++)
            {   // 1 hour steps
                currentTime = i * 3600.0 / 60;
                int month = Climate.HourNumberToMonth(i);
                SolarThermalCollector.EnergyFlow(this, out double volumetricFlowRate, out double deltaT, out Pipe fromPipe, out Pipe toPipe, out double electricPower);
                // water: 4200 J/(kg*K), volumetricFlowRate in m³/s, (volumetricFlowRate * 1000 * 3600) = number of kg in this step (1 hour)
                double usedEnergy = (volumetricFlowRate * 1000 * 3600 / 60) * (deltaT) * 4200; // Joule used in this hour
                totalEnergy += usedEnergy;
                EnergyPerMonth[month] += usedEnergy;
            }
            double kWhTh = totalEnergy / 3600 / 1000; // J -> kWh
            for (int i = 0; i < 12; i++)
            {
                double p = EnergyPerMonth[i] / totalEnergy * 100; // percentage ot total energy
                if (i != 11) System.Diagnostics.Trace.Write(p.ToString("0.#", CultureInfo.InvariantCulture) + @"% & ");
                else System.Diagnostics.Trace.Write(p.ToString("0.#", CultureInfo.InvariantCulture) + @"% \\");
            }
            System.Diagnostics.Trace.WriteLine("");
        }
        public void CheckHeatingConsistency()
        {
            FileStream fs = File.OpenRead(@"C:\Users\ghofm\source\repos\DistrictHeating\DistrictHeating\Weather\GiesenTemperatur.txt");
            Dictionary<int, double[]> tempPerYear = null;
            using (StreamReader reader = new StreamReader(fs))
            {   // read temperature per hour for all years in the file
                tempPerYear = Climate.ReadDwdData(reader, "TT_TU");
            }
            IProsumer radiator = HeatingConsumer.RadiatorHeating;
            System.Diagnostics.Trace.WriteLine(@"Jahr & Jan & Feb & Mär & Apr & Mai & Jun & Jul & Aug & Sep & Okt & Nov & Dez \\");
            for (int year = 2000; year < 2022; ++year)
            {   // for the years 2000 to 2021
                if (tempPerYear.TryGetValue(year, out double[]? tt))
                {
                    Climate.Temperature = tt; // set this year's hourly temperatures
                    radiator.Initialize(this); // initialize with these temperatures
                    this.warmPipeTemp = ZeroK + 90; // set the warm pipe to 90°C, so the heat pump will never be used
                    double totalEnergy = 0.0; // accumulate thermal energy
                    double totalElectricity = 0.0;  // accumulate heat pump energy
                    double[] EnergyPerMonth = new double[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                    for (int i = 0; i < HoursPerYear; i++)
                    {   // 1 hour steps
                        currentTime = i * 3600.0;
                        int month = Climate.HourNumberToMonth(i);
                        radiator.EnergyFlow(this, out double volumetricFlowRate, out double deltaT, out Pipe fromPipe, out Pipe toPipe, out double electricPower);
                        // water: 4200 J/(kg*K), volumetricFlowRate in m³/s, (volumetricFlowRate * 1000 * 3600) = number of kg in this step (1 hour)
                        double usedEnergy = (volumetricFlowRate * 1000 * 3600) * (-deltaT) * 4200; // Joule used in this hour
                        totalEnergy += usedEnergy;
                        totalElectricity += electricPower * 3600; // Joule used in this hour
                        EnergyPerMonth[month] += usedEnergy;
                    }
                    double kWhTh = totalEnergy / 3600 / 1000; // J -> kWh
                    double kWhEl = totalElectricity / 3600 / 1000; // J -> kWh
                    System.Diagnostics.Trace.Write(year.ToString() + " & ");
                    for (int i = 0; i < 12; i++)
                    {
                        double p = EnergyPerMonth[i] / totalEnergy * 100; // percentage ot total energy
                        if (i != 11) System.Diagnostics.Trace.Write(p.ToString("0.#", CultureInfo.InvariantCulture) + @"% & ");
                        else System.Diagnostics.Trace.Write(p.ToString("0.#", CultureInfo.InvariantCulture) + @"% \\");
                    }
                    System.Diagnostics.Trace.WriteLine("");
                }
            }
            /* result (https://de.statista.com/statistik/daten/studie/160067/umfrage/verbrauch-von-heizenergie-nach-monaten/)
             * 
Jahr & Jan & Feb & Mär & Apr & Mai & Jun & Jul & Aug & Sep & Okt & Nov & Dez \\
Durchschnitt & 16.1 & 13 & 12.5 & 8.1 & 3.5 & 2.2 & 1.7 & 1.6 & 5.2 & 8.4 & 12.2 & 15.5 \\
2000 & 16% & 13.1% & 12.2% & 8.2% & 3.8% & 2.8% & 3.1% & 0.8% & 4.7% & 8.2% & 12.2% & 14.8% \\
2001 & 15.6% & 12.7% & 12% & 9.6% & 3.3% & 4% & 1% & 0.9% & 6.3% & 6% & 13.1% & 15.6% \\
2002 & 15.5% & 12% & 12.2% & 9.3% & 5.1% & 1.5% & 1.5% & 0.7% & 5.6% & 9.5% & 12% & 15.1% \\
2003 & 16.3% & 15.6% & 10.9% & 8.5% & 4.3% & 0.9% & 0.6% & 0.7% & 4.9% & 10.7% & 10.8% & 15.6% \\
2004 & 14.9% & 12.8% & 12.5% & 7.9% & 5.9% & 3.1% & 1.8% & 1.2% & 3.8% & 7.7% & 12.5% & 15.9% \\
2005 & 14.6% & 15.7% & 11.8% & 7.6% & 5.5% & 2.6% & 1.4% & 2% & 4% & 7% & 12.4% & 15.3% \\
2006 & 17.9% & 14.4% & 14.7% & 9.6% & 5.1% & 2.8% & 0.2% & 3.6% & 2.5% & 6.1% & 10% & 13.2% \\
2007 & 12.6% & 13% & 11.9% & 6.3% & 4.2% & 2.1% & 2.5% & 2.3% & 6.1% & 9.7% & 13.4% & 16% \\
2008 & 13.1% & 12.8% & 12.8% & 9.8% & 3.5% & 2.3% & 1.5% & 1.4% & 6.2% & 9.1% & 12.1% & 15.4% \\
2009 & 18.1% & 13.7% & 12.2% & 6.5% & 4.5% & 4.4% & 1.1% & 1.2% & 3.9% & 9% & 9.9% & 15.4% \\
2010 & 16% & 12.9% & 11.1% & 7.3% & 6.7% & 2.3% & 0.7% & 2.1% & 5.3% & 8.6% & 10.6% & 16.5% \\
2011 & 15.2% & 14.1% & 11.8% & 6.3% & 4.5% & 3% & 2.6% & 1.7% & 4.6% & 9.3% & 13.3% & 13.6% \\
2012 & 14.8% & 15.4% & 10.1% & 8.8% & 4.1% & 3.3% & 2% & 1.1% & 5.6% & 9.3% & 11.9% & 13.6% \\
2013 & 15.3% & 14.4% & 14.7% & 8.3% & 6.3% & 3.4% & 0.5% & 1.2% & 4.6% & 6.8% & 12% & 12.4% \\
2014 & 14.9% & 13% & 11.6% & 7.3% & 6.2% & 3.8% & 0.8% & 3.4% & 3.6% & 7.2% & 12.5% & 15.6% \\
2015 & 15% & 14.5% & 12.8% & 8.8% & 6% & 2.7% & 1.1% & 1.1% & 5.4% & 9.7% & 11% & 11.9% \\
2016 & 14.5% & 12.9% & 13.3% & 9.8% & 4.4% & 2.5% & 1.1% & 1.2% & 2.7% & 9% & 13.1% & 15.5% \\
2017 & 17.9% & 13% & 10% & 10% & 5% & 1.7% & 1.5% & 1.5% & 5.3% & 8% & 12.4% & 13.6% \\
2018 & 14.2% & 17.6% & 15.1% & 6.5% & 2.9% & 2% & 0.5% & 1% & 4.8% & 8.5% & 12.4% & 14.4% \\
2019 & 15.8% & 13.1% & 11.1% & 8.3% & 7.4% & 1.2% & 1.3% & 1.1% & 5% & 8.4% & 12.9% & 14.4% \\
2020 & 14.9% & 13.1% & 12.4% & 8.1% & 6.6% & 2.6% & 1.1% & 0.8% & 4.9% & 8.6% & 12.7% & 14.4% \\
2021 & 14.2% & 13.8% & 12.2% & 11.1% & 7.2% & 1.2% & 0.9% & 2.2% & 3.6% & 8.8% & 11.8% & 12.9% \\

             */
        }
    }
}
