using PC_Building_Application.Data;
using PC_Building_Application.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Helper.Build_Compatibility_Checks
{
    public class MotherboardCompatibilityCheck
    {
        public List<string> CheckMotherboardAndCpuCompatibility(Motherboard mobo, CPU cpu)
        {
            var errorStrings = new List<string>();
            if (mobo.SocketType.Name != cpu.SocketType.Name)
                errorStrings.Add($"CPU's socket {cpu.SocketType.Name} cannot fit onto motherboards socket {mobo.SocketType.Name}");

            return errorStrings;
        }

        public List<string> CheckMotherboardAndRamsCompatibility(Motherboard mobo, IEnumerable<RAM> rams)
        {
            var errorStrings = new List<string>();
            int noOfRamSticks = 0;
            bool compatibleMemoryType = true;
            string ramName = "";

            foreach (var ram in rams)
            {
                noOfRamSticks += ram.NoOfSticks;
                if (ram.Type != mobo.MemoryType)
                {
                    compatibleMemoryType = false;
                    ramName = ram.Name;
                }
            }

            if (noOfRamSticks > mobo.NoOfRAMSlots)
                errorStrings.Add($"Motherboard has {mobo.NoOfRAMSlots} slots for RAM, but there are {noOfRamSticks} included in PC build");

            if (!compatibleMemoryType)
                errorStrings.Add($"{ramName} and motherboard are incompatible. Please pick {mobo.MemoryType} RAM");

            return errorStrings;
        }

        public List<string> CheckMotherboardAndCoolerCompatibility(Motherboard mobo, Cooler cooler)
        {
            var errorStrings = new List<string>();
            bool socketTypeMatch = false;

            var coolerSockets = cooler.CoolerSocketTypes.Select(cst => cst.SocketType);
            foreach (var socket in coolerSockets)
            {
                if (socket.Name == mobo.SocketType.Name)
                {
                    socketTypeMatch = true;
                    break;
                }
            }

            if (!socketTypeMatch)
                errorStrings.Add($"Cooler is not designed for {mobo.SocketType.Name} socket, so it will not fit.");

            return errorStrings;
        }

        public List<string> CheckMotherboardAndStorageCompatibility(Motherboard mobo, IEnumerable<Storage> storages)
        {
            var errorStrings = new List<string>();
            int noOfMoboM2Slots = 0;

            foreach (var storage in storages)
            {
                if (storage.StorageType.Name == "M.2 SSD")
                    ++noOfMoboM2Slots;
            }

            if (noOfMoboM2Slots > mobo.NoOfM2Slots)
                errorStrings.Add($"Motherboard has {mobo.NoOfM2Slots} M.2 Slots, but this PC build includes {noOfMoboM2Slots} M.2 SSDs");

            return errorStrings;
        }
    }
}

