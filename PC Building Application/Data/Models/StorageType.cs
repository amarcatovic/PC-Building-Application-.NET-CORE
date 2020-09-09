using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data
{
    public class StorageType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Storage> Storages { get; set; }
    }
}
