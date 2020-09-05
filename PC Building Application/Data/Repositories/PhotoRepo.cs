using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Options;
using PC_Building_Application.Data.Models;
using PC_Building_Application.Data.Models.Dtos;
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
        private readonly IMapper _mapper;
        private Cloudinary _cloudinary;

        public PhotoRepo(DataContext context, IMapper mapper, IOptions<CloudinarySettings> cloudinarySettings)
        {
            _context = context;
            _cloudinarySettings = cloudinarySettings;
            _mapper = mapper;

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

        public async Task<Photo> AddPhotoForComponent(PhotoToCreateDto photo)
        {
            var file = photo.File;
            var uploadResult = new ImageUploadResult();
            if (file.Length > 0)
            {
                using (var stream = file.OpenReadStream())
                {
                    var uploadParams = new ImageUploadParams
                    {
                        File = new FileDescription(file.FileName, stream)
                    };

                    uploadResult = _cloudinary.Upload(uploadParams);
                }
            }

            photo.Url = uploadResult.Url.AbsoluteUri;
            photo.PublicId = uploadResult.PublicId;

            var newPhoto = _mapper.Map<Photo>(photo);
            await _context.Photos.AddAsync(newPhoto);

            if (await _context.SaveChangesAsync() >= 0)
            {
                return newPhoto;
            }

            return null;
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
