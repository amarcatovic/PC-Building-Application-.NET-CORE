using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data.Models.Dtos.CPU_Dtos
{
    public class CPUReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Released { get; set; }
        public string SocketType { get; set; }
        public string Clockspeed { get; set; }
        public string TurboSpeed { get; set; }
        public int NoOfCores { get; set; }
        public int SingleThreadRating { get; set; }
        public string Manufacturer { get; set; }
        public PhotoReturnDto Photo { get; set; }
    }
}
