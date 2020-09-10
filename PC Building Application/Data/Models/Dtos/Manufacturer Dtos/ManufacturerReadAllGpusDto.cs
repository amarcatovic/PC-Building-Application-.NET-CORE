using PC_Building_Application.Data.Models.Dtos.GPU_Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data.Models.Dtos.Manufacturer_Dtos
{
    public class ManufacturerReadAllGpusDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public PhotoReturnDto Photo { get; set; }
        public ICollection<GPUReadDto> GPUs { get; set; }
    }
}
