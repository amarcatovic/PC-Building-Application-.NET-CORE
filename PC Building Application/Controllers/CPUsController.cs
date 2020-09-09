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
using PC_Building_Application.Data.Models.Dtos.CPU_Dtos;
using PC_Building_Application.Data.Repositories.Interfaces;

namespace PC_Building_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CPUsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICPURepo _repo;

        public CPUsController(IMapper mapper, ICPURepo repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        /// <summary>
        /// Returns all cpus
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/cpus
        ///
        /// </remarks>
        /// <response code="200">Returns cpus info if okay</response> 
        [HttpGet]
        public async Task<IActionResult> GetCPUs()
        {
            var cpusFromDb = await _repo.GetCPUs();
            var cpuReadDto = _mapper.Map<IEnumerable<CPUReadDto>>(cpusFromDb);

            return Ok(cpuReadDto);
        }

        /// <summary>
        /// Returns single cpu which id matches requested id
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/cpus/1
        ///
        /// </remarks>
        /// <response code="200">Returns single cpu info if okay</response>
        /// <response code="404">If something goes wrong</response> 
        [HttpGet("{id}", Name = "GetCPUById")]
        public async Task<IActionResult> GetCPUById(int id)
        {
            var cpuFromDb = await _repo.GetCPUById(id);
            if (cpuFromDb == null)
                return NotFound($"CPU with an id {id} was not found!");

            var cpuReadDto = _mapper.Map<CPUReadDto>(cpuFromDb);
            return Ok(cpuReadDto);
        }

        /// <summary>
        /// Creates cpu from form-data
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/cpus
        ///     form-data:
        ///         Name:                   "New CPU",
        ///         Released:               "01/05/2020",
        ///         SocketTypeId:           1,
        ///         Clockspeed:             3.6 GHz
        ///         TurboSpeed:             4.2 GHz,
        ///         SingleThreadRating:     17234, BASED ON https://www.cpubenchmark.net/
        ///         ManufacturerId:         1,
        ///         Price:                  319.99,
        ///         PhotoFile:              type: File,
        ///         PhotoDescription:       "Awesome New CPU"
        ///
        /// </remarks>
        /// <response code="201">Returns cpu info if okay</response>
        /// <response code="400">If something goes wrong</response>  
        [HttpPost]
        public async Task<IActionResult> AddCPU([FromForm] CPUCreateDto cpuCreateDto)
        {
            var photoToCreateDto = new PhotoToCreateDto()
            {
                Description = cpuCreateDto.PhotoDescription,
                File = cpuCreateDto.PhotoFile
            };

            var cpu = _mapper.Map<CPU>(cpuCreateDto);
            await _repo.CreateCPU(cpu, photoToCreateDto);
            if (await _repo.Done())
            {
                var cpuReadDto = _mapper.Map<CPUReadDto>(cpu);
                return CreatedAtRoute(nameof(GetCPUById), new { id = cpuReadDto.Id }, cpuReadDto);
            }

            return BadRequest("Something went wrong. Review data and try again");
        }

        /// <summary>
        /// Updates values given in JSON document array
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PATCH /api/cpus/1
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
        public async Task<IActionResult> PatchCPU(int id, JsonPatchDocument<CPUPatchDto> patchDocument)
        {
            var cpuFromDb = await _repo.GetCPUById(id);
            if(cpuFromDb == null)
                return NotFound($"CPU with an id {id} was not found!");

            var cpuPatch = _mapper.Map<CPUPatchDto>(cpuFromDb);
            patchDocument.ApplyTo(cpuPatch, ModelState);
            if (!TryValidateModel(cpuPatch))
                return ValidationProblem(ModelState);

            _mapper.Map(cpuPatch, cpuFromDb);
            if (await _repo.Done())
                return NoContent();

            return BadRequest("Something went wrong!");
        }
    }
}