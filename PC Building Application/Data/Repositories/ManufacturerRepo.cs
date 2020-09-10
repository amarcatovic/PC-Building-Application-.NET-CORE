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
            /*var createdPhoto = await _photoRepo.AddPhotoForComponent(photo);
            if (createdPhoto == null)
                return;

            manufacturer.PhotoId = createdPhoto.Id;
            await _context.Cases.AddAsync(manufacturer);*/
            throw new NotImplementedException();
        }

        public async Task<bool> Done()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Manufacturer>> GetAllManufacturers()
        {
            throw new NotImplementedException();
        }

        public async Task<Manufacturer> GetManufacturerById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Manufacturer> GetManufacturerCasesById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Manufacturer> GetManufacturerCoolersById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Manufacturer> GetManufacturerCpusById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Manufacturer> GetManufacturerGpusById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Manufacturer> GetManufacturerMotherboardsById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Manufacturer> GetManufacturerPowerSuppliesById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Manufacturer> GetManufacturerRamsById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Manufacturer> GetManufacturerStoragesById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
