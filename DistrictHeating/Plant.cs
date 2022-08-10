using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace DistrictHeating
{
    public enum Pipe { returnPipe, warmPipe, hotPipe };
    /// <summary>
    /// the plant: contains information about the current state of the heating system.
    /// 
    /// </summary>
    internal static class Plant
    {
        static Plant() 
        {
            currentTime = 0;
            useThreePipes = false;
            System.Text.Json.JsonDocument jsonDocument = JsonDocument.Parse("");
            System.Text.Json.JsonElement root = jsonDocument.RootElement;
            double[] test = { 1, 2, 3, 4, 5 };
            test[0] = test[1];
        }
        public static int currentTime; // number of hours since first of january of the simulation
        public static double returnPipeTemp; // current temperature of the return pipe [K]
        public static double returnPipeFlow; // current volume flow of the return pipe [l/s]
        public static double warmPipeTemp; // current temperature of the warm pipe [K]
        public static double warmPipeFlow; // current volume flow of the warm pipe [l/s]
        public static double hotPipeTemp; // current temperature of the hot pipe [K]
        public static double hotPipeFlow; // current volume flow of the hot pipe [l/s]
        public static readonly bool useThreePipes = false; // 
        public static readonly double warmPipeMinTemp = 40; // minimum temperature for the warm pipe
        public static readonly double hotPipeMinTemp = 50; // minimum temperature for the hot pipe
        public static readonly double[] hotPipeSupplyTemp = { 0, 38, 44, 50, 56, 62, 68, 72 }; // desired supply temperatures at 20°C, 15°C, ..., -15°C, -20°C ambient temperature
    }
}
