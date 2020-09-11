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
        public async Task<bool> InsertRAMIntoPC(int pcId, IEnumerable<int> ramIds)
        {
            foreach (var ramId in ramIds)
            {
                await _context.PCRAM.AddAsync(new PCRAM() { RAMId = ramId, PCId = pcId });
            }

            if ((await _context.SaveChangesAsync()) >= 0)
                return true;

            return false;
        }
    }
}
