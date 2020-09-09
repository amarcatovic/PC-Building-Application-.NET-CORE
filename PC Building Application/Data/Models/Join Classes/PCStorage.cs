using PC_Building_Application.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data
{
    public class PCStorage
    {
        public PC PC { get; set; }
        public int PCId { get; set; }
        public Storage Storage { get; set; }
        public int StorageId { get; set; }
    }
}
