using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data.Models.Dtos.Storage_Dtos
{
    public class StorageCreateDto
    {
        public string Name { get; set; }
        public DateTime Released { get; set; }
        public string Capacity { get; set; }
        public int StorageTypeId { get; set; }
        public bool HasCooling { get; set; }
        public int PhotoId { get; set; }
        public int ManufacturerId { get; set; }
        public string PhotoDescription { get; set; }
        public IFormFile PhotoFile { get; set; }
    }
}
