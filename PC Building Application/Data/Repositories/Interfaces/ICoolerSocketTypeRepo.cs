using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data.Repositories.Interfaces
{
    public interface ICoolerSocketTypeRepo
    {
        Task<bool> InsertCoolerWithSocketTypes(int coolerId, IEnumerable<int> socketTypes);
    }
}
