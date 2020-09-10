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
    public class ManufacturerRepo : IManufacturerRepo
    {
        private readonly DataContext _context;
        private readonly IPhotoRepo _photoRepo;
        public ManufacturerRepo(DataContext context, IPhotoRepo photoRepo)
        {
            _context = context;
            _photoRepo = photoRepo;
        }

        public async Task CraeteManufacturer(Manufacturer manufacturer, PhotoToCreateDto photo)
        {
            var createdPhoto = await _photoRepo.AddPhotoForComponent(photo);
            if (createdPhoto == null)
                return;

            manufacturer.PhotoId = createdPhoto.Id;
            await _context.Manufacturers.AddAsync(manufacturer);
        }

        public async Task<bool> Done()
        {
            return await (_context.SaveChangesAsync()) >= 0;
        }

        public async Task<IEnumerable<Manufacturer>> GetAllManufacturers()
        {
            var manufacturersFromDb = await _context.Manufacturers
                .Include(m => m.CPUs)
                .ThenInclude(cpu => cpu.Photo)
                .Include(m => m.CPUs)
                .ThenInclude(cpu => cpu.SocketType)
                .Include(m => m.GPUs)
                .ThenInclude(gpu => gpu.Photo)
                .Include(m => m.Coolers)
                .ThenInclude(c => c.Photo)
                .Include(m => m.Coolers)
                .ThenInclude(c => c.CoolerSocketTypes)
                .ThenInclude(cst => cst.SocketType)
                .Include(m => m.Motherboards)
                .ThenInclude(mobo => mobo.Photo)
                .Include(m => m.RAMs)
                .ThenInclude(r => r.Photo)
                .Include(m => m.PowerSupplies)
                .ThenInclude(ps => ps.Photo)
                .Include(m => m.Cases)
                .ThenInclude(c => c.Photo)
                .Include(m => m.Storages)
                .ThenInclude(s => s.Photo)
                .Include(m => m.Storages)
                .ThenInclude(st => st.StorageType)
                .Include(m => m.Photo)
                .ToListAsync();

            return manufacturersFromDb;
        }

        public async Task<Manufacturer> GetManufacturerById(int id)
        {
            var manufacturerFromDb = await _context.Manufacturers
                .Include(m => m.CPUs)
                .ThenInclude(cpu => cpu.Photo)
                .Include(m => m.CPUs)
                .ThenInclude(cpu => cpu.SocketType)
                .Include(m => m.GPUs)
                .ThenInclude(gpu => gpu.Photo)
                .Include(m => m.Coolers)
                .ThenInclude(c => c.Photo)
                .Include(m => m.Coolers)
                .ThenInclude(c => c.CoolerSocketTypes)
                .ThenInclude(cst => cst.SocketType)
                .Include(m => m.Motherboards)
                .ThenInclude(mobo => mobo.Photo)
                .Include(m => m.RAMs)
                .ThenInclude(r => r.Photo)
                .Include(m => m.PowerSupplies)
                .ThenInclude(ps => ps.Photo)
                .Include(m => m.Cases)
                .ThenInclude(c => c.Photo)
                .Include(m => m.Storages)
                .ThenInclude(s => s.Photo)
                .Include(m => m.Storages)
                .ThenInclude(st => st.StorageType)
                .Include(m => m.Photo)
                .SingleOrDefaultAsync(m => m.Id == id);

            return manufacturerFromDb;
        }

        public async Task<Manufacturer> GetManufacturerCasesById(int id)
        {
            var manufacturerFromDb = await _context.Manufacturers
                .Include(m => m.Cases)
                .ThenInclude(c => c.Photo)
                .Include(m => m.Photo)
                .SingleOrDefaultAsync(m => m.Id == id);

            return manufacturerFromDb;
        }

        public async Task<Manufacturer> GetManufacturerCoolersById(int id)
        {
            var manufacturerFromDb = await _context.Manufacturers
                .Include(m => m.Coolers)
                .ThenInclude(c => c.CoolerSocketTypes)
                .ThenInclude(cst => cst.SocketType)
                .Include(m => m.Coolers)
                .ThenInclude(c => c.Photo)
                .Include(m => m.Photo)
                .SingleOrDefaultAsync(m => m.Id == id);

            return manufacturerFromDb;
        }

        public async Task<Manufacturer> GetManufacturerCpusById(int id)
        {
            var manufacturerFromDb = await _context.Manufacturers
                .Include(m => m.CPUs)
                .ThenInclude(cpu => cpu.SocketType)
                .Include(m => m.CPUs)
                .ThenInclude(cpu => cpu.Photo)
                .Include(m => m.Photo)
                .SingleOrDefaultAsync(m => m.Id == id);

            return manufacturerFromDb;
        }

        public async Task<Manufacturer> GetManufacturerGpusById(int id)
        {
            var manufacturerFromDb = await _context.Manufacturers
                .Include(m => m.GPUs)
                .ThenInclude(gpu => gpu.Photo)
                .Include(m => m.Photo)
                .SingleOrDefaultAsync(m => m.Id == id);

            return manufacturerFromDb;
        }

        public async Task<Manufacturer> GetManufacturerMotherboardsById(int id)
        {
            var manufacturerFromDb = await _context.Manufacturers
                .Include(m => m.Motherboards)
                .ThenInclude(mobo => mobo.SocketType)
                .Include(m => m.Motherboards)
                .ThenInclude(mobo => mobo.Photo)
                .Include(m => m.Photo)
                .SingleOrDefaultAsync(m => m.Id == id);

            return manufacturerFromDb;
        }

        public async Task<Manufacturer> GetManufacturerPowerSuppliesById(int id)
        {
            var manufacturerFromDb = await _context.Manufacturers
                .Include(m => m.PowerSupplies)
                .ThenInclude(psu => psu.Photo)
                .Include(m => m.Photo)
                .SingleOrDefaultAsync(m => m.Id == id);

            return manufacturerFromDb;
        }

        public async Task<Manufacturer> GetManufacturerRamsById(int id)
        {
            var manufacturerFromDb = await _context.Manufacturers
                .Include(m => m.RAMs)
                .ThenInclude(ram => ram.Photo)
                .Include(m => m.Photo)
                .SingleOrDefaultAsync(m => m.Id == id);

            return manufacturerFromDb;
        }

        public async Task<Manufacturer> GetManufacturerStoragesById(int id)
        {
            var manufacturerFromDb = await _context.Manufacturers
                .Include(m => m.Storages)
                .ThenInclude(s => s.StorageType)
                .Include(m => m.Storages)
                .ThenInclude(s => s.Photo)
                .Include(m => m.Photo)
                .SingleOrDefaultAsync(m => m.Id == id);

            return manufacturerFromDb;
        }
    }
}
