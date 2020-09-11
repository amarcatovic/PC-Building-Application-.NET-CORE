using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data.Repositories.Interfaces
{
    public interface IPCRamRepo
    {
        Task<bool> InsertRAMIntoPC(int pcId, IEnumerable<int> ramIds);
        Task AddRam(int pcId, int ramId);
        Task RemoveRam(int pcId, int ramId);
    }
}
