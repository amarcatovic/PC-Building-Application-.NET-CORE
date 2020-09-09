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
    public class RAMRepo : IRAMRepo
    {
        private readonly DataContext _context;
        private readonly IPhotoRepo _photoRepo;
        public RAMRepo(DataContext context, IPhotoRepo photoRepo)
        {
            _context = context;
            _photoRepo = photoRepo;
        }
        public async Task CreateRAM(RAM ram, PhotoToCreateDto photo)
        {
            var createdPhoto = await _photoRepo.AddPhotoForComponent(photo);
            if (createdPhoto == null)
                return;

            ram.PhotoId = createdPhoto.Id;
            await _context.RAMs.AddAsync(ram);
        }

        public async Task<int> Done()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<RAM>> GetAllRAMs()
        {
            var ramsFromDb = await _context.RAMs
                .Include(ram => ram.Photo)
                .ToListAsync();

            return ramsFromDb;
        }

        public async Task<RAM> GetRAMById(int id)
        {
            var ramsFromDb = await _context.RAMs
                .Include(ram => ram.Photo)
                .SingleOrDefaultAsync(ram => ram.Id == id);

            return ramsFromDb;
        }
    }
}
