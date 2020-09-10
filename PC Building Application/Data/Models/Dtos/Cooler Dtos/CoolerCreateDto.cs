using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data.Models.Dtos.Cooler_Dtos
{
    public class CoolerCreateDto
    {
        public string Name { get; set; }
        public DateTime Released { get; set; }
        public bool IsWaterCooler { get; set; }
        public byte NoOfFans { get; set; }
        public bool HasRGB { get; set; }
        public float Price { get; set; }
        public int PhotoId { get; set; }
        public int ManufacturerId { get; set; }
        public string PhotoDescription { get; set; }
        public IFormFile PhotoFile { get; set; }
        public IEnumerable<int> SocketTypeIds { get; set; }
    }
}
