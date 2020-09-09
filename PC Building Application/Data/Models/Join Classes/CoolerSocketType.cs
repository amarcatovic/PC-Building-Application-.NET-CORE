using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data.Models.Join_Classes
{
    public class CoolerSocketType
    {
        public Cooler Cooler { get; set; }
        public int CoolerId { get; set; }
        public SocketType SocketType { get; set; }
        public int SocketTypeId { get; set; }
    }
}
