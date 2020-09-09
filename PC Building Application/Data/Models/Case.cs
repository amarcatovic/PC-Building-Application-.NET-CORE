using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data.Models
{
    public class Case
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Released { get; set; }
        public byte NoOfUSB3Ports { get; set; }
        public bool HasRGB { get; set; }
        public bool HasScreen { get; set; }
        public string Size { get; set; }
        public float Price { get; set; }
        public Photo Photo { get; set; }
        public int PhotoId { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public int ManufacturerId { get; set; }
        public ICollection<PC> PCs { get; set; }

    }
}
