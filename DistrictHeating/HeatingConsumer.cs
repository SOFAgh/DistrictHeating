using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistrictHeating
{
    public class HeatingConsumer : IProsumer
    {
        public string? Name { get; set; }
        public double[] SupplyTemp { get; set; } = { 20, 38, 44, 50, 56, 62, 68, 72 }; // desired supply temperatures at 20°C, 15°C, ..., -15°C, -20°C ambient temperature
        public double PowerConsumptionPerYear { get; set; }
        public double DayTemperature { get; set; }
        public double NightTemperature { get; set; }
        public int DayStartHour { get; set; }
        public int DayEndHour { get; set; }
        public double DeltaTemp { get; set; }
        public static HeatingConsumer UnderFloorHeating
        {
            get
            {
                return new HeatingConsumer
                {
                    Name = "Fußbodenheizung",
                    DayStartHour = 6,
                    DayEndHour = 23,
                    DayTemperature = 20,
                    NightTemperature = 16,
                    PowerConsumptionPerYear = 10000000.0 * 3600.0,
                    DeltaTemp = 10,
                    SupplyTemp = new double[] { 20, 25, 30, 34, 38, 41, 44, 48, 50 } // from: https://www.vaillant.de/heizung/heizung-verstehen/tipps-rund-um-ihre-heizung/vorlauf-rucklauftemperatur
                };
            }
        }
        public static HeatingConsumer RadiatorHeating
        {
            get
            {
                return new HeatingConsumer
                {
                    Name = "Heizkörperheizung",
                    DayStartHour = 5,
                    DayEndHour = 22,
                    DayTemperature = 20,
                    NightTemperature = 16,
                    PowerConsumptionPerYear = 15000000.0 * 3600.0,
                    DeltaTemp = 10,
                    SupplyTemp = new double[] { 20, 38, 44, 50, 56, 62, 68, 72 } // from: https://www.vaillant.de/heizung/heizung-verstehen/tipps-rund-um-ihre-heizung/vorlauf-rucklauftemperatur
                };
            }
        }

        public void Step(out double volumeFlow, out double flowTemperature, out Pipe fromPipe, out Pipe toPipe, out double electricity)
        {
            // set output to no heating at all:
            volumeFlow = 0.0;
            flowTemperature = 0.0;
            fromPipe = Pipe.returnPipe;
            toPipe = Pipe.returnPipe;
            electricity = 0.0;

            double currentHour = DistrictHeating.Plant.currentTime / 3600;
            int hourIndex = (int)Math.Floor(currentHour);
            double ambient = DistrictHeating.Plant.GetCurrentTemperature();
            double ambient24 = DistrictHeating.Plant.GetMeanTemperature(24);
            int dayHour = hourIndex % 24;
            double requestedTemperature;
            if (dayHour >= DayStartHour && dayHour < DayEndHour) requestedTemperature = DayTemperature;
            else requestedTemperature = NightTemperature;
            if (ambient < requestedTemperature && ambient24 < requestedTemperature)
            {   // we need heating

                double normalized = Math.Min(Math.Max(20 - ambient, 0), 39.9999);
                double normOffset = Math.IEEERemainder(normalized, 5);
                int supplyIndex = (int)Math.Floor(normalized / 5);
                double supplyNeeded = SupplyTemp[supplyIndex] + normOffset * (SupplyTemp[supplyIndex + 1] - SupplyTemp[supplyIndex]);
                if (!Plant.UseThreePipes || supplyNeeded < DistrictHeating.Plant.warmPipeTemp)
                {   // use the warm pipe

                }
            }
        }
    }
}
