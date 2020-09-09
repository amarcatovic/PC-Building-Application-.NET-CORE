using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data.Models.Dtos.CPU_Dtos
{
    public class CPUCreateDto
    {
        public string Name { get; set; }
        public DateTime Released { get; set; }
        public int SocketTypeId { get; set; }
        public string Clockspeed { get; set; }
        public string TurboSpeed { get; set; }
        public int NoOfCores { get; set; }
        public int SingleThreadRating { get; set; }
        public int ManufacturerId { get; set; }
        public int PhotoId { get; set; }
        public string PhotoDescription { get; set; }
        public IFormFile PhotoFile { get; set; }
    }
}
