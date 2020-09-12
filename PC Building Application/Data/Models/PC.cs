using PC_Building_Application.Data.Models.Join_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data.Models
{
    public class PC
    {
        public int Id { get; set; }
        public string BuildTitle { get; set; }
        public string BuildDescription { get; set; }
        public DateTime DateBuilt { get; set; }
        public Motherboard Motherboard { get; set; }
        public int MotherboardId { get; set; }
        public CPU CPU { get; set; }
        public int CPUId { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
        public Cooler Cooler { get; set; }
        public int CoolerId { get; set; }
        public PowerSupply PowerSupply { get; set; }
        public int PowerSupplyId { get; set; }
        public Case Case { get; set; }
        public int CaseId { get; set; }
        public ICollection<PCGPU> PCGPUs { get; set; }
        public ICollection<PCRAM> PCRAMs { get; set; }
        public ICollection<PCStorage> PCStorages { get; set; }


        //PC PART COMPATIBILITY CHECH METHODS

        public List<string> CheckMotherboardAndCpuCompatibility()
        {
            var errorStrings = new List<string>();
            if (this.Motherboard.SocketType.Name != this.CPU.SocketType.Name)
                errorStrings.Add($"CPU's socket {this.CPU.SocketType.Name} cannot fit onto motherboards socket {this.Motherboard.SocketType.Name}");

            return errorStrings;
        }

        public List<string> CheckMotherboardAndRamsCompatibility()
        {
            var errorStrings = new List<string>();
            int noOfRamSticks = 0;
            bool compatibleMemoryType = true;
            string ramName = "";

            foreach (var ram in this.PCRAMs.Select(pcram => pcram.RAM))
            {
                noOfRamSticks += ram.NoOfSticks;
                if (ram.Type != this.Motherboard.MemoryType)
                {
                    compatibleMemoryType = false;
                    ramName = ram.Name;
                }
            }

            if (noOfRamSticks > this.Motherboard.NoOfRAMSlots)
                errorStrings.Add($"Motherboard has {this.Motherboard.NoOfRAMSlots} slots for RAM, but there are {noOfRamSticks} included in PC build");

            if (!compatibleMemoryType)
                errorStrings.Add($"{ramName} and motherboard are incompatible. Please pick {this.Motherboard.MemoryType} RAM");

            return errorStrings;
        }

        public List<string> CheckMotherboardAndCoolerCompatibility()
        {
            var errorStrings = new List<string>();
            bool socketTypeMatch = false;

            var coolerSockets = this.Cooler.CoolerSocketTypes.Select(cst => cst.SocketType);
            foreach (var socket in coolerSockets)
            {
                if (socket.Name == this.Motherboard.SocketType.Name)
                {
                    socketTypeMatch = true;
                    break;
                }
            }

            if (!socketTypeMatch)
                errorStrings.Add($"Cooler is not designed for {this.Motherboard.SocketType.Name} socket, so it will not fit.");

            return errorStrings;
        }

        public List<string> CheckMotherboardAndStorageCompatibility()
        {
            var errorStrings = new List<string>();
            int noOfMoboM2Slots = 0;

            foreach (var storage in this.PCStorages.Select(pcs => pcs.Storage))
            {
                if (storage.StorageType.Name == "M.2 SSD")
                    ++noOfMoboM2Slots;
            }

            if (noOfMoboM2Slots > this.Motherboard.NoOfM2Slots)
                errorStrings.Add($"Motherboard has {this.Motherboard.NoOfM2Slots} M.2 Slots, but this PC build includes {noOfMoboM2Slots} M.2 SSDs");

            return errorStrings;
        }

        public List<string> CheckPsuAndStoragesompatibility()
        {
            var errorStrings = new List<string>();
            int noOfSataCablesRequired = 0;

            foreach (var storage in this.PCStorages.Select(pcs => pcs.Storage))
            {
                if (storage.Name != "M.2 SSD")
                    ++noOfSataCablesRequired;
            }

            if (this.PowerSupply.NoOfSATACables < noOfSataCablesRequired)
                errorStrings.Add($"There are {noOfSataCablesRequired} SATA drives, but Power supply has only {this.PowerSupply.NoOfSATACables} SATA power cables");


            return errorStrings;
        }

        public List<string> CheckGpuAndPowerSupplyCompatibility()
        {
            var errorStrings = new List<string>();
            var gpus = this.PCGPUs.Select(pcgpu => pcgpu.GPU);

            foreach (var gpu in gpus)
            {
                if (this.PowerSupply.NoOfPCIe6Pins < gpu.NoOfPCIe6Pins ||
                    this.PowerSupply.NoOfPCIe8Pins < gpu.NoOfPCIe8Pins ||
                    (this.PowerSupply.NoOfPCIe8Pins < 2 * gpu.NoOfPCIe12Pins && this.PowerSupply.NoOfPCIe12Pins < gpu.NoOfPCIe12Pins))
                {
                    string tempErrorString = $"{gpu.Name} requires (";
                    if (gpu.NoOfPCIe6Pins > 0)
                        tempErrorString += $"{gpu.NoOfPCIe6Pins.ToString()}) 6 Pin Connector";
                    if (gpu.NoOfPCIe6Pins > 1)
                        tempErrorString += "s";

                    if (gpu.NoOfPCIe8Pins > 0)
                        tempErrorString += $", ({gpu.NoOfPCIe8Pins.ToString()}) 8 Pin Connector";
                    if (gpu.NoOfPCIe8Pins > 1)
                        tempErrorString += "s";

                    if (gpu.NoOfPCIe12Pins > 0)
                        tempErrorString += $" and ({ gpu.NoOfPCIe12Pins.ToString()}) 12 Pin Connector";
                    if (gpu.NoOfPCIe12Pins > 1)
                        tempErrorString += "s";

                    tempErrorString += ", but Power supply has ";
                    if (this.PowerSupply.NoOfPCIe6Pins > 0)
                        tempErrorString += $"({this.PowerSupply.NoOfPCIe6Pins}) 6 Pin";
                    if (this.PowerSupply.NoOfPCIe8Pins > 0)
                        tempErrorString += $", ({this.PowerSupply.NoOfPCIe8Pins}) 8 Pin";
                    if (this.PowerSupply.NoOfPCIe12Pins > 0)
                        tempErrorString += $", ({this.PowerSupply.NoOfPCIe12Pins}) 12 Pin";

                    if (this.PowerSupply.NoOfPCIe6Pins == 0 && this.PowerSupply.NoOfPCIe8Pins == 0 && this.PowerSupply.NoOfPCIe12Pins == 0)
                        tempErrorString += "no PCIe Pins";
                    else
                        tempErrorString += " PCIe connectors";


                    errorStrings.Add(tempErrorString);
                }
            }

            return errorStrings;
        }
    }
}
