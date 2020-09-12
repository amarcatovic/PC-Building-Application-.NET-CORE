﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data.Models
{
    public class PowerSupply
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Released { get; set; }
        public string Power { get; set; }
        public byte NoOfPCIe6Pins { get; set; }
        public byte NoOfPCIe8Pins { get; set; }
        public byte NoOfPCIe12Pins { get; set; }
        public byte NoOfSATACables { get; set; }
        public byte NoOfCPUCables { get; set; }
        public bool Has24PinCable { get; set; }
        public string EfficiencyRating { get; set; }
        public float Price { get; set; }
        public Photo Photo { get; set; }
        public int PhotoId { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public int ManufacturerId { get; set; }
        public ICollection<PC> PCs { get; set; }       
    }
}
