using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data.Models
{
    public class PowerSupply
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Released { get; set; }
        public string Power { get; set; }
        public byte NoOfPCIe6Pins { get; set; }
        public byte NoOfPCIe8Pins { get; set; }
        public byte NoOfPCIe12Pins { get; set; }
        public byte NoOfSATACables { get; set; }
        public byte NoOfCPUCables { get; set; }
        public bool Has24PinCable { get; set; }
        public string EfficiencyRating { get; set; }
        public float Price { get; set; }
        public Photo Photo { get; set; }
        public int PhotoId { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public int ManufacturerId { get; set; }
        public ICollection<PC> PCs { get; set; }

        // COMPATIBILITY CHECK METHODS
        public List<string> CheckPsuAndStoragesompatibility(IEnumerable<Storage> storages)
        {
            var errorStrings = new List<string>();
            int noOfSataCablesRequired = 0;
            
            foreach(var storage in storages)
            {
                if (storage.Name != "M.2 SSD")
                    ++noOfSataCablesRequired;
            }

            if (this.NoOfSATACables < noOfSataCablesRequired)
                errorStrings.Add($"There are {noOfSataCablesRequired} SATA drives, but Power supply has only {this.NoOfSATACables} SATA power cables");


            return errorStrings;
        }
    }
}
