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
    public class PowerSupplyRepo : IPowerSupplyRepo
    {
        private readonly DataContext _context;
        private readonly IPhotoRepo _photoRepo;

        public PowerSupplyRepo(DataContext context, IPhotoRepo photoRepo)
        {
            _context = context;
            _photoRepo = photoRepo;
        }
        public async Task CreatePowerSupply(PowerSupply powerSupply, PhotoToCreateDto photo)
        {
            var createdPowerSupply = await _photoRepo.AddPhotoForComponent(photo);
            if (createdPowerSupply == null)
                return;

            powerSupply.PhotoId = powerSupply.Id;
            await _context.PowerSupplies.AddAsync(powerSupply);
        }

        public async Task<int> Done()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<PowerSupply>> GetAllPowerSupplys()
        {
            var psusFromDb = await _context.PowerSupplies
                .Include(psu => psu.Photo)
                .Include(psu => psu.Manufacturer)
                .ToListAsync();

            return psusFromDb;
        }

        public async Task<PowerSupply> GetPowerSupplyById(int id)
        {
            var psuFromDb = await _context.PowerSupplies
                .Include(psu => psu.Photo)
                .Include(psu => psu.Manufacturer)
                .SingleOrDefaultAsync(psu => psu.Id == id);

            return psuFromDb;
        }
    }
}
