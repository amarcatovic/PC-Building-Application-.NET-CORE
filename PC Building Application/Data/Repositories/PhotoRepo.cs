using CloudinaryDotNet;
using Microsoft.Extensions.Options;
using PC_Building_Application.Data.Models;
using PC_Building_Application.Data.Repositories.Interfaces;
using PC_Building_Application.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data.Repositories
{
    public class PhotoRepo : IPhotoRepo
    {
        private readonly DataContext _context;
        private readonly IOptions<CloudinarySettings> _cloudinarySettings;
        private Cloudinary _cloudinary;

        public PhotoRepo(DataContext context, IOptions<CloudinarySettings> cloudinarySettings)
        {
            _context = context;
            _cloudinarySettings = cloudinarySettings;

            Account account = new Account(
                _cloudinarySettings.Value.CloudName,
                _cloudinarySettings.Value.APIKey,
                _cloudinarySettings.Value.APISecret
            );

            _cloudinary = new Cloudinary(account);
        }

        public async Task AddPhoto(Photo photo)
        {
            await _context.AddAsync(photo);
        }

        public Task<Photo> AddPhotoForComponent(int componentId)
        {
            
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
