using PC_Building_Application.Data.Models.Join_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data.Models
{
    public class SocketType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<CPU> CPUs { get; set; }
        public ICollection<Motherboard> Motherboards { get; set; }
        public ICollection<CoolerSocketType> CoolerSocketTypes { get; set; }
    }
}
