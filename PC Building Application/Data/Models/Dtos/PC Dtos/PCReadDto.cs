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

namespace PC_Building_Application.Data.Models.Dtos.PC_Dtos
{
    public class PCReadDto
    {
        public int Id { get; set; }
        public string BuildTitle { get; set; }
        public string BuildDescription { get; set; }
        public DateTime DateBuilt { get; set; }
        public MotherboardReadDto Motherboard { get; set; }
        public CPUReadDto CPU { get; set; }
        public UserReadDto User { get; set; }
        public CoolerReadDto Cooler { get; set; }
        public PowerSupplyReadDto PowerSupply { get; set; }
        public CaseReadDto Case { get; set; }
        public ICollection<GPUReadDto> GPU { get; set; }
        public ICollection<RAMReadDto> RAM { get; set; }
        public ICollection<StorageReadDto> Storage { get; set; }
    }
}
