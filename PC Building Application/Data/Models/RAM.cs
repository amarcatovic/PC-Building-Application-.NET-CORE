﻿using PC_Building_Application.Data.Models.Join_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data.Models
{
    public class RAM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Released { get; set; }
        public int Speed { get; set; }
        public string Type { get; set; }
        public sbyte NoOfSticks { get; set; }
        public string CapacityPerStick { get; set; }
        public bool HasRGB { get; set; }
        public float Price { get; set; }
        public Photo Photo { get; set; }
        public int PhotoId { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public int ManufacturerId { get; set; }
        public ICollection<PCRAM> PCRAMs { get; set; }
    }
}
