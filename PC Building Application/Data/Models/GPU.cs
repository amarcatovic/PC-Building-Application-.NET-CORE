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
    }
}
