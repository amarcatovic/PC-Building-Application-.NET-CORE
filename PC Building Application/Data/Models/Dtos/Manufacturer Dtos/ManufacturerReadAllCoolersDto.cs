using PC_Building_Application.Data.Models.Dtos.Cooler_Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data.Models.Dtos.Manufacturer_Dtos
{
    public class ManufacturerReadAllCoolersDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public PhotoReturnDto Photo { get; set; }
        public ICollection<CoolerReadDto> Coolers { get; set; }
    }
}
