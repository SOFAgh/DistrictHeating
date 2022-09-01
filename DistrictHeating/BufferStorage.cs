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
        public double Volume { get; set; } = 50;
        /// <summary>
        /// Energy transfer of the heat exchanger in W/K
        /// </summary>
        public double EnergyTransfer { get; set; } = 100;
        /// <summary>
        /// Number of buffer storages connected in series. There might be several beuffer storages connected in series or a single storage with layers of water
        /// </summary>
        public int NumberOfStorages { get; set; } = 2;
        /// <summary>
        /// Heat loss to the environment via the surface in W/K, where K is the temperature difference between water and ambient air
        /// </summary>
        public double HeatLoss { get; set; } = 0.05;
        public double CurrentTemperature { get; set; } = 293;
        public void TransferEnergie(double volumeStream, double inTemperature, out double outTemperature, double duration)
        {
            if (volumeStream == 0)
            {
                outTemperature = inTemperature;
                return;
            }
            double bufferVolume = Volume * NumberOfStorages;
            double transferWaterVolume = volumeStream * duration; // water running through the heat exchanger in m³
            double meanTemperatur = (transferWaterVolume * inTemperature + bufferVolume * CurrentTemperature) / (transferWaterVolume + bufferVolume);
            double maxEnergyTransfer = (meanTemperatur - CurrentTemperature) * bufferVolume * 4200000; // maximum energy that can be transferred
            double deltaT = inTemperature - CurrentTemperature; // deltaT is positiv when loading, negative when unloading heat
            double power = deltaT * EnergyTransfer;
            double energyToTransfer = power * duration;
            if (Math.Abs(maxEnergyTransfer) < Math.Abs(energyToTransfer))
            {
                CurrentTemperature = meanTemperatur;
                outTemperature = meanTemperatur;
            }
            else
            {
                CurrentTemperature = (CurrentTemperature * bufferVolume * 4200000 + energyToTransfer) / (bufferVolume * 4200000);
                outTemperature = (inTemperature * transferWaterVolume * 4200000 + energyToTransfer) / (transferWaterVolume * 4200000);
            }
        }
    }
}