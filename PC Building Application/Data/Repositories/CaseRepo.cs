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
    public class CaseRepo : ICaseRepo
    {
        private readonly DataContext _context;
        private readonly IPhotoRepo _photoRepo;
        public CaseRepo(DataContext context, IPhotoRepo photoRepo)
        {
            _context = context;
            _photoRepo = photoRepo;
        }
        public async Task CreateCase(Case @case, PhotoToCreateDto photo)
        {
            var createdPhoto = await _photoRepo.AddPhotoForComponent(photo);
            if (createdPhoto == null)
                return;

            @case.PhotoId = createdPhoto.Id;
            await _context.Cases.AddAsync(@case);
        }

        public async Task<bool> Done()
        {
            return (await _context.SaveChangesAsync()) >= 0;
        }

        public async Task<Case> GetCaseById(int id)
        {
            var caseFromDb = await _context.Cases
               .Include(c => c.Manufacturer)
               .Include(c => c.Photo)
               .SingleOrDefaultAsync(cpu => cpu.Id == id);

            return caseFromDb;
        }

        public async Task<IEnumerable<Case>> GetCases()
        {
            var casesFromDb = await _context.Cases
               .Include(c => c.Manufacturer)
               .Include(c => c.Photo)
               .ToListAsync();

            return casesFromDb;
        }
    }
}
