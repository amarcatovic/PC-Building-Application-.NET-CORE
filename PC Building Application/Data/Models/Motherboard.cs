using CloudinaryDotNet.Actions;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_Building_Application.Data.Models
{
    public class Motherboard
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Released { get; set; }
        public SocketType SocketType { get; set; }
        public int SocketTypeId { get; set; }
        public int MaxMemmoryFreq { get; set; }
        public string MemoryType { get; set; }
        public int NoOfM2Slots { get; set; }
        public bool HasRGB { get; set; }
        public int NoOfPCIeSlots { get; set; }
        public int NoOfRAMSlots { get; set; }
        public float Price { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public int ManufacturerId { get; set; }
        public Photo Photo { get; set; }
        public int PhotoId { get; set; }
        public ICollection<PC> PCs { get; set; }


        // COMPATIBILITY CHECK METHODS
        public List<string> CheckMotherboardAndCpuCompatibility(CPU cpu)
        {
            var errorStrings = new List<string>();
            if (this.SocketType.Name != cpu.SocketType.Name)
                errorStrings.Add($"CPU's socket {cpu.SocketType.Name} cannot fit onto motherboards socket {this.SocketType.Name}");

            return errorStrings;
        }

        public List<string> CheckMotherboardAndRamsCompatibility(IEnumerable<RAM> rams)
        {
            var errorStrings = new List<string>();
            int noOfRamSticks = 0;
            bool compatibleMemoryType = true;
            string ramName = "";

            foreach(var ram in rams)
            {
                noOfRamSticks += ram.NoOfSticks;
                if (ram.Type != this.MemoryType)
                {
                    compatibleMemoryType = false;
                    ramName = ram.Name;
                }                  
            }

            if (noOfRamSticks > this.NoOfRAMSlots)
                errorStrings.Add($"Motherboard has {this.NoOfRAMSlots} slots for RAM, but there are {noOfRamSticks} included in PC build");

            if (!compatibleMemoryType)
                errorStrings.Add($"{ramName} and motherboard are incompatible. Please pick {this.MemoryType} RAM");

            return errorStrings;
        }

        public List<string> CheckMotherboardAndCoolerCompatibility(Cooler cooler)
        {
            var errorStrings = new List<string>();
            bool socketTypeMatch = false;

            var coolerSockets = cooler.CoolerSocketTypes.Select(cst => cst.SocketType);
            foreach(var socket in coolerSockets)
            {
                if (socket.Name == this.SocketType.Name)
                {
                    socketTypeMatch = true;
                    break;
                }
            }

            if (!socketTypeMatch)
                errorStrings.Add($"Cooler is not designed for {this.SocketType.Name} socket, so it will not fit.");

            return errorStrings;
        }

        public List<string> CheckMotherboardAndStorageCompatibility(IEnumerable<Storage> storages)
        {
            var errorStrings = new List<string>();
            int noOfMoboM2Slots = 0;

            foreach(var storage in storages)
            {
                if (storage.StorageType.Name == "M.2 SSD")
                    ++noOfMoboM2Slots;
            }

            if (noOfMoboM2Slots > this.NoOfM2Slots)
                errorStrings.Add($"Motherboard has {this.NoOfM2Slots} M.2 Slots, but this PC build includes {noOfMoboM2Slots} M.2 SSDs");

            return errorStrings;
        }
    }
}
