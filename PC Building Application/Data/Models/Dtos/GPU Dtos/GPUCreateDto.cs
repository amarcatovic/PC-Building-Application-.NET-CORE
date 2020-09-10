using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data.Models.Dtos.GPU_Dtos
{
    public class GPUCreateDto
    {
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
        public int PhotoId { get; set; }
        public int ManufacturerId { get; set; }
        public string PhotoDescription { get; set; }
        public IFormFile PhotoFile { get; set; }
    }
}
