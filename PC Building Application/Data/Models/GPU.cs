using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data.Models
{
    public class GPU
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Released { get; set; }
        public string PCIPort { get; set; }
        public string MemoryType { get; set; }
        public string VRAM { get; set; }
        public int NoOfHDMIPorts { get; set; }
        public int NoOfDisplayPorts { get; set; }
        public bool HasVGA { get; set; }
        public bool HasDVI { get; set; }
        public float Price { get; set; }
        public byte NoOfPCIe6Pins { get; set; }
        public byte NoOfPCIe8Pins { get; set; }
        public byte NoOfPCIe12Pins { get; set; }
        public Photo Photo { get; set; }
        public int PhotoId { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public int ManufacturerId { get; set; }
        public ICollection<PC> PCs { get; set; }


        // COMPATIBILITY CHECK METHODS
        public List<string> CheckGpuAndPowerSupplyCompatibility(PowerSupply powerSupply)
        {
            var errorStrings = new List<string>();
            if(powerSupply.NoOfPCIe6Pins < this.NoOfPCIe6Pins || 
                powerSupply.NoOfPCIe8Pins < this.NoOfPCIe8Pins || 
                (powerSupply.NoOfPCIe8Pins < 2 * this.NoOfPCIe12Pins && powerSupply.NoOfPCIe12Pins < this.NoOfPCIe12Pins))
            {
                string tempErrorString = "GPU requires (";
                if(this.NoOfPCIe6Pins > 0)
                    tempErrorString += this.NoOfPCIe6Pins.ToString() + ") 6 Pin Connector";
                if (this.NoOfPCIe6Pins > 1)
                    tempErrorString += "s";

                if (this.NoOfPCIe8Pins > 0)
                    tempErrorString += ", (" + this.NoOfPCIe8Pins.ToString() + ") 8 Pin Connector";
                if (this.NoOfPCIe8Pins > 1)
                    tempErrorString += "s";

                if (this.NoOfPCIe12Pins > 0)
                    tempErrorString += " and (" + this.NoOfPCIe12Pins.ToString() + ") 12 Pin Connector";
                if (this.NoOfPCIe12Pins > 1)
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
