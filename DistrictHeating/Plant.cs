using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;
using System.Globalization;
using System.IO;

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
        public static int[] daysPerMonth = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
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
            SolarThermalCollector = new SolarThermalCollector() { Area = 3500 };
            Heating = new List<HeatingConsumer>();
            Heating.Add(HeatingConsumer.RadiatorHeating);
            Heating.Add(HeatingConsumer.UnderFloorHeating);
            BoreHoleField = new BoreHoleField(4, ZeroK + 10);
            BufferStorage = new BufferStorage();
            Pipeline = new Pipeline();
        }
        // current state data:
        public double currentTime; // number of seconds since first of january of the simulation
        public double returnPipeTemp; // current temperature of the return pipe [K]
        public double warmPipeTemp; // current temperature of the warm pipe [K]
        public double hotPipeTemp; // current temperature of the hot pipe [K]
        // diagrams
        public struct DiagramEntry
        {
            public int timeStamp; // seconds
            public double val; // value of the entry
            public DiagramEntry(int timeStamp, double val)
            {
                this.timeStamp = timeStamp;
                this.val = val;
            }
        }
        public Dictionary<string, List<DiagramEntry>> Diagrams = new Dictionary<string, List<DiagramEntry>>();
        public List<double> returnPipeTempPerHour = new List<double>();
        public List<double> warmPipeTempPerHour = new List<double>();
        public List<double> hotPipeTempPerHour = new List<double>();
        public List<double> ambientTemperaturePerHour = new List<double>();
        public List<double> boreHoleEnergyPerDay = new List<double>();
        public List<double> boreHoleTempBorderPerHour = new List<double>();
        public List<double> boreHoleTempCenterPerHour = new List<double>();
        public List<double> boreHoleEnergyFlowPerHour = new List<double>();
        public List<double> heatConsumptionPerHour = new List<double>();
        public List<double> electricityConsumptionPerHour = new List<double>();
        public List<double> solarHeatPerHour = new List<double>();
        public List<double> volumeFlowPerHour = new List<double>();
        public double solarPercentage;
        public double electricityTotal;
        public double heatProduced;
        public double solarTotal;
        public double boreHoleRemoved;
        public double boreHoleAdded;

        // plant properties
        public bool UseThreePipes { get; set; } = false; // use a three pipe system
        public double WarmPipeMinTemp { get; set; } = 40; // minimum temperature for the warm pipe
        public double HotPipeMinTemp { get; set; } = 50; // minimum temperature for the hot pipe
        public Climate Climate { get; set; }
        public SolarThermalCollector SolarThermalCollector;
        public List<HeatingConsumer> Heating;
        public BoreHoleField BoreHoleField;
        public Pipeline Pipeline;
        public BufferStorage BufferStorage;
        public int CurrentHourIndex { get { return (int)Math.Floor((currentTime / 3600) % HoursPerYear); } }
        internal double GetCurrentTemperature()
        {
            double currentHour = (currentTime / 3600) % HoursPerYear;
            int hourIndex = (int)Math.Floor(currentHour);
            return Climate.Temperature[hourIndex];
        }
        internal double GetMeanTemperature(int numHours)
        {
            if (numHours <= 0) return GetCurrentTemperature();
            double currentHour = (currentTime / 3600) % HoursPerYear;
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
        public void StartSimulation(Action<int> progressBar)
        {
            solarPercentage = 0.0;
            electricityTotal = 0.0;
            heatProduced = 0.0;
            solarTotal = 0.0;
            boreHoleRemoved = 0.0;
            boreHoleAdded = 0.0;
            Diagrams.Clear();
            // initialize the components
            SolarThermalCollector.Initialize(this);
            returnPipeTemp = 10 + ZeroK; // 10°C for return pipe
            warmPipeTemp = 20 + ZeroK; // 20° for warm and hot, only relevant for the first step
            hotPipeTemp = 20 + ZeroK;
            for (int j = 0; j < Heating.Count; j++)
            {
                Heating[j].Initialize(this); // calculate scaling factors
            }
            BoreHoleField.Initialize();
            BufferStorage.Initialize();

            // in the following loop we consider for each time step (one hour) how much energy the solar collectors will deliver and how much energy the heaters will require
            // wich both depend on whether data. The difference will be stored in or must be provided by the boreholefield. Now the question is the temperature level
            // because it makes a difference for the distribution of the energy between heat and elecricity. What temperature can we assume on the warm pipe (and hot pipe)
            // for the next hour? The simple, but not perfect solution would be: if more is consumed than provided, we use the outlet temperatur of the storage, otherwise
            // we use the outlet temperatur of the solar collector as the warm pipe temperature. But this doesn't respect the volumetric flowrate. For the same energy
            // the flowrate through the collectors is much slower than through the heaters, because of the hgher temperature lift. Controlling the flow rate should be part
            // of the Controller not of the simulation. So, as the first approach, we use the simple solution
            //
            // different approach:
            // the temperatures of the pipes (returnPipeTemp, warmPipeTemp, hotPipeTemp) stay constant over the period 'step'. Each device consumes fron one pip and delivers
            // to another pipe. This water is collected and determins the temperatures of the next period.
            int step = 3600; // step with 3600 seconds, i.e. one hour
            // for (int i = 0; i < HoursPerYear * 3600 / step; i++)
            for (int i = 0; i < 2 * HoursPerYear * 3600 / step; i++)
            {
                progressBar((int)(i * 1000.0 / (2 * HoursPerYear * 3600 / step)));
                currentTime = i * step; // current time is in s
                // we assume a pool for each pipe, which is at the beginning filled with water at the current temperature of the respective pipe.
                // in the course of the"step" (i.e. one hour) the pools will grow or shrink, they might even underflow, but this is no problem
                double returnPipeVolume = 0.0;
                double warmPipeVolume = 0.0;
                double hotPipeVolume = 0.0;
                double returnPipeEnergy = 0.0;
                double warmPipeEnergy = 0.0;
                double hotPipeEnergy = 0.0;
                double heatConsumption = 0.0;
                double electricityConsumption = 0.0;
                // let the solar collectors do their work
                if (i == Climate.DateToHourNumber(8, 28, 1))
                { // use as a breakpoint

                }
                SolarThermalCollector.EnergyFlow(this, out double volumetricFlowRate, out double deltaT, out Pipe fromPipe, out Pipe toPipe, out double electricPower);
                double solarVolume = volumetricFlowRate * step; // this much water was pumped through the collectors fromPipe->toPipe
                double solarEnergy = solarVolume * deltaT * 4200000;
                solarTotal += solarEnergy;
                if (JouleToKW(solarEnergy, step) > 1000)
                {

                }
                if (solarVolume > 0)
                {
                    if (fromPipe == Pipe.returnPipe) // which it always should be
                    {
                        if (toPipe == Pipe.warmPipe)
                        {
                            warmPipeEnergy += solarVolume * (returnPipeTemp + deltaT);
                            warmPipeVolume += solarVolume;
                        }
                        else if (toPipe == Pipe.hotPipe)
                        {
                            hotPipeEnergy += solarVolume * (returnPipeTemp + deltaT);
                            hotPipeVolume += solarVolume;
                        }
                    }
                }
                for (int j = 0; j < Heating.Count; j++)
                {
                    Heating[j].EnergyFlow(this, out volumetricFlowRate, out deltaT, out fromPipe, out toPipe, out electricPower);
                    double heatingVolume = volumetricFlowRate * step; // amount of water which has been used by this heating
                    if (toPipe == Pipe.returnPipe)
                    {
                        double inTemp = (fromPipe == Pipe.warmPipe) ? warmPipeTemp : hotPipeTemp;
                        returnPipeVolume += heatingVolume; // add this amount of water to the return pipe pool with the now decreased temperature
                        returnPipeEnergy += heatingVolume * (inTemp + deltaT); // deltaT is negative!
                        heatConsumption += -heatingVolume * deltaT * 4200000; // in J, deltaT is negative, but we want a positiv value
                        electricityConsumption += electricPower * step;
                    }
                }
                electricityTotal += electricityConsumption;
                heatProduced += heatConsumption;
                // now we have to balance the two or three pools, by pumping the water through the borehole field
                double transferredEnergy = 0.0;
                double volumeFlow = 0.0;
                if (this.UseThreePipes)
                {

                }
                else
                {
                    if (warmPipeVolume > returnPipeVolume)
                    {   // there was more hot water generated than used. Pump the difference through the boreHoleField
                        if (warmPipeVolume > 0)
                        {
                            double pumpThroughBorehole = (warmPipeVolume - returnPipeVolume); // always positive
                            // pump the water first through the buffer storage (if any) then through the borehole field
                            BufferStorage.TransferEnergie(pumpThroughBorehole / step, warmPipeTemp, out double outTemp, step);
                            BoreHoleField.TransferEnergie(pumpThroughBorehole / step, outTemp, out outTemp, step);
                            transferredEnergy = -pumpThroughBorehole * (outTemp - warmPipeTemp) * 4200000;
                            boreHoleAdded += transferredEnergy; ;
                            volumeFlow = pumpThroughBorehole / step;
                            returnPipeVolume += pumpThroughBorehole;
                            returnPipeEnergy += pumpThroughBorehole * outTemp;
                        }
                    }
                    else
                    {   // water from the warm pipe has been used, transfer from return pipe to warm pipe
                        if (returnPipeVolume > 0)
                        {
                            double pumpThroughBorehole = (returnPipeVolume - warmPipeVolume); // always positive
                            // pump the water first through the borehole field then through the buffer storage (if any) 
                            BoreHoleField.TransferEnergie(-pumpThroughBorehole / step, returnPipeTemp, out double outTemp, step);
                            BufferStorage.TransferEnergie(-pumpThroughBorehole / step, outTemp, out outTemp, step);
                            transferredEnergy = -pumpThroughBorehole * (outTemp - returnPipeTemp) * 4200000;
                            boreHoleRemoved -= transferredEnergy; ;
                            volumeFlow = -pumpThroughBorehole / step;
                            warmPipeVolume += returnPipeVolume;
                            warmPipeEnergy += returnPipeVolume * outTemp;
                        }
                    }
                }
                double dbgtebo = JouleToKWh(BoreHoleField.GetTotalEnergy(ZeroK + 10)) / 1000;
                double dbgtebu = JouleToKWh(BufferStorage.GetTotalEnergy(ZeroK + 10)) / 1000;
                if (returnPipeVolume > 0) returnPipeTemp = returnPipeEnergy / returnPipeVolume;
                if (warmPipeVolume > 0) warmPipeTemp = warmPipeEnergy / warmPipeVolume;
                if (hotPipeVolume > 0) hotPipeTemp = hotPipeEnergy / hotPipeVolume;

                // change the temperatures according to temperature loss in the pipe system
                double returnPipeLoss, warmPipeLoss, hotPipeLoss;
                (returnPipeTemp, returnPipeLoss) = Pipeline.TemperatureChange(returnPipeTemp, returnPipeVolume / step, step);
                (warmPipeTemp, warmPipeLoss) = Pipeline.TemperatureChange(warmPipeTemp, warmPipeVolume / step, step);
                (hotPipeTemp, hotPipeLoss) = Pipeline.TemperatureChange(hotPipeTemp, hotPipeVolume / step, step);
                double netLoss = warmPipeLoss + hotPipeLoss + returnPipeLoss;
                // save the current data for the graphical representation
                int currentSeconds = (int)Math.Round(currentTime);
                if (currentSeconds % 3600 == 0) // should always reach exact hours
                {
                    int hourIndex = currentSeconds / 3600;
                    DiagramAdd(currentSeconds, "returnPipe", returnPipeTemp - ZeroK, "°C");
                    DiagramAdd(currentSeconds, "warmPipe", warmPipeTemp - ZeroK, "°C");
                    DiagramAdd(currentSeconds, "hotPipe", hotPipeTemp - ZeroK, "°C");
                    DiagramAdd(currentSeconds, "boreHoleCenter", BoreHoleField.GetHotEndTemperature(0) - ZeroK, "°C");
                    DiagramAdd(currentSeconds, "boreHoleBorder", BoreHoleField.GetColdEndTemperature(0) - ZeroK, "°C");
                    DiagramAdd(currentSeconds, "heatConsumption", JouleToKW(heatConsumption, step), "kW");
                    DiagramAdd(currentSeconds, "electricityConsumption", JouleToKW(electricityConsumption, step), "kW");
                    DiagramAdd(currentSeconds, "solarEnergy", JouleToKW(solarEnergy, step), "kW");
                    DiagramAdd(currentSeconds, "boreHoleEnergyFlow", JouleToKW(transferredEnergy, step), "kW");
                    DiagramAdd(currentSeconds, "ambientTemperature", GetCurrentTemperature(), "°C");
                    DiagramAdd(currentSeconds, "volumeFlow", volumeFlow * 1000, "l/s"); // m³ -> l
                    DiagramAdd(currentSeconds, "netLoss", JouleToKW(netLoss, step), "kW");
                    DiagramAdd(currentSeconds, "bufferEnergy", JouleToKWh(BufferStorage.GetTotalEnergy(ZeroK + 10)) / 1000, "MWh");
                    DiagramAdd(currentSeconds, "bufferTopTemperature", BufferStorage.TopTemperature - ZeroK, "°C");
                    DiagramAdd(currentSeconds, "bufferBottomTemperature", BufferStorage.BottomTemperature - ZeroK, "°C");
                    if (hourIndex % 24 == 12) // once a day at 12:00
                    {
                        boreHoleEnergyPerDay.Add(JouleToKWh(BoreHoleField.GetTotalEnergy(ZeroK + 10)));
                        DiagramAdd(currentSeconds, "boreHoleEnergy", JouleToKWh(BoreHoleField.GetTotalEnergy(ZeroK + 10)) / 1000, "MWh");
                        //System.Diagnostics.Trace.WriteLine("BoreholeEnergy: " + JouleToKWh(BoreHoleField.GetTotalEnergy(ZeroK + 10)) / 1000);
                    }
                }
            }
            solarPercentage = heatProduced / (electricityTotal + heatProduced);
            electricityTotal = JouleToKWh(electricityTotal) / 1000; // we expect MWh
            heatProduced = JouleToKWh(heatProduced) / 1000; // we expect MWh
            solarTotal = JouleToKWh(solarTotal) / 1000; // we expect MWh
            boreHoleRemoved = JouleToKWh(boreHoleRemoved) / 1000; // we expect MWh
            boreHoleAdded = JouleToKWh(boreHoleAdded) / 1000; // we expect MWh
        }

        private void DiagramAdd(int currentSeconds, string name, double value, string unit)
        {
            string key = name + "|" + unit;
            if (!Diagrams.TryGetValue(key, out List<DiagramEntry>? diagram))
            {
                diagram = Diagrams[key] = new List<DiagramEntry>();
            }
            diagram.Add(new DiagramEntry(currentSeconds, value));
        }

        private double ToCelsius(double temp)
        {
            return temp - ZeroK;
        }
        private double JouleToKWh(double joule)
        {
            return joule / 3600 / 1000;
        }
        private double JouleToKW(double joule, double step)
        {
            return joule / step / 1000;
        }

        public void CheckBoreHoleFieldAndSolarConsistency()
        {
            SolarThermalCollector = new SolarThermalCollector() { Area = 3500 };
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
                if (i % 24 == 12) bhf.Dump("D" + (i / 24).ToString("D4"));
                System.Diagnostics.Trace.WriteLine(currentTime.ToString() + ": " + bhf.GetTemperatureAt(29, 0, -29).ToString());
            }
            long tc1 = DateTime.Now.Ticks;
            double sec = (tc1 - tc0) / 100000.0;
            double kWhTh = bhf.GetTotalEnergy(ZeroK + 10) / 3600 / 1000; // J -> kWh
            double kWhThSolar = totalEnergy / 3600 / 1000; // J -> kWh
            //this.returnPipeTemp = 10 + ZeroK;
            //totalEnergy = 0.0; // accumulate thermal energy
            //excessEnergy = 0.0;
            //BoreHoleField bhf1 = new BoreHoleField(4, ZeroK + 10);
            //step = 60; // step with 69 seconds
            //for (int i = 0; i < HoursPerYear * 3600 / step; i++)
            //{
            //    currentTime = i * step;
            //    SolarThermalCollector.EnergyFlow(this, out double volumetricFlowRate, out double deltaT, out Pipe fromPipe, out Pipe toPipe, out double electricPower);
            //    // water: 4200 J/(kg*K), volumetricFlowRate in m³/s, (volumetricFlowRate * 1000 * 3600) = number of kg in this step (1 hour)
            //    double usedEnergy = volumetricFlowRate * 1000 * step * deltaT * 4200; // Joule produced in this hour by solarthermal collectors
            //    totalEnergy += usedEnergy;
            //    bhf1.TransferEnergie(volumetricFlowRate, returnPipeTemp + deltaT, out double outTemp, step);
            //    if (volumetricFlowRate != 0)
            //    {
            //        excessEnergy += (returnPipeTemp - outTemp) * volumetricFlowRate * step * 4200000 / 3600 / 1000;
            //    }
            //    // bhf.Dump(i.ToString("D4"));
            //}
            //double diff = bhf1.CompareWith(bhf); // 0.035K average difference between all points of the grid, while temperature ranges from 10°C to 50°C. 3600s steps versus 60s steps
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
            SolarThermalCollector = new SolarThermalCollector() { Area = 3500 };
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
2000 & 16\% & 13.1\% & 12.2\% & 8.2\% & 3.8\% & 2.8\% & 3.1\% & 0.8\% & 4.7\% & 8.2\% & 12.2\% & 14.8\% \\
2001 & 15.6\% & 12.7\% & 12\% & 9.6\% & 3.3\% & 4\% & 1\% & 0.9\% & 6.3\% & 6\% & 13.1\% & 15.6\% \\
2002 & 15.5\% & 12\% & 12.2\% & 9.3\% & 5.1\% & 1.5\% & 1.5\% & 0.7\% & 5.6\% & 9.5\% & 12\% & 15.1\% \\
2003 & 16.3\% & 15.6\% & 10.9\% & 8.5\% & 4.3\% & 0.9\% & 0.6\% & 0.7\% & 4.9\% & 10.7\% & 10.8\% & 15.6\% \\
2004 & 14.9\% & 12.8\% & 12.5\% & 7.9\% & 5.9\% & 3.1\% & 1.8\% & 1.2\% & 3.8\% & 7.7\% & 12.5\% & 15.9\% \\
2005 & 14.6\% & 15.7\% & 11.8\% & 7.6\% & 5.5\% & 2.6\% & 1.4\% & 2\% & 4\% & 7\% & 12.4\% & 15.3\% \\
2006 & 17.9\% & 14.4\% & 14.7\% & 9.6\% & 5.1\% & 2.8\% & 0.2\% & 3.6\% & 2.5\% & 6.1\% & 10\% & 13.2\% \\
2007 & 12.6\% & 13\% & 11.9\% & 6.3\% & 4.2\% & 2.1\% & 2.5\% & 2.3\% & 6.1\% & 9.7\% & 13.4\% & 16\% \\
2008 & 13.1\% & 12.8\% & 12.8\% & 9.8\% & 3.5\% & 2.3\% & 1.5\% & 1.4\% & 6.2\% & 9.1\% & 12.1\% & 15.4\% \\
2009 & 18.1\% & 13.7\% & 12.2\% & 6.5\% & 4.5\% & 4.4\% & 1.1\% & 1.2\% & 3.9\% & 9\% & 9.9\% & 15.4\% \\
2010 & 16\% & 12.9\% & 11.1\% & 7.3\% & 6.7\% & 2.3\% & 0.7\% & 2.1\% & 5.3\% & 8.6\% & 10.6\% & 16.5\% \\
2011 & 15.2\% & 14.1\% & 11.8\% & 6.3\% & 4.5\% & 3\% & 2.6\% & 1.7\% & 4.6\% & 9.3\% & 13.3\% & 13.6\% \\
2012 & 14.8\% & 15.4\% & 10.1\% & 8.8\% & 4.1\% & 3.3\% & 2\% & 1.1\% & 5.6\% & 9.3\% & 11.9\% & 13.6\% \\
2013 & 15.3\% & 14.4\% & 14.7\% & 8.3\% & 6.3\% & 3.4\% & 0.5\% & 1.2\% & 4.6\% & 6.8\% & 12\% & 12.4\% \\
2014 & 14.9\% & 13\% & 11.6\% & 7.3\% & 6.2\% & 3.8\% & 0.8\% & 3.4\% & 3.6\% & 7.2\% & 12.5\% & 15.6\% \\
2015 & 15\% & 14.5\% & 12.8\% & 8.8\% & 6\% & 2.7\% & 1.1\% & 1.1\% & 5.4\% & 9.7\% & 11\% & 11.9\% \\
2016 & 14.5\% & 12.9\% & 13.3\% & 9.8\% & 4.4\% & 2.5\% & 1.1\% & 1.2\% & 2.7\% & 9\% & 13.1\% & 15.5\% \\
2017 & 17.9\% & 13\% & 10\% & 10\% & 5\% & 1.7\% & 1.5\% & 1.5\% & 5.3\% & 8\% & 12.4\% & 13.6\% \\
2018 & 14.2\% & 17.6\% & 15.1\% & 6.5\% & 2.9\% & 2\% & 0.5\% & 1\% & 4.8\% & 8.5\% & 12.4\% & 14.4\% \\
2019 & 15.8\% & 13.1\% & 11.1\% & 8.3\% & 7.4\% & 1.2\% & 1.3\% & 1.1\% & 5\% & 8.4\% & 12.9\% & 14.4\% \\
2020 & 14.9\% & 13.1\% & 12.4\% & 8.1\% & 6.6\% & 2.6\% & 1.1\% & 0.8\% & 4.9\% & 8.6\% & 12.7\% & 14.4\% \\
2021 & 14.2\% & 13.8\% & 12.2\% & 11.1\% & 7.2\% & 1.2\% & 0.9\% & 2.2\% & 3.6\% & 8.8\% & 11.8\% & 12.9\% \\

             */
        }
    }
}
