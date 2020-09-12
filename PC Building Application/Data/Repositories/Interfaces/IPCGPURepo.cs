using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data.Repositories.Interfaces
{
    public interface IPCGPURepo
    {
        Task<bool> InsertGPUntoPC(int pcId, IEnumerable<int> gpuIds);
        Task AddGpu(int pcId, int gpuId);
        Task RemoveGpu(int pcId, int gpuId);
    }
}
