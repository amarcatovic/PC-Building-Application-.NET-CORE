using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data.Models.Dtos
{
    public class MotherboardCreateDto
    {
        public string Name { get; set; }
        public DateTime Released { get; set; }
        public int SocketTypeId { get; set; }
        public int MaxMemmoryFreq { get; set; }
        public string MemoryType { get; set; }
        public int NoOfM2Slots { get; set; }
        public bool HasRGB { get; set; }
        public int NoOfPCIeSlots { get; set; }
        public int NoOfRAMSlots { get; set; }
        public int ManufacturerId { get; set; }
        public int PhotoId { get; set; }
        public string PhotoDescription { get; set; }
        public IFormFile PhotoFile { get; set; }
    }
}
