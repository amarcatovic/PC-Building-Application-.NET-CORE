using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data.Repositories.Interfaces
{
    public interface IPCStorageRepo
    {
        Task<bool> InsertStorageInPC(int pcId, IEnumerable<int> storageIds);
        Task AddStorage(int pcId, int storageId);
        Task RemoveStorage(int pcId, int storageId)
    }
}
