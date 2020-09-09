using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data.Models.Dtos
{
    public class MotherboardReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Released { get; set; }
        public string SocketType { get; set; }
        public int MaxMemmoryFreq { get; set; }
        public string MemoryType { get; set; }
        public int NoOfM2Slots { get; set; }
        public bool HasRGB { get; set; }
        public int NoOfPCIeSlots { get; set; }
        public int NoOfRAMSlots { get; set; }
        public float Price { get; set; }
        public string Manufacturer { get; set; }
        public PhotoReturnDto Photo { get; set; }
    }
}
