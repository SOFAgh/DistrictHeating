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
        public double EnergyConsumptionPerYear { get; set; }
        public double DayTemperature { get; set; }
        public double NightTemperature { get; set; }
        public int DayStartHour { get; set; }
        public int DayEndHour { get; set; }
        public double DeltaTemp { get; set; }
        public double HeatPumpEfficiency { get; set; }
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
                    EnergyConsumptionPerYear = 10000000.0 * 3600.0,
                    DeltaTemp = 10,
                    SupplyTemp = new double[] { 20, 25, 30, 34, 38, 41, 44, 48, 50 }, // from: https://www.vaillant.de/heizung/heizung-verstehen/tipps-rund-um-ihre-heizung/vorlauf-rucklauftemperatur
                    HeatPumpEfficiency = 0.5
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
                    EnergyConsumptionPerYear = 15000000.0 * 3600.0,
                    DeltaTemp = 10,
                    SupplyTemp = new double[] { 20, 30, 38, 44, 50, 56, 62, 68, 72 }, // from: https://www.vaillant.de/heizung/heizung-verstehen/tipps-rund-um-ihre-heizung/vorlauf-rucklauftemperatur
                    HeatPumpEfficiency = 0.5
                };
            }
        }
        private double powerFactor; // a factor scaling from temperature difference of supply temperature and ambient temperature to power
        public void Initialize(Plant plant)
        {
            double[] temp = plant.Climate.Temperature; // temperature of the yer per hour (8760 entries)
            double sum24 = 0; // the temperatur for the last 24 hours
            for (int i = 0; i < 24; i++) // init with last day in december
            {
                sum24 += temp[8760 - i - 1];
            }
            double sumEnergy = 0;
            for (int hour = 0; hour < 8760; hour++)
            {
                int dayHour = hour % 24;
                double requestedTemperature;
                if (dayHour >= DayStartHour && dayHour < DayEndHour) requestedTemperature = DayTemperature;
                else requestedTemperature = NightTemperature;
                sum24 += temp[hour]; // update the sum of the last 24 hours
                sum24 -= temp[(hour - 24 + 8760) % 8760];
                if (temp[hour] < requestedTemperature && sum24 / 24 < requestedTemperature)
                {   // we need heating
                    double normalized = Math.Min(Math.Max(20 - temp[hour], 0), 39.9999);
                    double normOffset = Math.IEEERemainder(normalized, 5);
                    int supplyIndex = (int)Math.Floor(normalized / 5);
                    double supplyNeeded = SupplyTemp[supplyIndex] + normOffset * (SupplyTemp[supplyIndex + 1] - SupplyTemp[supplyIndex]);
                    double powerNeeded = (supplyNeeded - temp[hour]); // the unscaled power we need for heating is the difference between the supply temperature and the ambient outside temperature
                    // e.g. -20° outside, supplyNeeded = 72, powerNeeded = 79
                    // e.g. 0° outside, supplyNeeded = 50, powerNeeded = 50
                    // e.g. 10° outside, supplyNeeded = 44, powerNeeded = 34
                    sumEnergy += powerNeeded;
                }
            }
            // powerFactor*sumPower == PowerConsumptionPerYear [J] ==>
            powerFactor = EnergyConsumptionPerYear / sumEnergy / 3600; // this factor scales the temperature difference of powerNeeded to the actual power in W
        }
        private double sqr(double d) { return d * d; }
        public void EnergyFlow(Plant plant, out double volumetricFlowRate, out double deltaT, out Pipe fromPipe, out Pipe toPipe, out double electricPower)
        {
            // set output to no heating at all:

            double currentHour = plant.currentTime / 3600;
            int hourIndex = (int)Math.Floor(currentHour);
            double ambient = plant.GetCurrentTemperature();
            double ambient24 = plant.GetMeanTemperature(24);
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
                double powerNeeded = powerFactor * (supplyNeeded - ambient); // the power we need for heating in W at currentTime
                if (plant.UseThreePipes)
                {
                    throw new ApplicationException("three pipes not implemented");
                }
                else
                {
                    deltaT = -DeltaTemp; // this should not be fixed but calculated from some reasonable data
                    fromPipe = Pipe.warmPipe;
                    toPipe = Pipe.returnPipe;
                    if (supplyNeeded < plant.warmPipeTemp - Plant.ZeroK)
                    {   // use the warm pipe without heat pump
                        electricPower = 0.0;
                        volumetricFlowRate = powerNeeded / (4200 * DeltaTemp) / 1000 ;
                    }
                    else
                    {   // we need the heat pump!
                        double heatPumpOffset = supplyNeeded - plant.warmPipeTemp + Plant.ZeroK;
                        double cop = HeatPumpEfficiency * (supplyNeeded+Plant.ZeroK) / heatPumpOffset;
                        electricPower = powerNeeded / cop; // mechanical power of the heat pump
                        double netPower = (cop - 1) / cop * powerNeeded; // thermal power from the district heating net
                        volumetricFlowRate = netPower / (4200 * DeltaTemp) / 1000 ; // "/ 1000": kg (water) -> m³
                    }
                }
            }
            else
            {   // no heating required
                deltaT = 0;
                volumetricFlowRate = 0.0;
                fromPipe = Pipe.returnPipe;
                toPipe = Pipe.returnPipe;
                electricPower = 0.0;
            }
        }
    }
}
