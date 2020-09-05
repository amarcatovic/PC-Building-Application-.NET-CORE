﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data.Models
{
    public class Manufacturer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

        public ICollection<CPU> CPUs { get; set; }
        public ICollection<Motherboard> Motherboards { get; set; }
    }
}