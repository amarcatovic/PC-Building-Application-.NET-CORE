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
using PC_Building_Application.Data.Models.Dtos.GPU_Dtos;
using PC_Building_Application.Data.Repositories.Interfaces;

namespace PC_Building_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GPUsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IGPURepo _repo;

        public GPUsController(IMapper mapper, IGPURepo repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        /// <summary>
        /// Returns all gpus
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/gpus
        ///
        /// </remarks>
        /// <response code="200">Returns gpus info if okay</response> 
        [HttpGet]
        public async Task<IActionResult> GetGPUs()
        {
            var gpusFromDb = await _repo.GetAllGPUs();
            var gpuReadDto = _mapper.Map<IEnumerable<GPUReadDto>>(gpusFromDb);

            return Ok(gpuReadDto);
        }

        /// <summary>
        /// Returns single gpu which id matches requested id
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/gpus/1
        ///
        /// </remarks>
        /// <response code="200">Returns single gpu info if okay</response>
        /// <response code="404">If something goes wrong</response> 
        [HttpGet("{id}", Name = "GetGPUById")]
        public async Task<IActionResult> GetGPUById(int id)
        {
            var gpuFromDb = await _repo.GetGPUById(id);
            if (gpuFromDb == null)
                return NotFound($"GPU with an id {id} was not found!");

            var gpuReadDto = _mapper.Map<GPUReadDto>(gpuFromDb);
            return Ok(gpuReadDto);
        }

        /// <summary>
        /// Creates gpu from form-data
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/gpus
        ///     form-data:
        ///         Name:                   "New GPU",
        ///         Released:               "01/06/2020",
        ///         PCIPort:                "x16",
        ///         MemoryType:             "DDR6",
        ///         VRAM:                   "11GB",
        ///         NoOfHDMIPorts:          2,
        ///         NoOfDisplayPorts:       2,
        ///         Price:                  319.99,
        ///         HasVGA                  false,
        ///         HasDVI                  true,
        ///         PhotoFile:              type: File,
        ///         PhotoDescription:       "Awesome New GPU"
        ///
        /// </remarks>
        /// <response code="201">Returns gpu info if okay</response>
        /// <response code="400">If something goes wrong</response>  
        [HttpPost]
        public async Task<IActionResult> AddGPU([FromForm] GPUCreateDto gpuCreateDto)
        {
            var photoToCreateDto = new PhotoToCreateDto()
            {
                Description = gpuCreateDto.PhotoDescription,
                File = gpuCreateDto.PhotoFile
            };

            var gpu = _mapper.Map<GPU>(gpuCreateDto);
            await _repo.CreateGPU(gpu, photoToCreateDto);
            if (await _repo.Done() >= 0)
            {
                var gpuReadDto = _mapper.Map<GPUReadDto>(gpu);
                return CreatedAtRoute(nameof(GetGPUById), new { id = gpuReadDto.Id }, gpuReadDto);
            }

            return BadRequest("Something went wrong. Review data and try again");
        }

        /// <summary>
        /// Updates values given in JSON document array
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PATCH /api/gpus/1
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
        public async Task<IActionResult> PatchGPU(int id, JsonPatchDocument<GPUPatchDto> patchDocument)
        {
            var gpuFromDb = await _repo.GetGPUById(id);
            if (gpuFromDb == null)
                return NotFound($"GPU with an id {id} was not found!");

            var gpuPatch = _mapper.Map<GPUPatchDto>(gpuFromDb);
            patchDocument.ApplyTo(gpuPatch, ModelState);
            if (!TryValidateModel(gpuPatch))
                return ValidationProblem(ModelState);

            _mapper.Map(gpuPatch, gpuFromDb);
            if (await _repo.Done() >= 0)
                return NoContent();

            return BadRequest("Something went wrong!");
        }
    }
}