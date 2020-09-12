using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data.Models.Dtos.PC_Dtos
{
    public class PCCreateDto
    {
        public PCCreateDto()
        {
            UserId = "anonymous";
            DateBuilt = DateTime.Now;
        }

        public string BuildTitle { get; set; }
        public string BuildDescription { get; set; }
        public DateTime DateBuilt { get; set; }
        public string UserId { get; set; }
        public int MotherboardId { get; set; }
        public int CPUId { get; set; }
        public int CoolerId { get; set; }
        public int PowerSupplyId { get; set; }
        public int CaseId { get; set; }
        public ICollection<int> gpuIds { get; set; }
        public ICollection<int> ramIds { get; set; }
        public ICollection<int> storageIds { get; set; }
    }
}
