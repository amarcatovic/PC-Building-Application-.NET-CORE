using PC_Building_Application.Data.Models.Dtos.CPU_Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data.Models.Dtos.Manufacturer_Dtos
{
    public class ManufacturerReadCpusDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

        public ICollection<CPUReadDto> CPUs { get; set; }
    }
}
