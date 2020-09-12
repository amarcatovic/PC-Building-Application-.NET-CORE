using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data.Models.Join_Classes
{
    public class PCGPU
    {
        public PC PC { get; set; }
        public int PCID { get; set; }
        public GPU GPU { get; set; }
        public int GPUId { get; set; }
        public DateTime Inserted { get; set; }
    }
}
