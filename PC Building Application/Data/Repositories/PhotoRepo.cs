using PC_Building_Application.Data.Models;
using PC_Building_Application.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data.Repositories
{
    public class PhotoRepo : IPhotoRepo
    {
        private readonly DataContext _context;

        public PhotoRepo(DataContext context)
        {
            _context = context;
        }

        public async Task AddPhoto(Photo photo)
        {
            await _context.AddAsync(photo);
        }

        public async Task<int> Done()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<Photo> GetPhoto(int id)
        {
            return await _context.Photos.FindAsync(id);
        }
    }
}
