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
    public class CoolerRepo : ICoolerRepo
    {
        private readonly DataContext _context;
        private readonly IPhotoRepo _photoRepo;

        public CoolerRepo(DataContext context, IPhotoRepo photoRepo)
        {
            _context = context;
            _photoRepo = photoRepo;
        }

        public async Task CreateCooler(Cooler cooler, PhotoToCreateDto photo)
        {
            var createdPhoto = await _photoRepo.AddPhotoForComponent(photo);
            if (createdPhoto == null)
                return;

            cooler.PhotoId = createdPhoto.Id;
            await _context.Coolers.AddAsync(cooler);
        }

        public async Task<bool> Done()
        {
            return (await _context.SaveChangesAsync()) >= 0;
        }

        public async Task<Cooler> GetCoolerById(int id)
        {
            var coolerFromDb = await _context.Coolers
               .Include(c => c.CoolerSocketTypes)
               .ThenInclude(cst => cst.SocketType)
               .Include(c => c.Manufacturer)
               .Include(c => c.Photo)
               .SingleOrDefaultAsync(c => c.Id == id);

            return coolerFromDb;
        }

        public async Task<IEnumerable<Cooler>> GetCoolers()
        {
            var coolersFromDb = await _context.Coolers
               .Include(c => c.CoolerSocketTypes)
               .ThenInclude(cst => cst.SocketType)
               .Include(c => c.Manufacturer)
               .Include(c => c.Photo)
               .ToListAsync();

            return coolersFromDb;
        }
    }
}
