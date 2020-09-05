using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PC_Building_Application.Data.Models;
using PC_Building_Application.Data.Models.Dtos;
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

        [HttpGet]
        public async Task<IActionResult> GetMotherboards()
        {
            var mobos = await _repo.GetAllMotherboards();
            var mobosDto = _mapper.Map<IEnumerable<MotherboardReadDto>>(mobos);
            return Ok(mobosDto);
        }

        [HttpGet("{id}", Name = "GetMotherboardById")]
        public async Task<IActionResult> GetMotherboardById(int id)
        {
            var moboFromDb = await _repo.GetMotherboardById(id);
            if (moboFromDb == null)
                return NotFound($"Motherboard with id {id} was not found!");

            var moboDto = _mapper.Map<MotherboardReadDto>(moboFromDb);
            return Ok(moboDto);
        }

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
    }
}