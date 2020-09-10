using PC_Building_Application.Data.Models.Join_Classes;
using PC_Building_Application.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data.Repositories
{
    public class CoolerSocketTypeRepo : ICoolerSocketTypeRepo
    {
        private readonly DataContext _context;

        public CoolerSocketTypeRepo(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> InsertCoolerWithSocketTypes(int coolerId, IEnumerable<int> socketTypes)
        {
            foreach(var socketTypeId in socketTypes)
            {
                await _context.CoolerSocketType.AddAsync(new CoolerSocketType() { CoolerId = coolerId, SocketTypeId = socketTypeId });
            }

            if ((await _context.SaveChangesAsync()) >= 0)
                return true;

            return false;
        }
    }
}
