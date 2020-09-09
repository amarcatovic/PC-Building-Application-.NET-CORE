using Microsoft.EntityFrameworkCore;
using PC_Building_Application.Data.Models;
using PC_Building_Application.Data.Models.Dtos;
using PC_Building_Application.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data.Repositories
{
    public class CPURepo : ICPURepo
    {
        private readonly DataContext _context;
        private readonly IPhotoRepo _photoRepo;

        public CPURepo(DataContext context, IPhotoRepo photoRepo)
        {
            _context = context;
            _photoRepo = photoRepo;
        }
        public async Task CreateCPU(CPU cpu, PhotoToCreateDto photo)
        {
            var createdPhoto = await _photoRepo.AddPhotoForComponent(photo);
            if (createdPhoto == null)
                return;

            cpu.PhotoId = createdPhoto.Id;
            await _context.CPUs.AddAsync(cpu);
        }

        public async Task<bool> Done()
        {
            return (await _context.SaveChangesAsync()) >= 0;
        }

        public async Task<CPU> GetCPUById(int id)
        {
            var cpuFromDb = await _context.CPUs
                .Include(cpu => cpu.SocketType)
                .Include(cpu => cpu.Manufacturer)
                .Include(cpu => cpu.Photo)
                .SingleOrDefaultAsync(cpu => cpu.Id == id);

            return cpuFromDb;
        }

        public async Task<IEnumerable<CPU>> GetCPUs()
        {
            var cpusFromDb = await _context.CPUs
                .Include(cpu => cpu.SocketType)
                .Include(cpu => cpu.Manufacturer)
                .Include(cpu => cpu.Photo)
                .ToListAsync();

            return cpusFromDb;
        }
    }
}
