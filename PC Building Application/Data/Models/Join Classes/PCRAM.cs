using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data.Models.Join_Classes
{
    public class PCRAM
    {
        public PC PC { get; set; }
        public int PCId { get; set; }
        public RAM RAM { get; set; }
        public int RAMId { get; set; }
        public DateTime Inserted { get; set; }
    }
}
