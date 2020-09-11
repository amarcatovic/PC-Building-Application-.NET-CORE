using Microsoft.EntityFrameworkCore;
using PC_Building_Application.Data.Models.Join_Classes;
using PC_Building_Application.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data.Repositories
{
    public class PCRamRepo : IPCRamRepo
    {
        private readonly DataContext _context;

        public PCRamRepo(DataContext context)
        {
            _context = context;
        }

        public async Task AddRam(int pcId, int ramId)
        {
            await _context.PCRAM.AddAsync(new PCRAM() { PCId = pcId, RAMId = ramId, Inserted = DateTime.Now });
        }

        public async Task<bool> InsertRAMIntoPC(int pcId, IEnumerable<int> ramIds)
        {
            foreach (var ramId in ramIds)
            {
                await _context.PCRAM.AddAsync(new PCRAM() { RAMId = ramId, PCId = pcId, Inserted = DateTime.Now });
            }

            if ((await _context.SaveChangesAsync()) >= 0)
                return true;

            return false;
        }

        public async Task RemoveRam(int pcId, int ramId)
        {
            var pcRamFromDb = await _context.PCRAM
                .FirstOrDefaultAsync(pcs => pcs.RAMId == ramId && pcs.PCId == pcId);

            _context.PCRAM.Remove(pcRamFromDb);
        }
    }
}
