using System;
using System.Collections.Generic;
using System.Text;

namespace DistrictHeating
{
    public class ConcentratingHeatPump
    {
        /// <summary>
        /// The peak power of the photovoltaic in W
        /// </summary>
        public double PeakPower; // in W
        /// <summary>
        /// The electrical power required for the heatpump (not modulated) in W
        /// </summary>
        public double HeatPumpPower; // in W
        /// <summary>
        /// The capacity of the battery in Wh
        /// </summary>
        public double BatteryCapacity; // in Wh

        private double powerFactor = 0.0;
        private double maxElectricPower = 0.0;
        private double maxThermalPower = 0.0;

        private double batteryLoaded; // amount of Wh in the battery
        public void Initialize(Plant plant)
        {
            batteryLoaded = 0.0;
            double globalSolarRadiation = 0.0;
            for (int hour = 0; hour < Plant.HoursPerYear; hour++)
            {
                globalSolarRadiation += plant.Climate.GlobalSolarRadiation[hour];
            }
            powerFactor = PeakPower * 1000 / globalSolarRadiation; // assuming total power per year = 1000*PeakPower
            globalSolarRadiation = 0.0;
            for (int hour = 0; hour < Plant.HoursPerYear; hour++)
            {
                globalSolarRadiation += powerFactor * plant.Climate.GlobalSolarRadiation[hour];
            }
        }
        /*
         * Gegeben: elektrische Leistung, Temperatur des kalten Rings, wie das Wasser auf die kalte Seite der Wärmepumpe eintritt,
         * Temperatur des Rücklaufs, wie das Wasser auf der warmen Seite eintritt. Zu bestimmen sind jetzt: Volumenstrom und Temperaturdifferenz
         * auf der kalten und ebenso auf der warmen Seite, beides kann auch als Leistung betrachtet werden. Wenn wir die Zieltemperatur vorgeben, 
         * dann kennen wir den COP=zt/(zt-ct)*0.5 . Damit kennen wir die Leistung, mit der Wärme entzogen und erzeugt wird. Die erzeugte ist 
         * um die elektrische Leistung größer als die entzogene. Erzeugung: COP*el, Entzug: (COP-1)*el. Damit kann man den Volumenstrom auf
         * der warmen Seite bestimmen und bei einem anzunehmende dt für die kalte Seite auch den Volumenstrom dort.
         * Wir brauchen also noch zusätzlich die gewünschte hotMinOutTemp.
         */
        public void EnergyFlow(Plant plant, double step, bool isHeating, double coldInTemp, double hotInTemp, out double coldVolumetricFlowRate, out double hotVolumetricFlowRate, out double coldOutTemp, out double hotOutTemp)
        {
            double minOutTemp = plant.BoreHoleField.TemperatureAtCenter;
            double availablePower = powerFactor * plant.Climate.GlobalSolarRadiation[plant.CurrentHourIndex]; // power in W
            maxElectricPower = Math.Max(maxElectricPower, availablePower);
            double stepHour = step / 3600;
            double elEnergy = availablePower * stepHour; // electrical energy in this step in Wh
            bool loadBattery = !isHeating || availablePower > HeatPumpPower;
            if (batteryLoaded < BatteryCapacity && loadBattery) // when it is not heating, i.e. there is more sun than needed
            {
                if (batteryLoaded + elEnergy * 0.9 < BatteryCapacity)
                {
                    batteryLoaded += elEnergy * 0.9; // loading battery with 90% efficiency
                    coldOutTemp = coldInTemp;
                    hotOutTemp = hotInTemp;
                    coldVolumetricFlowRate = 0.0;
                    hotVolumetricFlowRate = 0.0;
                    return; // all energy goes into the battery and it is daytime, don*t use the heatpump
                }
                else
                {
                    elEnergy -= (BatteryCapacity - batteryLoaded) / 0.9;
                    if (elEnergy < 0.0) elEnergy = 0.0;
                    batteryLoaded = BatteryCapacity;
                }
            }
            if ((isHeating && batteryLoaded > 0.0) || batteryLoaded >= BatteryCapacity)
            {   // run the heatpump if we need heat or the battery is full
                availablePower = elEnergy / stepHour;
                double energyNeeded = HeatPumpPower * stepHour;
                double availableEnergy = availablePower * stepHour;
                double availabeHeatPumpPower = HeatPumpPower;
                if (availableEnergy < energyNeeded)
                {
                    batteryLoaded -= (energyNeeded - availableEnergy); // could result in negativ load of battery
                    if (batteryLoaded < 0.0)
                    {
                        availabeHeatPumpPower = (batteryLoaded + energyNeeded - availableEnergy) / stepHour;
                        batteryLoaded = 0.0;
                    }
                }
                // if there is more energy than we can use, this part of the energy will be lost

                // now let aus run the heatpump with the HeatPumpPower
                coldOutTemp = Math.Max(Plant.ZeroK, coldInTemp - 10); // never below 0°
                double coldDeltaT = coldInTemp - coldOutTemp;
                // hotOutTemp = hotInTemp + (Plant.ZeroK + 100 - hotInTemp) / 2.0;
                hotOutTemp = Math.Min(60 + Plant.ZeroK, minOutTemp + 30); // arbitrary values, may be specified
                if (hotOutTemp < hotInTemp) hotOutTemp = hotInTemp + 10;
                double hotDeltaT = hotOutTemp - hotInTemp;
                if (coldDeltaT <= 0.0 || hotDeltaT <= 0.0)
                {
                    coldOutTemp = coldInTemp;
                    hotOutTemp = hotInTemp;
                    coldVolumetricFlowRate = 0.0;
                    hotVolumetricFlowRate = 0.0;
                }
                else
                {
                    double cop = 0.5 * hotOutTemp / (hotOutTemp - coldInTemp); // Carnot * 0.5
                    double heatingPower = cop * availabeHeatPumpPower;
                    double coolingPower = (cop - 1) * availabeHeatPumpPower;
                    coldVolumetricFlowRate = coolingPower / (4200 * coldDeltaT) / 1000; // "/ 1000": kg (water) -> m³
                    hotVolumetricFlowRate = heatingPower / (4200 * hotDeltaT) / 1000; // "/ 1000": kg (water) -> m³
                    maxThermalPower = Math.Max(maxThermalPower, heatingPower);
                }
            }
            else
            {   // night and no battery left
                coldOutTemp = coldInTemp;
                hotOutTemp = hotInTemp;
                coldVolumetricFlowRate = 0.0;
                hotVolumetricFlowRate = 0.0;
            }
            if (double.IsNaN(coldOutTemp) || double.IsNaN(hotOutTemp) || double.IsNaN(coldVolumetricFlowRate) || double.IsNaN(hotVolumetricFlowRate))
            { }
        }
    }
}
