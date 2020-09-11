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
    }
}
