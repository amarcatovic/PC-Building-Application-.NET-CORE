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
        private readonly IPhotoRepo _photoRepo;

        public PhotosController(IPhotoRepo photoRepo)
        {
            _photoRepo = photoRepo;
        }

        /// <summary>
        /// Returns single photo which id matches with requested id
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/photos/1
        ///     Header: Authorisation: Barer JWT
        ///
        /// </remarks>
        /// <response code="200">Returns photo info if okay</response>
        /// <response code="404">If something goes wrong</response>  
        [HttpGet("{id}", Name = "GetPhoto")]
        public async Task<IActionResult> GetPhoto(int id)
        {
            var result = await _photoRepo.GetPhoto(id);

            if (result == null)
                return NotFound();
            
            return Ok(result);
        }
    }
}