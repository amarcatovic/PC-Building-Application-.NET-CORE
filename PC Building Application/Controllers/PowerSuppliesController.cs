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
using PC_Building_Application.Data.Models.Dtos.Power_Supply_Dtos;
using PC_Building_Application.Data.Repositories.Interfaces;

namespace PC_Building_Application.Controllers
{
    [Route("api/PSUs")]
    [ApiController]
    public class PowerSuppliesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPowerSupplyRepo _repo;

        public PowerSuppliesController(IMapper mapper, IPowerSupplyRepo repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        /// <summary>
        /// Returns all psus
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/psus
        ///
        /// </remarks>
        /// <response code="200">Returns psus info if okay</response> 
        [HttpGet]
        public async Task<IActionResult> GetPowerSupplies()
        {
            var psusFromDb = await _repo.GetAllPowerSupplys();
            var psuReadDto = _mapper.Map<IEnumerable<PowerSupplyReadDto>>(psusFromDb);

            return Ok(psuReadDto);
        }

        /// <summary>
        /// Returns single psu which id matches requested id
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/psus/5
        ///
        /// </remarks>
        /// <response code="200">Returns single psu info if okay</response>
        /// <response code="404">If something goes wrong</response> 
        [HttpGet("{id}", Name = "GetPowerSupplyById")]
        public async Task<IActionResult> GetPowerSupplyById(int id)
        {
            var powerSupplyFromDb = await _repo.GetPowerSupplyById(id);
            if (powerSupplyFromDb == null)
                return NotFound($"Power Supply with an id {id} was not found!");

            var powerSupplyReadDto = _mapper.Map<PowerSupplyReadDto>(powerSupplyFromDb);
            return Ok(powerSupplyReadDto);
        }

        /// <summary>
        /// Creates psu from form-data
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/psus
        ///     form-data:
        ///         Name:                   "New PSU",
        ///         Released:               "01/05/2020",
        ///         Power:                  "850W",
        ///         NoOfPCIe6Pins:          0
        ///         NoOfPCIe8Pins:          2,
        ///         NoOfSATACables:         6,
        ///         NoOfCPUCables:          2,
        ///         Has24PinCable:          true,
        ///         EfficiencyRating:       "Silver",
        ///         ManufacturerId:         5,
        ///         Price:                  199.99,
        ///         PhotoFile:              type: File,
        ///         PhotoDescription:       "Awesome New GPU"
        ///
        /// </remarks>
        /// <response code="201">Returns gpu info if okay</response>
        /// <response code="400">If something goes wrong</response>  
        [HttpPost]
        public async Task<IActionResult> AddPowerSupply([FromForm] PowerSupplyCreateDto powerSupplyCreateDto)
        {
            var photoToCreateDto = new PhotoToCreateDto()
            {
                Description = powerSupplyCreateDto.PhotoDescription,
                File = powerSupplyCreateDto.PhotoFile
            };

            var powerSupply = _mapper.Map<PowerSupply>(powerSupplyCreateDto);
            await _repo.CreatePowerSupply(powerSupply, photoToCreateDto);
            if (await _repo.Done() >= 0)
            {
                var powerSupplyReadDto = _mapper.Map<PowerSupplyReadDto>(powerSupply);
                return CreatedAtRoute(nameof(GetPowerSupplyById), new { id = powerSupplyReadDto.Id }, powerSupplyReadDto);
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
        public async Task<IActionResult> PatchCPU(int id, JsonPatchDocument<PowerSupplyPatchDto> patchDocument)
        {
            var powerSupplyFromDb = await _repo.GetPowerSupplyById(id);
            if (powerSupplyFromDb == null)
                return NotFound($"Power Supply with an id {id} was not found!");

            var powerSupplyPatch = _mapper.Map<PowerSupplyPatchDto>(powerSupplyFromDb);
            patchDocument.ApplyTo(powerSupplyPatch, ModelState);
            if (!TryValidateModel(powerSupplyPatch))
                return ValidationProblem(ModelState);

            _mapper.Map(powerSupplyPatch, powerSupplyFromDb);
            if (await _repo.Done() >= 0)
                return NoContent();

            return BadRequest("Something went wrong!");
        }
    }
}