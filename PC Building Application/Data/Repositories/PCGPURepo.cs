using Microsoft.EntityFrameworkCore;
using PC_Building_Application.Data.Models.Join_Classes;
using PC_Building_Application.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data.Repositories
{
    public class PCGPURepo : IPCGPURepo
    {
        private readonly DataContext _context;

        public PCGPURepo(DataContext context)
        {
            _context = context;
        }
        public async Task AddGpu(int pcId, int gpuId)
        {
            await _context.PCGPU.AddAsync(new PCGPU() { PCID = pcId, GPUId = gpuId, Inserted = DateTime.Now });
        }

        public async Task<bool> InsertGPUntoPC(int pcId, IEnumerable<int> gpuIds)
        {
            foreach (var gpuId in gpuIds)
            {
                await _context.PCGPU.AddAsync(new PCGPU() { GPUId = gpuId, PCID = pcId, Inserted = DateTime.Now });
            }

            if ((await _context.SaveChangesAsync()) >= 0)
                return true;

            return false;
        }

        public async Task RemoveGpu(int pcId, int gpuId)
        {
            var pcGpuFromDb = await _context.PCGPU
                .FirstOrDefaultAsync(pcs => pcs.GPUId == gpuId && pcs.PCID == pcId);

            _context.PCGPU.Remove(pcGpuFromDb);
        }
    }
}
