using Microsoft.EntityFrameworkCore;
using PC_Building_Application.Data.Models;
using PC_Building_Application.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data.Repositories
{
    public class SocketTypeRepo : ISocketTypeRepo
    {
        private readonly DataContext _context;

        public SocketTypeRepo(DataContext context)
        {
            _context = context;
        }
        public async Task CreateSocketType(SocketType socketType)
        {
            await _context.AddAsync(socketType);
        }

        public async Task<bool> Done()
        {
            return (await _context.SaveChangesAsync()) >= 0;
        }

        public async Task<SocketType> GetSingleSocketTypeById(int id)
        {
            var socketTypeFromDb = await _context.SocketTypes
                .Include(st => st.Motherboards)
                .ThenInclude(m => m.Photo)
                .Include(st => st.Motherboards)
                .ThenInclude(st => st.Manufacturer)
                .Include(st => st.CPUs)
                .ThenInclude(cpu => cpu.Manufacturer)
                .Include(st => st.CPUs)
                .ThenInclude(cpu => cpu.Photo)
                .SingleOrDefaultAsync(st => st.Id == id);

            return socketTypeFromDb;
        }

        public async Task<IEnumerable<SocketType>> GetSocketTypes()
        {
            var socketTypesFromDb = await _context.SocketTypes
                .Include(st => st.Motherboards)
                .ThenInclude(m => m.Photo)
                .Include(st => st.Motherboards)
                .ThenInclude(st => st.Manufacturer)
                .Include(st => st.CPUs)
                .ThenInclude(cpu => cpu.Manufacturer)
                .Include(st => st.CPUs)
                .ThenInclude(cpu => cpu.Photo)
                .ToListAsync();

            return socketTypesFromDb;
        }
    }
}
