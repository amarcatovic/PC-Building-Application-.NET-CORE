using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data.Models.Dtos.PC_Dtos
{
    public class PCCreateWithPartsDto
    {
        public int Id { get; set; }
        public string BuildTitle { get; set; }
        public string BuildDescription { get; set; }
        public DateTime DateBuilt { get; set; }
        public int MotherboardId { get; set; }
        public int CPUId { get; set; }
        public string UserId { get; set; }
        public int GPUId { get; set; }
        public int CoolerId { get; set; }
        public int PowerSupplyId { get; set; }
        public int CaseId { get; set; }
        public ICollection<int> ramIds { get; set; }
        public ICollection<int> storageIds { get; set; }
    }
}
