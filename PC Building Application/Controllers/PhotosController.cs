using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PC_Building_Application.Helper;
using CloudinaryDotNet;
using PC_Building_Application.Data.Models.Dtos;
using System.Security.Claims;
using CloudinaryDotNet.Actions;
using PC_Building_Application.Data.Models;
using PC_Building_Application.Data.Repositories.Interfaces;

namespace PC_Building_Application.Controllers
{
    [Authorize]
    [Route("api/Photos")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        private readonly IUserRepo _userRepo;
        private readonly IPhotoRepo _photoRepo;
        private readonly IMapper _mapper;
        private IOptions<CloudinarySettings> _cloudinarySettings;
        private Cloudinary _cloudinary;

        public PhotosController(IUserRepo userRepo, IPhotoRepo photoRepo, IMapper mapper, IOptions<CloudinarySettings> cloudinarySettings)
        {
            _userRepo = userRepo;
            _photoRepo = photoRepo;
            _mapper = mapper;
            _cloudinarySettings = cloudinarySettings;

            Account account = new Account(
                _cloudinarySettings.Value.CloudName,
                _cloudinarySettings.Value.APIKey,
                _cloudinarySettings.Value.APISecret
            );

            _cloudinary = new Cloudinary(account);
        }

        [HttpGet("{id}", Name = "GetPhoto")]
        public async Task<IActionResult> GetPhoto(int id)
        {
            var photoFromDb = await _photoRepo.GetPhoto(id);

            if (photoFromDb == null)
                return NotFound();

            var photoReturnDto = _mapper.Map<PhotoReturnDto>(photoFromDb);

            return Ok(photoReturnDto);
        }

        [HttpPost("add/user/{id}")]
        public async Task<IActionResult> AddPhoto(string id, [FromForm] PhotoToCreateDto photoToCreateDto)
        {
            if (id != User.FindFirst(ClaimTypes.NameIdentifier).Value)
                return Unauthorized();

            var user = await _userRepo.GetUserById(id);

            var file = photoToCreateDto.File;

            var uploadResult = new ImageUploadResult();



            if(file.Length > 0)
            {
                using(var stream = file.OpenReadStream())
                {
                    var uploadParams = new ImageUploadParams
                    {
                        File = new FileDescription(file.FileName, stream),
                        Transformation = new Transformation()
                            .Width(500).Height(500).Crop("fill").Gravity("face")
                    };

                    uploadResult = _cloudinary.Upload(uploadParams);
                }
            }

            photoToCreateDto.Url = uploadResult.Url.AbsoluteUri;
            photoToCreateDto.PublicId = uploadResult.PublicId;

            var photo = _mapper.Map<Photo>(photoToCreateDto);
            await _photoRepo.AddPhoto(photo);

            if (await _photoRepo.Done() >= 0)
            {
                user.PhotoId = photo.Id;
                await _userRepo.Done();
                var photoReturnDto = _mapper.Map<PhotoReturnDto>(photo);
                return CreatedAtRoute(nameof(GetPhoto), new { id = photo.Id }, photoReturnDto);
            }

            return BadRequest();
        }
    }
}