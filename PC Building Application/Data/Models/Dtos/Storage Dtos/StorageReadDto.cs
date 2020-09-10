using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data.Models.Dtos.Storage_Dtos
{
    public class StorageReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Released { get; set; }
        public string Capacity { get; set; }
        public string StorageType { get; set; }
        public bool HasCooling { get; set; }
        public float Price { get; set; }
        public PhotoReturnDto Photo { get; set; }
        public string Manufacturer { get; set; }
    }
}
