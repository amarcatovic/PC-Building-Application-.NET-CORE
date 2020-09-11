using Microsoft.EntityFrameworkCore;
using PC_Building_Application.Data.Models;
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
        public async Task CreatePCInitial(PC pc)
        {
            await _context.PCs.AddAsync(pc);
        }

        public async Task<bool> CreatePCWithParts(int id, PC pc)
        {
            var pcFromDb = _context.PCs.SingleOrDefault(pc => pc.Id == id);
            if (pcFromDb == null)
                return false;

            pcFromDb.BuildTitle = pc.BuildTitle;
            pcFromDb.BuildDescription = pc.BuildDescription;
            pcFromDb.MotherboardId = pc.MotherboardId;
            pcFromDb.CPUId = pc.CPUId;
            pcFromDb.GPUId = pc.GPUId;
            pcFromDb.CoolerId = pc.CoolerId;
            pcFromDb.PowerSupplyId = pc.PowerSupplyId;
            pcFromDb.CaseId = pc.CaseId;

            await _context.SaveChangesAsync();

            return true;
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
                .Include(pc => pc.PCStorages)
                .ThenInclude(pcs => pcs.Storage)
                .SingleOrDefaultAsync(cpu => cpu.Id == id);

            return pcFromDb;
        }
    }
}
