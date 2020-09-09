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
using PC_Building_Application.Data.Models.Dtos.Motherboard_Dtos;
using PC_Building_Application.Data.Repositories.Interfaces;

namespace PC_Building_Application.Controllers
{
    [Route("api/Motherboards")]
    [ApiController]
    public class MotherboardsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMotherboardRepo _repo;

        public MotherboardsController(IMapper mapper, IMotherboardRepo repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        /// <summary>
        /// Returns all motherboards
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/motherboards
        ///
        /// </remarks>
        /// <response code="200">Returns motherboards info if okay</response> 
        [HttpGet]
        public async Task<IActionResult> GetMotherboards()
        {
            var mobos = await _repo.GetAllMotherboards();
            var mobosDto = _mapper.Map<IEnumerable<MotherboardReadDto>>(mobos);
            return Ok(mobosDto);
        }

        /// <summary>
        /// Returns single motherboard which id matches requested id
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/motherboards/1
        ///
        /// </remarks>
        /// <response code="200">Returns single motherboard info if okay</response>
        /// <response code="404">If something goes wrong</response>  
        [HttpGet("{id}", Name = "GetMotherboardById")]
        public async Task<IActionResult> GetMotherboardById(int id)
        {
            var moboFromDb = await _repo.GetMotherboardById(id);
            if (moboFromDb == null)
                return NotFound($"Motherboard with id {id} was not found!");

            var moboDto = _mapper.Map<MotherboardReadDto>(moboFromDb);
            return Ok(moboDto);
        }

        /// <summary>
        /// Creates motherboard from form-data
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/motherboards
        ///     form-data:
        ///         Name:               "New Mobo",
        ///         Released:           "01/01/2020",
        ///         SocketTypeId:       1,
        ///         MaxMemmoryFreq:     3200
        ///         NoOfM2Slots:        2,
        ///         HasRGB:             true,
        ///         NoOfPCIeSlots:      2,
        ///         NoOfRAMSlots:       4,
        ///         ManufacturerId:     1,
        ///         PhotoFile:          type: File,
        ///         PhotoDescription:   "Awesome MoBo"
        ///
        /// </remarks>
        /// <response code="201">Returns motherboard info if okay</response>
        /// <response code="400">If something goes wrong</response>  
        [HttpPost]
        public async Task<IActionResult> AddMotherboard([FromForm] MotherboardCreateDto motherboardCreateDto)
        {
            var photoToCreateDto = new PhotoToCreateDto()
            {
                Description = motherboardCreateDto.PhotoDescription,
                File = motherboardCreateDto.PhotoFile
            };

            var motherboard = _mapper.Map<Motherboard>(motherboardCreateDto);
            await _repo.CreateMotherboard(motherboard, photoToCreateDto);
            if(await _repo.Done() >= 0)
            {
                var motherboardReadDto = _mapper.Map<MotherboardReadDto>(motherboard);
                return CreatedAtRoute(nameof(GetMotherboardById), new { id = motherboardReadDto.Id }, motherboardReadDto);
            }

            return BadRequest("Something went wrong. Review data and try again");
        }

        /// <summary>
        /// Updates values given in JSON document array
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PATCH /api/motherboards/1
        ///     [
        ///         {
        ///             "op": "replace",
        ///             "path": "/ManufacturerId",
        ///             "value": "1"
        ///         }
        ///     ]
        ///
        /// </remarks>
        /// <response code="204">Returns no content if okay</response>
        /// <response code="404">If something goes wrong</response>  
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchMotherboard(int id, JsonPatchDocument<MotherboardPatchDto> patchDocument)
        {
            var moboFromDb = await _repo.GetMotherboardById(id);
            if (moboFromDb == null)
                return NotFound($"Motherboard with id {id} was not found");

            var motherboardPatch = _mapper.Map<MotherboardPatchDto>(moboFromDb);
            patchDocument.ApplyTo(motherboardPatch, ModelState);

            if (!TryValidateModel(motherboardPatch))
                return ValidationProblem(ModelState);

            _mapper.Map(motherboardPatch, moboFromDb);
            await _repo.Done();

            return NoContent();
        }
    }
}