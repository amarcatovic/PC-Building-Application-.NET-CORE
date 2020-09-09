using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data.Models.Dtos.RAM_Dtos
{
    public class RAMCreateDto
    {
        public string Name { get; set; }
        public DateTime Released { get; set; }
        public int Speed { get; set; }
        public string Type { get; set; }
        public sbyte NoOfSticks { get; set; }
        public string CapacityPerStick { get; set; }
        public bool HasRGB { get; set; }
        public float Price { get; set; }
        public int PhotoId { get; set; }
        public string PhotoDescription { get; set; }
        public IFormFile PhotoFile { get; set; }
    }
}
