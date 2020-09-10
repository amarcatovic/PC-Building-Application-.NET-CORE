using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data.Models.Dtos.Case_Dtos
{
    public class CaseReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Released { get; set; }
        public byte NoOfUSB3Ports { get; set; }
        public bool HasRGB { get; set; }
        public bool HasScreen { get; set; }
        public string Size { get; set; }
        public float Price { get; set; }
        public PhotoReturnDto Photo { get; set; }
        public string Manufacturer { get; set; }
    }
}
