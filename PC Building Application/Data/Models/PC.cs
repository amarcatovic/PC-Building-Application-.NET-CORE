using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data.Models
{
    public class PC
    {
        public int Id { get; set; }
        public string BuildTitle { get; set; }
        public string BuildDescription { get; set; }
        public DateTime DateBuilt { get; set; }
        public Motherboard Motherboard { get; set; }
        public int MotherboardId { get; set; }
        public CPU CPU { get; set; }
        public int CPUId { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
        public ICollection<RAM> RAMs { get; set; }
    }
}
