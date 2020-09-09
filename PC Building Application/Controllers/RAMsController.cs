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
using PC_Building_Application.Data.Models.Dtos.RAM_Dtos;
using PC_Building_Application.Data.Repositories.Interfaces;

namespace PC_Building_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RAMsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRAMRepo _repo;

        public RAMsController(IMapper mapper, IRAMRepo repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRAMs()
        {
            var ramsFromDb = await _repo.GetAllRAMs();
            var ramReadDto = _mapper.Map<IEnumerable<RAMReadDto>>(ramsFromDb);

            return Ok(ramReadDto);
        }

        [HttpGet("{id}", Name = "GetRAMById")]
        public async Task<IActionResult> GetRAMById(int id)
        {
            var ramFromDb = await _repo.GetRAMById(id);
            if (ramFromDb == null)
                return NotFound($"RAM with an id {id} was not found!");

            var ramReadDto = _mapper.Map<RAMReadDto>(ramFromDb);
            return Ok(ramReadDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRAM([FromForm] RAMCreateDto ramCreateDto)
        {
            var photoToCreateDto = new PhotoToCreateDto()
            {
                Description = ramCreateDto.PhotoDescription,
                File = ramCreateDto.PhotoFile
            };

            var ram = _mapper.Map<RAM>(ramCreateDto);
            await _repo.CreateRAM(ram, photoToCreateDto);
            if (await _repo.Done() >= 0)
            {
                var ramReadDto = _mapper.Map<RAMReadDto>(ram);
                return CreatedAtRoute(nameof(GetRAMById), new { id = ramReadDto.Id }, ramReadDto);
            }

            return BadRequest("Something went wrong. Review data and try again");
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchRAM(int id, JsonPatchDocument<RAMPatchDto> patchDocument)
        {
            var ramFromDb = await _repo.GetRAMById(id);
            if (ramFromDb == null)
                return NotFound($"RAM with an id {id} was not found!");

            var ramPatch = _mapper.Map<RAMPatchDto>(ramFromDb);
            patchDocument.ApplyTo(ramPatch, ModelState);
            if (!TryValidateModel(ramPatch))
                return ValidationProblem(ModelState);

            _mapper.Map(ramPatch, ramFromDb);
            if (await _repo.Done() >= 0)
                return NoContent();

            return BadRequest("Something went wrong!");
        }
    }
}