using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public string PublicId { get; set; }

        public ICollection<RAM> RAMs { get; set; }
        public ICollection<CPU> CPUs { get; set; }
        public ICollection<GPU> GPUs { get; set; }
        public ICollection<Motherboard> Motherboards { get; set; }
        public ICollection<Cooler> Coolers { get; set; }
        public ICollection<PowerSupply> PowerSupplies { get; set; }
        public ICollection<Case> Cases { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
