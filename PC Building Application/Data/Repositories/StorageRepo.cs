using Microsoft.EntityFrameworkCore;
using PC_Building_Application.Data.Models.Dtos;
using PC_Building_Application.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data.Repositories
{
    public class StorageRepo : IStorageRepo
    {
        private readonly DataContext _context;
        private readonly IPhotoRepo _photoRepo;

        public StorageRepo(DataContext context, IPhotoRepo photoRepo)
        {
            _context = context;
            _photoRepo = photoRepo;
        }
        public async Task CreateStorage(Storage storage, PhotoToCreateDto photo)
        {
            var createdPhoto = await _photoRepo.AddPhotoForComponent(photo);
            if (createdPhoto == null)
                return;

            storage.PhotoId = createdPhoto.Id;
            await _context.Storages.AddAsync(storage);
        }

        public async Task<bool> Done()
        {
            return (await _context.SaveChangesAsync()) >= 0;
        }

        public async Task<Storage> GetStorageById(int id)
        {
            var storageFromDb = await _context.Storages
                .Include(s => s.StorageType)
                .Include(s => s.Manufacturer)
                .Include(s => s.Photo)
                .SingleOrDefaultAsync(s => s.Id == id);

            return storageFromDb;
        }

        public async Task<IEnumerable<Storage>> GetStorages()
        {
            var storagesFromDb = await _context.Storages
                .Include(s => s.StorageType)
                .Include(s => s.Manufacturer)
                .Include(s => s.Photo)
                .ToListAsync();

            return storagesFromDb;
        }
    }
}
