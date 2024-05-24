using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace DistrictHeating
{
    public class HeatingConsumer : IProsumer
    {
        /// <summary>
        /// The deltaT used for extracting energy from the net. It is fixed to 10°, but there might be some more elaborate dynamic value
        /// </summary>
        public double DeltaTemp { get; set; } = 10;
        /// <summary>
        /// Efficiency of the heatpump in respect to Carnot. 
        /// </summary>
        public double HeatPumpEfficiency { get; set; } = 0.5;
        /// <summary>
        /// Percentage of energy consumption for hot water supply
        /// </summary>
        public double percentageHotWater { get; set; } = 10;
        /// <summary>
        /// Total energy consumption per year in J
        /// </summary>
        public double EnergyConsumptionPerYear { get; set; } = 3000000000.0 * 3600.0;

        private double heatingPowerFactor; // factor scaling the "raw power needed" to match the total energy consumption for heating
        private double hotWaterPowerFactor; // factor scaling the "raw power needed" to match the total energy consumption for hot water

        public void Initialize(Plant plant)
        {
            double sumHeating = 0.0, sumHotWater = 0.0;
            for (int i = 0; i < 8760; i++)
            {
                sumHeating += unscaledHeatingPowerNeeded(plant, i);
                sumHotWater += unscaledHotWaterPowerNeeded(plant, i);
            }
            // heatingPowerFactor*sumHeating == PowerConsumptionPerYear*(100-percentageHotWater)/100 [J] ==>
            heatingPowerFactor = EnergyConsumptionPerYear * (100 - percentageHotWater) / 100 / sumHeating / 3600; // this factor scales the temperature difference of powerNeeded to the actual power in W
            hotWaterPowerFactor = EnergyConsumptionPerYear * percentageHotWater / 100 / sumHotWater / 3600; // this factor scales the temperature difference of powerNeeded to the actual power in W

            double[] perMonth = new double[12]; // verify that the energy needed each month is about the statistical percentage for each mont
            for (int i = 0; i < 8760; i++)
            {
                (int month, int day, int hour) = Climate.HourNumberToDate(i);
                perMonth[month - 1] += heatingPowerFactor * unscaledHeatingPowerNeeded(plant, i) * 3600;
                perMonth[month - 1] += hotWaterPowerFactor * unscaledHotWaterPowerNeeded(plant, i) * 3600;
            }
            double total = 0.0;
            for (int i = 0; i < perMonth.Length; i++) total += perMonth[i];
            for (int i = 0; i < perMonth.Length; i++) perMonth[i] /= total;
        }
        private double unscaledHeatingPowerNeeded(Plant plant, int hourIndex)
        {
            double ambient = plant.Climate.Temperature[hourIndex];
            double ambient24 = 0.0;
            for (int i = 0; i < 24; i++)
            {
                ambient24 += plant.Climate.Temperature[(hourIndex - i + 8760) % 8760];
            }
            ambient24 /= 24; // average ambient temperature for the last 24 hours
            int dayHour = hourIndex % 24;
            double dd = Math.Max(17 - ambient, 0) + 3 * Math.Max(17 - ambient24, 0); // 0, when 17° or more ambient temperature, at -20°: 160, at -10°: 120, at 0°: 80, at 10° 40
            // this is a unscaled measure how much energy we need in this hour according to the ambient temperature and ambient24 temperature. ambient24 is weighted 3 times
            // because the following percentage also respects the average change of ambient temperature
            double res = 0.0;
            switch (dayHour)
            {   // the numbers represent the percentage of heat needed in the respective hours
                case 0: res += dd * 0.79; break;
                case 1: res += dd * 0.79; break;
                case 2: res += dd * 0.95; break;
                case 3: res += dd * 1.11; break;
                case 4: res += dd * 1.74; break;
                case 5: res += dd * 4.35; break;
                case 6: res += dd * 7.91; break;
                case 7: res += dd * 7.11; break;
                case 8: res += dd * 5.69; break;
                case 9: res += dd * 5.14; break;
                case 10: res += dd * 4.90; break;
                case 11: res += dd * 4.74; break;
                case 12: res += dd * 4.51; break;
                case 13: res += dd * 4.43; break;
                case 14: res += dd * 4.19; break;
                case 15: res += dd * 4.51; break;
                case 16: res += dd * 4.74; break;
                case 17: res += dd * 5.22; break;
                case 18: res += dd * 5.69; break;
                case 19: res += dd * 6.25; break;
                case 20: res += dd * 6.40; break;
                case 21: res += dd * 6.09; break;
                case 22: res += dd * 1.74; break;
                case 23: res += dd * 1.03; break;
            }
            return res; // the result is a number, which is proportional to the heating power neede this hour
        }
        private double unscaledHotWaterPowerNeeded(Plant plant, int hourIndex)
        {
            int dayHour = hourIndex % 24;
            double dd = 1.0;
            double res = 0.0;
            switch (dayHour)
            {   // the numbers represent the percentage of energy needed for hot water each hour
                case 0: res += dd * 1.76; break;
                case 1: res += dd * 0.88; break;
                case 2: res += dd * 0.44; break;
                case 3: res += dd * 0.44; break;
                case 4: res += dd * 0.88; break;
                case 5: res += dd * 2.64; break;
                case 6: res += dd * 7.22; break;
                case 7: res += dd * 7.39; break;
                case 8: res += dd * 6.25; break;
                case 9: res += dd * 5.28; break;
                case 10: res += dd * 4.58; break;
                case 11: res += dd * 4.23; break;
                case 12: res += dd * 4.14; break;
                case 13: res += dd * 3.87; break;
                case 14: res += dd * 3.61; break;
                case 15: res += dd * 3.43; break;
                case 16: res += dd * 3.79; break;
                case 17: res += dd * 4.84; break;
                case 18: res += dd * 5.55; break;
                case 19: res += dd * 7.22; break;
                case 20: res += dd * 7.57; break;
                case 21: res += dd * 7.31; break;
                case 22: res += dd * 4.23; break;
                case 23: res += dd * 2.46; break;
            }
            // there is no dependency from the ambient temperature
            return res; // the result is a number, which is proportional to the energy needed for hot water at this hour
        }
        public void EnergyFlow(Plant plant, out double volumetricFlowRate, out double deltaT, out double electricPower)
        {
            double currentHour = plant.currentTime / 3600;
            int hourIndex = (int)Math.Floor(currentHour) % 8760;
            double hp = heatingPowerFactor * unscaledHeatingPowerNeeded(plant, hourIndex);
            double wp = hotWaterPowerFactor * unscaledHotWaterPowerNeeded(plant, hourIndex);
            double totalPowerNeeded = hp + wp; // power in W
            deltaT = -DeltaTemp; // this should not be fixed but calculated from some reasonable data
            if (plant.netFlowTemperature < plant.warmPipeTemp)
            {   // use the warm pipe without heat pump
                electricPower = 0.0;
                volumetricFlowRate = totalPowerNeeded / (4200 * DeltaTemp) / 1000; // "/ 1000": kg (water) -> m³
            }
            else
            {   // we need the heat pump!
                double heatPumpOffset = plant.netFlowTemperature - plant.warmPipeTemp;
                double cop = HeatPumpEfficiency * (plant.netFlowTemperature) / heatPumpOffset;
                electricPower = totalPowerNeeded / cop; // mechanical (electrical) power of the heat pump
                //double netPower = (cop - 1) / cop * plant.netFlowTemperature; // thermal power from the district heating net
                double netPower = totalPowerNeeded-electricPower; // thermal power from the district heating net
                volumetricFlowRate = netPower / (4200 * DeltaTemp) / 1000; // "/ 1000": kg (water) -> m³
            }
        }

    }
    public class HeatingConsumerOld : IProsumer
    {
        public string? Name { get; set; }
        public double[] SupplyTemp { get; set; } = { 20, 30, 38, 44, 50, 56, 62, 68, 72 }; // desired supply temperatures at 20°C, 15°C, ..., -15°C, -20°C ambient temperature
        public double DayTemperature { get; set; }
        public double NightTemperature { get; set; }
        public int DayStartHour { get; set; }
        public int DayEndHour { get; set; }
        public double DeltaTemp { get; set; }
        public double HeatPumpEfficiency { get; set; }
        public int NumberOfInstances { get; set; }
        public double percentageHotWater { get; set; } = 10;
        public double EnergyConsumptionPerYear { get; set; }
        public static HeatingConsumerOld UnderFloorHeating
        {
            get
            {
                return new HeatingConsumerOld
                {
                    Name = "Fußbodenheizung",
                    DayStartHour = 6,
                    DayEndHour = 23,
                    DayTemperature = 20,
                    NightTemperature = 16,
                    EnergyConsumptionPerYear = 10000000.0 * 3600.0,
                    DeltaTemp = 10,
                    SupplyTemp = new double[] { 20, 25, 30, 34, 38, 41, 44, 48, 50 }, // from: https://www.vaillant.de/heizung/heizung-verstehen/tipps-rund-um-ihre-heizung/vorlauf-rucklauftemperatur
                    HeatPumpEfficiency = 0.5,
                    NumberOfInstances = 300
                };
            }
        }
        public static HeatingConsumerOld RadiatorHeating
        {
            get
            {
                return new HeatingConsumerOld
                {
                    Name = "Heizkörperheizung",
                    DayStartHour = 5,
                    DayEndHour = 22,
                    DayTemperature = 20,
                    NightTemperature = 16,
                    EnergyConsumptionPerYear = 15000000.0 * 3600.0,
                    DeltaTemp = 10,
                    SupplyTemp = new double[] { 20, 30, 38, 44, 50, 56, 62, 68, 72 }, // from: https://www.vaillant.de/heizung/heizung-verstehen/tipps-rund-um-ihre-heizung/vorlauf-rucklauftemperatur
                    HeatPumpEfficiency = 0.5,
                    NumberOfInstances = 0
                };
            }
        }
        private double powerFactor; // a factor scaling from temperature difference of supply temperature and ambient temperature to power
        private double heatingPowerFactor;
        private double hotWaterPowerFactor;
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
                else
                {
                    sumEnergy += 1.0;
                }
            }
            // powerFactor*sumPower == PowerConsumptionPerYear [J] ==>
            powerFactor = EnergyConsumptionPerYear / sumEnergy / 3600; // this factor scales the temperature difference of powerNeeded to the actual power in W
            InitializeX(plant);
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
            // if (true)
            {   // we need heating

                double normalized = Math.Min(Math.Max(20 - ambient, 0), 39.9999);
                if (normalized < 1.0) normalized = 1.0; // bad implementation, we need an implementation which also reflects warm water usage
                int supplyIndex = (int)Math.Floor(normalized / 5);
                double normOffset = normalized / 5 - supplyIndex;
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
                        volumetricFlowRate = powerNeeded / (4200 * DeltaTemp) / 1000;
                        volumetricFlowRate *= NumberOfInstances; // this object resembles a single instance of a heating system. But it is used multiple times in the plant
                    }
                    else
                    {   // we need the heat pump!
                        double heatPumpOffset = supplyNeeded - plant.warmPipeTemp + Plant.ZeroK;
                        double cop = HeatPumpEfficiency * (supplyNeeded + Plant.ZeroK) / heatPumpOffset;
                        electricPower = powerNeeded / cop; // mechanical power of the heat pump
                        double netPower = (cop - 1) / cop * powerNeeded; // thermal power from the district heating net
                        volumetricFlowRate = netPower / (4200 * DeltaTemp) / 1000; // "/ 1000": kg (water) -> m³
                        volumetricFlowRate *= NumberOfInstances; // this object resembles a single instance of a heating system. But it is used multiple times in the plant
                        electricPower *= NumberOfInstances;
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
            EnergyFlow(plant, out double vfr, out double dt, out double ep);
        }
        public void InitializeX(Plant plant)
        {
            double sumHeating = 0.0, sumHotWater = 0.0;
            for (int i = 0; i < 8760; i++)
            {
                sumHeating += unscaledHeatingPowerNeeded(plant, i);
                sumHotWater += unscaledHotWaterPowerNeeded(plant, i);
            }
            // heatingPowerFactor*sumHeating == PowerConsumptionPerYear*(100-percentageHotWater)/100 [J] ==>
            heatingPowerFactor = EnergyConsumptionPerYear * (100 - percentageHotWater) / 100 / sumHeating / 3600; // this factor scales the temperature difference of powerNeeded to the actual power in W
            hotWaterPowerFactor = EnergyConsumptionPerYear * percentageHotWater / 100 / sumHotWater / 3600; // this factor scales the temperature difference of powerNeeded to the actual power in W
            double[] perMonth = new double[12];
            for (int i = 0; i < 8760; i++)
            {
                (int month, int day, int hour) = Climate.HourNumberToDate(i);
                perMonth[month - 1] += heatingPowerFactor * unscaledHeatingPowerNeeded(plant, i) * 3600;
                perMonth[month - 1] += hotWaterPowerFactor * unscaledHotWaterPowerNeeded(plant, i) * 3600;
            }
            double total = 0.0;
            for (int i = 0; i < perMonth.Length; i++) total += perMonth[i];
            for (int i = 0; i < perMonth.Length; i++) perMonth[i] /= total;
        }
        private double unscaledHeatingPowerNeeded(Plant plant, int hourIndex)
        {
            double ambient = plant.Climate.Temperature[hourIndex];
            double ambient24 = 0.0;
            for (int i = 0; i < 24; i++)
            {
                ambient24 += plant.Climate.Temperature[(hourIndex - i + 8760) % 8760];
            }
            ambient24 /= 24; // average ambient temperature for the last 24 hours
            int dayHour = hourIndex % 24;
            double dd = Math.Max(17 - ambient, 0) + 3 * Math.Max(17 - ambient24, 0); // 0, when 17° or more ambient temperature, at -20°: 160, at -10°: 120, at 0°: 80, at 10° 40
            // this is a unscaled measure how much energy we need in this hour according to the ambient temperature and ambient24 temperature. ambient24 is weighted 3 times
            // because the following percentage also respects the average change of ambient temperature
            double res = 0.0;
            switch (dayHour)
            {   // the numbers represent the percentage of heat needed in the respective hours
                case 0: res += dd * 0.79; break;
                case 1: res += dd * 0.79; break;
                case 2: res += dd * 0.95; break;
                case 3: res += dd * 1.11; break;
                case 4: res += dd * 1.74; break;
                case 5: res += dd * 4.35; break;
                case 6: res += dd * 7.91; break;
                case 7: res += dd * 7.11; break;
                case 8: res += dd * 5.69; break;
                case 9: res += dd * 5.14; break;
                case 10: res += dd * 4.90; break;
                case 11: res += dd * 4.74; break;
                case 12: res += dd * 4.51; break;
                case 13: res += dd * 4.43; break;
                case 14: res += dd * 4.19; break;
                case 15: res += dd * 4.51; break;
                case 16: res += dd * 4.74; break;
                case 17: res += dd * 5.22; break;
                case 18: res += dd * 5.69; break;
                case 19: res += dd * 6.25; break;
                case 20: res += dd * 6.40; break;
                case 21: res += dd * 6.09; break;
                case 22: res += dd * 1.74; break;
                case 23: res += dd * 1.03; break;
            }
            return res; // the result is a number, which is proportional to the heating power neede this hour
        }
        private double unscaledHotWaterPowerNeeded(Plant plant, int hourIndex)
        {
            int dayHour = hourIndex % 24;
            double dd = 1.0;
            double res = 0.0;
            switch (dayHour)
            {   // the numbers represent the percentage of energy needed for hot water each hour
                case 0: res += dd * 1.76; break;
                case 1: res += dd * 0.88; break;
                case 2: res += dd * 0.44; break;
                case 3: res += dd * 0.44; break;
                case 4: res += dd * 0.88; break;
                case 5: res += dd * 2.64; break;
                case 6: res += dd * 7.22; break;
                case 7: res += dd * 7.39; break;
                case 8: res += dd * 6.25; break;
                case 9: res += dd * 5.28; break;
                case 10: res += dd * 4.58; break;
                case 11: res += dd * 4.23; break;
                case 12: res += dd * 4.14; break;
                case 13: res += dd * 3.87; break;
                case 14: res += dd * 3.61; break;
                case 15: res += dd * 3.43; break;
                case 16: res += dd * 3.79; break;
                case 17: res += dd * 4.84; break;
                case 18: res += dd * 5.55; break;
                case 19: res += dd * 7.22; break;
                case 20: res += dd * 7.57; break;
                case 21: res += dd * 7.31; break;
                case 22: res += dd * 4.23; break;
                case 23: res += dd * 2.46; break;
            }
            // there is no dependency from the ambient temperature
            return res; // the result is a number, which is proportional to the energy needed for hot water at this hour
        }
        public void EnergyFlow(Plant plant, out double volumetricFlowRate, out double deltaT, out double electricPower)
        {
            // set output to no heating at all:

            double currentHour = plant.currentTime / 3600;
            int hourIndex = (int)Math.Floor(currentHour);
            double hp = heatingPowerFactor * unscaledHeatingPowerNeeded(plant, hourIndex);
            double wp = hotWaterPowerFactor * unscaledHotWaterPowerNeeded(plant, hourIndex);
            double totalPowerNeeded = hp + wp; // power in W
            deltaT = -DeltaTemp; // this should not be fixed but calculated from some reasonable data
            if (plant.netFlowTemperature < plant.warmPipeTemp)
            {   // use the warm pipe without heat pump
                electricPower = 0.0;
                volumetricFlowRate = (hp + wp) / (4200 * DeltaTemp) / 1000;
                volumetricFlowRate *= NumberOfInstances; // this object resembles a single instance of a heating system. But it is used multiple times in the plant
            }
            else
            {   // we need the heat pump!
                double heatPumpOffset = plant.netFlowTemperature - plant.warmPipeTemp;
                double cop = HeatPumpEfficiency * (plant.netFlowTemperature) / heatPumpOffset;
                electricPower = totalPowerNeeded / cop; // mechanical (electrical) power of the heat pump
                double netPower = (cop - 1) / cop * plant.netFlowTemperature; // thermal power from the district heating net
                volumetricFlowRate = netPower / (4200 * DeltaTemp) / 1000; // "/ 1000": kg (water) -> m³
                volumetricFlowRate *= NumberOfInstances; // this object resembles a single instance of a heating system. But it is used multiple times in the plant
                electricPower *= NumberOfInstances;
            }
        }
    }
}
