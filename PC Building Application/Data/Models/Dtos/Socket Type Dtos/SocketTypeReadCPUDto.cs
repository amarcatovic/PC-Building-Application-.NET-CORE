using PC_Building_Application.Data.Models.Dtos.CPU_Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data.Models.Dtos.Socket_Type_Dtos
{
    public class SocketTypeReadCPUDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<CPUReadDto> CPUs { get; set; }
    }
}
