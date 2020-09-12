using PC_Building_Application.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Helper.Build_Compatibility_Checks
{
    public class GPUCompatibilityCheck
    {
        public List<string> CheckGpuAndPowerSupplyCompatibility(GPU gpu, PowerSupply powerSupply)
        {
            var errorStrings = new List<string>();
            if (powerSupply.NoOfPCIe6Pins < gpu.NoOfPCIe6Pins ||
                powerSupply.NoOfPCIe8Pins < gpu.NoOfPCIe8Pins ||
                (powerSupply.NoOfPCIe8Pins < 2 * gpu.NoOfPCIe12Pins && powerSupply.NoOfPCIe12Pins < gpu.NoOfPCIe12Pins))
            {
                string tempErrorString = "GPU requires (";
                if (gpu.NoOfPCIe6Pins > 0)
                    tempErrorString += gpu.NoOfPCIe6Pins.ToString() + ") 6 Pin Connector";
                if (gpu.NoOfPCIe6Pins > 1)
                    tempErrorString += "s";

                if (gpu.NoOfPCIe8Pins > 0)
                    tempErrorString += ", (" + gpu.NoOfPCIe8Pins.ToString() + ") 8 Pin Connector";
                if (gpu.NoOfPCIe8Pins > 1)
                    tempErrorString += "s";

                if (gpu.NoOfPCIe12Pins > 0)
                    tempErrorString += " and (" + gpu.NoOfPCIe12Pins.ToString() + ") 12 Pin Connector";
                if (gpu.NoOfPCIe12Pins > 1)
                    tempErrorString += "s";

                tempErrorString += ", but Power supply has ";
                if (powerSupply.NoOfPCIe6Pins > 0)
                    tempErrorString += $"({powerSupply.NoOfPCIe6Pins}) 6 Pin";
                if (powerSupply.NoOfPCIe8Pins > 0)
                    tempErrorString += $", ({powerSupply.NoOfPCIe8Pins}) 8 Pin";
                if (powerSupply.NoOfPCIe12Pins > 0)
                    tempErrorString += $", ({powerSupply.NoOfPCIe12Pins}) 12 Pin";

                if (powerSupply.NoOfPCIe6Pins == 0 && powerSupply.NoOfPCIe8Pins == 0 && powerSupply.NoOfPCIe12Pins == 0)
                    tempErrorString += "no PCIe Pins";
                else
                    tempErrorString += " PCIe connectors";


                errorStrings.Add(tempErrorString);
            }

            return errorStrings;
        }
    }
}
