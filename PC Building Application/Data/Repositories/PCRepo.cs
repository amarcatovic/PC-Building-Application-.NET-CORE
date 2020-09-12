using Microsoft.EntityFrameworkCore;
using PC_Building_Application.Data.Models;
using PC_Building_Application.Data.Models.Join_Classes;
using PC_Building_Application.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data.Repositories
{
    public class PCRepo : IPCRepo
    {
        private readonly DataContext _context;
        public PCRepo(DataContext context)
        {
            _context = context;
        }
        public async Task CreatePC(PC pc)
        {
            await _context.PCs.AddAsync(pc);
        }

        public async Task<bool> Done()
        {
            return (await _context.SaveChangesAsync()) >= 0;
        }

        public async Task<PC> GetPCById(int id)
        {
            var pcFromDb = await _context.PCs
                .Include(pc => pc.Motherboard)
                .ThenInclude(m => m.Photo)
                .Include(pc => pc.Motherboard)
                .ThenInclude(m => m.SocketType)
                .Include(pc => pc.Motherboard)
                .ThenInclude(m => m.Manufacturer)
                .Include(pc => pc.CPU)
                .ThenInclude(cpu => cpu.Photo)
                .Include(pc => pc.CPU)
                .ThenInclude(cpu => cpu.SocketType)
                .Include(pc => pc.CPU)
                .ThenInclude(cpu => cpu.Manufacturer)
                .Include(pc => pc.PCGPUs)
                .ThenInclude(pc => pc.GPU)
                .ThenInclude(gpu => gpu.Photo)
                .Include(pc => pc.PCGPUs)
                .ThenInclude(pc => pc.GPU)
                .ThenInclude(gpu => gpu.Manufacturer)
                .Include(pc => pc.Cooler)
                .ThenInclude(c => c.Photo)
                .Include(pc => pc.Cooler)
                .ThenInclude(c => c.Manufacturer)
                .Include(pc => pc.Cooler)
                .ThenInclude(c => c.CoolerSocketTypes)
                .ThenInclude(cst => cst.SocketType)
                .Include(pc => pc.PowerSupply)
                .ThenInclude(ps => ps.Manufacturer)
                .Include(pc => pc.PowerSupply)
                .ThenInclude(ps => ps.Photo)
                .Include(pc => pc.Case)
                .ThenInclude(c => c.Photo)
                .Include(pc => pc.Case)
                .ThenInclude(c => c.Manufacturer)
                .Include(pc => pc.PCRAMs)
                .ThenInclude(pcram => pcram.RAM)
                .ThenInclude(ram => ram.Photo)
                .Include(pc => pc.PCStorages)
                .ThenInclude(pcs => pcs.Storage)
                .ThenInclude(s => s.Photo)
                .Include(pc => pc.PCStorages)
                .ThenInclude(pcs => pcs.Storage)
                .ThenInclude(s => s.StorageType)
                .Include(pc => pc.User)
                .ThenInclude(u => u.Photo)
                .SingleOrDefaultAsync(cpu => cpu.Id == id);

            return pcFromDb;
        }

        public async Task ReplaceCase(int pcId, int caseId)
        {
            var pcFromDb = await _context.PCs.SingleOrDefaultAsync(pc => pc.Id == pcId);
            pcFromDb.CaseId = caseId;
        }

        public async Task ReplaceCooler(int pcId, int coolerId)
        {
            var pcFromDb = await _context.PCs.SingleOrDefaultAsync(pc => pc.Id == pcId);
            pcFromDb.CoolerId = coolerId;
        }

        public async Task ReplaceCpu(int pcId, int cpuId)
        {
            var pcFromDb = await _context.PCs.SingleOrDefaultAsync(pc => pc.Id == pcId);
            pcFromDb.CPUId = cpuId;
        }

        public async Task ReplaceMotherboard(int pcId, int motherboardId)
        {
            var pcFromDb = await _context.PCs.SingleOrDefaultAsync(pc => pc.Id == pcId);
            pcFromDb.MotherboardId = motherboardId;
        }

        public async Task ReplacePowerSupply(int pcId, int psuId)
        {
            var pcFromDb = await _context.PCs.SingleOrDefaultAsync(pc => pc.Id == pcId);
            pcFromDb.PowerSupplyId = psuId;
        }
    }
}
