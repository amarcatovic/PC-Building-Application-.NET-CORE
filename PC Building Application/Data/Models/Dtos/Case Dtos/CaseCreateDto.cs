using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data.Models.Dtos.Case_Dtos
{
    public class CaseCreateDto
    {
        public string Name { get; set; }
        public DateTime Released { get; set; }
        public byte NoOfUSB3Ports { get; set; }
        public bool HasRGB { get; set; }
        public bool HasScreen { get; set; }
        public string Size { get; set; }
        public float Price { get; set; }
        public int PhotoId { get; set; }
        public int ManufacturerId { get; set; }
        public string PhotoDescription { get; set; }
        public IFormFile PhotoFile { get; set; }
    }
}
