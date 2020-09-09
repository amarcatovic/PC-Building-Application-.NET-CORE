﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data.Models
{
    public class RAM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Speed { get; set; }
        public string Type { get; set; }
        public sbyte NoOfSticks { get; set; }
        public string CapacityPerStick { get; set; }
        public bool HasRGB { get; set; }
        public float Price { get; set; }
        public ICollection<PC> PCs { get; set; }
    }
}
