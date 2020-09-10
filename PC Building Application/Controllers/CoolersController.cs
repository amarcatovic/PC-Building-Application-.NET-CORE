using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using PC_Building_Application.Data.Models;
using PC_Building_Application.Data.Models.Dtos;
using PC_Building_Application.Data.Models.Dtos.Cooler_Dtos;
using PC_Building_Application.Data.Repositories.Interfaces;

namespace PC_Building_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoolersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICoolerRepo _repo;
        private readonly ICoolerSocketTypeRepo _coolerSocketTypeRepo;

        public CoolersController(IMapper mapper, ICoolerRepo repo, ICoolerSocketTypeRepo coolerSocketTypeRepo)
        {
            _mapper = mapper;
            _repo = repo;
            _coolerSocketTypeRepo = coolerSocketTypeRepo;
        }

        /// <summary>
        /// Returns all coolers
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/coolers
        ///
        /// </remarks>
        /// <response code="200">Returns coolers info if okay</response> 
        [HttpGet]
        public async Task<IActionResult> GetAllCoolers()
        {
            var coolersFromDb = await _repo.GetCoolers();
            var coolerReadDto = _mapper.Map<IEnumerable<CoolerReadDto>>(coolersFromDb);

            return Ok(coolerReadDto);
        }

        /// <summary>
        /// Returns single cooler which id matches requested id
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/coolers/5
        ///
        /// </remarks>
        /// <response code="200">Returns single cooler info if okay</response>
        /// <response code="404">If something goes wrong</response>
        [HttpGet("{id}", Name = "GetCoolerById")]
        public async Task<IActionResult> GetCoolerById(int id)
        {
            var coolerFromDb = await _repo.GetCoolerById(id);
            if (coolerFromDb == null)
                return NotFound($"Cooler with an id {id} was not found");

            var coolerReadDto = _mapper.Map<CoolerReadDto>(coolerFromDb);
            return Ok(coolerReadDto);
        }

        /// <summary>
        /// Creates cooler from form-data
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/cpus
        ///     form-data:
        ///         Name:                   "New Cooler",
        ///         Released:               "01/05/2020",
        ///         IsWaterCooler:          true,
        ///         NoOfFans:               3
        ///         HasRGB:                 false,
        ///         ManufacturerId:         1,
        ///         Price:                  49.99,
        ///         PhotoFile:              type: File,
        ///         PhotoDescription:       "Awesome New Cooler",
        ///         SocketTypeIds[0]:       1
        ///         SocketTypeIds[1]:       2 
        ///         
        /// 
        ///         You can append Socket Type Ids in JavaScript like:
        ///         
        ///         const socketTypeIds = [1, 2, 3, 4];
        ///         for (let i = 0; i = socketTypeIds.length - 1; i++) {
        ///             formData.append('socketTypeIds[]', socketTypeIds[i]);
        ///         }
        ///
        /// </remarks>
        /// <response code="201">Returns cpu info if okay</response>
        /// <response code="400">If something goes wrong</response>  
        [HttpPost]
        public async Task<IActionResult> CreateCooler([FromForm] CoolerCreateDto coolerCreateDto)
        {
            var photoToCreateDto = new PhotoToCreateDto()
            {
                Description = coolerCreateDto.PhotoDescription,
                File = coolerCreateDto.PhotoFile
            };

            var cooler = _mapper.Map<Cooler>(coolerCreateDto);
            await _repo.CreateCooler(cooler, photoToCreateDto);
            if (await _repo.Done())
            {
                if(await _coolerSocketTypeRepo.InsertCoolerWithSocketTypes(cooler.Id, coolerCreateDto.SocketTypeIds))
                {
                    var coolerReadDto = _mapper.Map<CoolerCreatedReadDto>(cooler);
                    return CreatedAtRoute(nameof(GetCoolerById), new { id = coolerReadDto.Id }, coolerReadDto);
                }
            }

            return BadRequest("Something went wrong. Review data and try again");
        }

        /// <summary>
        /// Updates values given in JSON document array
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PATCH /api/coolers/1
        ///     [
        ///         {
        ///             "op": "replace",
        ///             "path": "/Price",
        ///             "value": "300"
        ///         }
        ///     ]
        ///
        /// </remarks>
        /// <response code="204">Returns no content if okay</response>
        /// <response code="404">If something goes wrong</response>  
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchCooler(int id, JsonPatchDocument<CoolerPatchDto> jsonPatchDocument)
        {
            var coolerFromDb = await _repo.GetCoolerById(id);
            if (coolerFromDb == null)
                return NotFound($"Cooler with an id {id} was not found");

            var coolerPatch = _mapper.Map<CoolerPatchDto>(coolerFromDb);
            jsonPatchDocument.ApplyTo(coolerPatch, ModelState);

            if (!TryValidateModel(ModelState))
                return ValidationProblem(ModelState);

            _mapper.Map(coolerPatch, coolerFromDb);
            if (await _repo.Done())
                return NoContent();

            return BadRequest("Something went wrong, please review the data and try again");
        }
    }
}