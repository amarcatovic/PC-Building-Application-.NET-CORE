using PC_Building_Application.Data.Models.Dtos.Case_Dtos;
using PC_Building_Application.Data.Models.Dtos.Cooler_Dtos;
using PC_Building_Application.Data.Models.Dtos.CPU_Dtos;
using PC_Building_Application.Data.Models.Dtos.GPU_Dtos;
using PC_Building_Application.Data.Models.Dtos.Power_Supply_Dtos;
using PC_Building_Application.Data.Models.Dtos.RAM_Dtos;
using PC_Building_Application.Data.Models.Dtos.Storage_Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data.Models.Dtos.Manufacturer_Dtos
{
    public class ManufacturerReadAllDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public ICollection<CPUReadDto> CPUs { get; set; }
        public ICollection<GPUReadDto> GPUs { get; set; }
        public ICollection<CoolerReadDto> Coolers { get; set; }
        public ICollection<MotherboardReadDto> Motherboards { get; set; }
        public ICollection<RAMReadDto> RAMs { get; set; }
        public ICollection<PowerSupplyReadDto> PowerSupplies { get; set; }
        public ICollection<CaseReadDto> Cases { get; set; }
        public ICollection<StorageReadDto> Storages { get; set; }
        public PhotoReturnDto Photo { get; set; }
    }
}
