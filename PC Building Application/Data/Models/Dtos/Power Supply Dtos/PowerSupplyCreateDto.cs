using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data.Models.Dtos.Power_Supply_Dtos
{
    public class PowerSupplyCreateDto
    {
        public string Name { get; set; }
        public DateTime Released { get; set; }
        public string Power { get; set; }
        public byte NoOfPCIe6Pins { get; set; }
        public byte NoOfPCIe8Pins { get; set; }
        public byte NoOfSATACables { get; set; }
        public byte NoOfCPUCables { get; set; }
        public bool Has24PinCable { get; set; }
        public byte EfficiencyRating { get; set; }
        public float Price { get; set; }
        public int PhotoId { get; set; }
        public int ManufacturerId { get; set; }
        public string PhotoDescription { get; set; }
        public IFormFile PhotoFile { get; set; }
    }
}
