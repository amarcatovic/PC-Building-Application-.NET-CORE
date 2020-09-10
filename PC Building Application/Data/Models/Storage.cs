using PC_Building_Application.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data
{
    public class Storage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Released { get; set; }
        public string Capacity { get; set; }
        public StorageType StorageType { get; set; }
        public int StorageTypeId { get; set; }
        public bool HasCooling { get; set; }
        public float Price { get; set; }
        public Photo Photo { get; set; }
        public int PhotoId { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public int ManufacturerId { get; set; }
        public ICollection<PCStorage> PCStorages { get; set; }
    }
}
