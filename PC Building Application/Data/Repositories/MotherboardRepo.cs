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
    public class MotherboardRepo : IMotherboardRepo
    {
        private readonly DataContext _context;
        private readonly PhotoRepo _photoRepo;

        public MotherboardRepo(DataContext context, PhotoRepo photoRepo)
        {
            _context = context;
            _photoRepo = photoRepo;
        }
        public async Task CreateMotherboard(Motherboard mobo, PhotoToCreateDto photo)
        {
            var createdPhoto = await _photoRepo.AddPhotoForComponent(photo);
            if (createdPhoto == null)
                return;

            mobo.PhotoId = createdPhoto.Id;
            await _context.Motherboards.AddAsync(mobo);
        }

        public async Task<IEnumerable<Motherboard>> GetAllMotherboards()
        {
            return await _context.Motherboards
                .Include(m => m.Photo)
                .Include(m => m.Manufacturer)
                .Include(m => m.SocketType)
                .ToListAsync();
        }

        public async Task<Motherboard> GetMotherboardById(int id)
        {
            return await _context.Motherboards
                .Include(m => m.Photo)
                .Include(m => m.Manufacturer)
                .Include(m => m.SocketType)
                .SingleOrDefaultAsync(m => m.Id == id);
        }

        public async Task<int> Done()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
