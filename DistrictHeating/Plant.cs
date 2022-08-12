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
        public static Plant thePlant;
        public Plant(int n)
        {
            currentTime = 0;
            useThreePipes = false;
            Climate = new Climate();
            JsonSerializer serializer = new JsonSerializer();
            serializer.Converters.Add(new JavaScriptDateTimeConverter());
            serializer.NullValueHandling = NullValueHandling.Ignore;

            using (StreamWriter sw = new StreamWriter(@"c:\Temp\jsontest.json"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, this);
            }
            using (StreamReader sr = new StreamReader(@"c:\Temp\jsontest.json"))
            {
                string jstr = sr.ReadToEnd();
                // the following works:
                Plant dbg = JsonConvert.DeserializeObject<Plant>(jstr);
            }
            thePlant = this;
        }
        public Plant()
        {
            Climate = new Climate();
            thePlant = this;
        }
        public double currentTime; // number of seconds since first of january of the simulation
        public double returnPipeTemp; // current temperature of the return pipe [K]
        public double returnPipeFlow; // current volume flow of the return pipe [l/s]
        public double warmPipeTemp; // current temperature of the warm pipe [K]
        public double warmPipeFlow; // current volume flow of the warm pipe [l/s]
        public double hotPipeTemp; // current temperature of the hot pipe [K]
        public double hotPipeFlow; // current volume flow of the hot pipe [l/s]
        protected bool useThreePipes { get; set; } = false; // 
        public double WarmPipeMinTemp { get; set; } = 40; // minimum temperature for the warm pipe
        public double HotPipeMinTemp { get; set; } = 50; // minimum temperature for the hot pipe
        public double[] HotPipeSupplyTemp { get; set; } = { 0, 38, 44, 50, 56, 62, 68, 72 }; // desired supply temperatures at 20°C, 15°C, ..., -15°C, -20°C ambient temperature
        public Climate Climate { get; set; }
        public static bool UseThreePipes
        {
            get { return thePlant.useThreePipes; }
        }

        internal double GetCurrentTemperature()
        {
            double currentHour = DistrictHeating.Plant.currentTime / 3600;
            int hourIndex = (int)Math.Floor(currentHour);
            return Climate.Temperature[hourIndex];
        }

        internal double GetMeanTemperature(int numHours)
        {
            if (numHours <= 0) return GetCurrentTemperature();
            double currentHour = DistrictHeating.Plant.currentTime / 3600;
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
    }
}
