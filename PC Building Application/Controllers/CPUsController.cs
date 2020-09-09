﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
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

        [HttpGet("{id}", Name = "GetCPUById")]
        public async Task<IActionResult> GetCPUById(int id)
        {
            var cpuFromDb = await _repo.GetCPUById(id);
            if (cpuFromDb == null)
                return NotFound($"CPU with an id {id} was not found!");

            var cpuReadDto = _mapper.Map<CPUReadDto>(cpuFromDb);
            return Ok(cpuReadDto);
        }

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
    }
}