using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistrictHeating
{
    public class BufferStorage
    {
        /// <summary>
        /// Volume of the storage, water in m³
        /// </summary>
        public double Volume = 500;
        /// <summary>
        /// Energy transfer of the heat exchanger in W/K
        /// </summary>
        public double EnergyTransfer = 1000;
        /// <summary>
        /// Number of buffer storages connected in series. There might be several beuffer storages connected in series or a single storage with layers of water
        /// </summary>
        public int NumberOfStorages = 10;
        /// <summary>
        /// Heat loss to the environment via the surface in W/K, where K is the temperature difference between water and ambient air
        /// </summary>
        public double HeatLoss = 0.05;
        public double StartTemperature = 293;
        private double[] temperature = new double[0]; // the temperature of each storage
        public void Initialize()
        {
            temperature = new double[NumberOfStorages];
            for (int i = 0; i < temperature.Length; i++)
            {
                temperature[i] = StartTemperature;
            }
        }
        public double TopTemperature
        {
            get { return temperature[0]; }
        }
        public double BottomTemperature
        {
            get { return temperature[temperature.Length - 1]; }
        }
        public void TransferEnergie(double volumeStream, double inTemperature, out double outTemperature, double duration)
        {
            if (volumeStream == 0 || NumberOfStorages == 0)
            {
                outTemperature = inTemperature;
                return;
            }
            double currentTemperature = inTemperature;
            double bufferVolume = Volume / NumberOfStorages;
            double transferWaterVolume = Math.Abs(volumeStream * duration); // water running through the heat exchanger in m³
            for (int i = 0; i < temperature.Length; i++)
            {
                int index = i;
                if (volumeStream < 0) index = temperature.Length - i - 1; // flowing "backward"
                double meanTemperatur = (transferWaterVolume * inTemperature + bufferVolume * temperature[index]) / (transferWaterVolume + bufferVolume);
                double maxEnergyTransfer = (meanTemperatur - temperature[index]) * bufferVolume * 4200000; // maximum energy that can be transferred
                double deltaT = inTemperature - temperature[index]; // deltaT is positiv when loading, negative when unloading heat
                double power = deltaT * EnergyTransfer / NumberOfStorages;
                double energyToTransfer = power * duration;
                // updating the temperature of each segemnt of the buffer storage
                if (Math.Abs(maxEnergyTransfer) < Math.Abs(energyToTransfer))
                {
                    temperature[index] = meanTemperatur;
                    inTemperature = meanTemperatur;
                }
                else
                {   // heatcapacity of water is 4.2 kJ/(kg*K) or 4200000 J/(m³*K)
                    //temperature[index] = (temperature[index] * bufferVolume * 4200000 + energyToTransfer) / (bufferVolume * 4200000);
                    //inTemperature = (inTemperature * transferWaterVolume * 4200000 - energyToTransfer) / (transferWaterVolume * 4200000);
                    temperature[index] = temperature[index] + energyToTransfer / (bufferVolume * 4200000);
                    inTemperature = inTemperature - energyToTransfer / (transferWaterVolume * 4200000);
                }
            }
            outTemperature = inTemperature;

        }

        /// <summary>
        /// Total energy contained in the buffer storage relative to baseTemperature
        /// </summary>
        /// <param name="baseTemperature"></param>
        /// <returns></returns>
        internal double GetTotalEnergy(double baseTemperature)
        {
            double res = 0.0;
            double bufferVolume = Volume / NumberOfStorages;
            for (int i = 0; i < temperature.Length; i++)
            {
                res += bufferVolume * (temperature[i] - baseTemperature) * 4200000;
            }
            return res;
        }
    }
}