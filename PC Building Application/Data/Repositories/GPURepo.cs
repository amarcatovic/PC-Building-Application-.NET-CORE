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
    public class GPURepo : IGPURepo
    {
        private readonly DataContext _context;
        private readonly IPhotoRepo _photoRepo;
        public GPURepo(DataContext context, IPhotoRepo photoRepo)
        {
            _context = context;
            _photoRepo = photoRepo;
        }
        public async Task CreateGPU(GPU gpu, PhotoToCreateDto photo)
        {
            var createdPhoto = await _photoRepo.AddPhotoForComponent(photo);
            if (createdPhoto == null)
                return;

            gpu.PhotoId = createdPhoto.Id;
            await _context.GPUs.AddAsync(gpu);
        }

        public async Task<int> Done()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<GPU>> GetAllGPUs()
        {
            var gpusFromDb = await _context.GPUs
                .Include(gpu => gpu.Photo)
                .Include(gpu => gpu.Manufacturer)
                .ToListAsync();

            return gpusFromDb;
        }

        public async Task<GPU> GetGPUById(int id)
        {
            var gpuFromDb = await _context.GPUs
                .Include(gpu => gpu.Photo)
                .Include(gpu => gpu.Manufacturer)
                .SingleOrDefaultAsync(gpu => gpu.Id == id);

            return gpuFromDb;
        }
    }
}
