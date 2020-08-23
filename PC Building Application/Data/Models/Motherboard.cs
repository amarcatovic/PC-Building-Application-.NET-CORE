using System;
using System.Collections.Generic;
using System.Linq;
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
        public Manufacturer Manufacturer { get; set; }
        public int ManufacturerId { get; set; }

        public Photo Photo { get; set; }
        public int PhotoId { get; set; }
        public ICollection<PC> PCs { get; set; }
    }
}
