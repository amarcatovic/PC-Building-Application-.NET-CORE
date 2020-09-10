using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using PC_Building_Application.Data;
using PC_Building_Application.Data.Models.Dtos;
using PC_Building_Application.Data.Models.Dtos.Storage_Dtos;
using PC_Building_Application.Data.Repositories.Interfaces;

namespace PC_Building_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoragesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IStorageRepo _repo;

        public StoragesController(IMapper mapper, IStorageRepo repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        /// <summary>
        /// Returns all storages
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/storages
        ///
        /// </remarks>
        /// <response code="200">Returns storages info if okay</response> 
        [HttpGet]
        public async Task<IActionResult> GetStorages()
        {
            var storagesFromDb = await _repo.GetStorages();
            var storageReadDto = _mapper.Map<IEnumerable<StorageReadDto>>(storagesFromDb);

            return Ok(storageReadDto);
        }

        /// <summary>
        /// Returns single storage which id matches requested id
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/storage/5
        ///
        /// </remarks>
        /// <response code="200">Returns single storage info if okay</response>
        /// <response code="404">If something goes wrong</response> 
        [HttpGet("{id}", Name = "GetStorageById")]
        public async Task<IActionResult> GetStorageById(int id)
        {
            var storageFromDb = await _repo.GetStorageById(id);
            if (storageFromDb == null)
                return NotFound($"Storage with an id {id} was not found!");

            var storageReadDto = _mapper.Map<StorageReadDto>(storageFromDb);
            return Ok(storageReadDto);
        }

        /// <summary>
        /// Creates storage from form-data
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/storages
        ///     form-data:
        ///         Name:                   "New CPU",
        ///         Released:               "01/05/2020",
        ///         Capacity:               "1TB",
        ///         StorageTypeId:          3
        ///         HasCooling:             false,
        ///         ManufacturerId:         1,
        ///         Price:                  139.99,
        ///         PhotoFile:              type: File,
        ///         PhotoDescription:       "Awesome New storage"
        ///
        /// </remarks>
        /// <response code="201">Returns storage info if okay</response>
        /// <response code="400">If something goes wrong</response>  
        [HttpPost]
        public async Task<IActionResult> AddCPU([FromForm] StorageCreateDto storageCreateDto)
        {
            var photoToCreateDto = new PhotoToCreateDto()
            {
                Description = storageCreateDto.PhotoDescription,
                File = storageCreateDto.PhotoFile
            };

            var storage = _mapper.Map<Storage>(storageCreateDto);
            await _repo.CreateStorage(storage, photoToCreateDto);
            if (await _repo.Done())
            {
                var storageReadDto = _mapper.Map<StorageReadDto>(storage);
                return CreatedAtRoute(nameof(GetStorageById), new { id = storageReadDto.Id }, storageReadDto);
            }

            return BadRequest("Something went wrong. Review data and try again");
        }

        /// <summary>
        /// Updates values given in JSON document array
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PATCH /api/storages/1
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
        public async Task<IActionResult> PatchCPU(int id, JsonPatchDocument<StoragePatchDto> patchDocument)
        {
            var storageFromDb = await _repo.GetStorageById(id);
            if (storageFromDb == null)
                return NotFound($"Storage with an id {id} was not found!");

            var storagePatch = _mapper.Map<StoragePatchDto>(storageFromDb);
            patchDocument.ApplyTo(storagePatch, ModelState);
            if (!TryValidateModel(storagePatch))
                return ValidationProblem(ModelState);

            _mapper.Map(storagePatch, storageFromDb);
            if (await _repo.Done())
                return NoContent();

            return BadRequest("Something went wrong!");
        }
    }
}
