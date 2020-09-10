using PC_Building_Application.Data.Models.Dtos.Socket_Type_Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data.Models.Dtos.Cooler_Dtos
{
    public class CoolerReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Released { get; set; }
        public bool IsWaterCooler { get; set; }
        public byte NoOfFans { get; set; }
        public bool HasRGB { get; set; }
        public float Price { get; set; }
        public PhotoReturnDto Photo { get; set; }
        public string Manufacturer { get; set; }
        public List<string> Sockets { get; set; }
    }
}
