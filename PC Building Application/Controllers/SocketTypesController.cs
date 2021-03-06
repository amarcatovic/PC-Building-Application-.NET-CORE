﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PC_Building_Application.Data.Models;
using PC_Building_Application.Data.Models.Dtos.Socket_Type_Dtos;
using PC_Building_Application.Data.Repositories.Interfaces;

namespace PC_Building_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocketTypesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISocketTypeRepo _repo;

        public SocketTypesController(IMapper mapper, ISocketTypeRepo repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        /// <summary>
        /// Returns socket types with their id and name
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/sockettypes
        ///
        /// </remarks>
        /// <response code="200">if okay</response>
        [HttpGet]
        public async Task<IActionResult> GetSocketTypes()
        {
            var socketTypesFromDb = await _repo.GetSocketTypes();

            var socketTypesReadDto = _mapper.Map<IEnumerable<SocketTypesReadDto>>(socketTypesFromDb);

            return Ok(socketTypesReadDto);
        }

        /// <summary>
        /// Returns socket types with their id, name and all cpus and motherboards that use this socket type
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/sockettypes/cpu/motherboard
        ///
        /// </remarks>
        /// <response code="200">if okay</response>
        [HttpGet("cpu/motherboard")]
        public async Task<IActionResult> GetSocketTypesWithCpusAndMobos()
        {
            var socketTypesFromDb = await _repo.GetSocketTypes();

            var socketTypesReadDto = _mapper.Map<IEnumerable<SocketTypeReadCPUAndMotherboards>>(socketTypesFromDb);

            return Ok(socketTypesReadDto);
        }

        /// <summary>
        /// Returns socket types with their id, name and all cpus that use this socket type
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/sockettypes/cpu
        ///
        /// </remarks>
        /// <response code="200">if okay</response>
        [HttpGet("cpu")]
        public async Task<IActionResult> GetSocketTypesWithCpus()
        {
            var socketTypesFromDb = await _repo.GetSocketTypes();

            var socketTypesReadDto = _mapper.Map<IEnumerable<SocketTypeReadCPUDto>>(socketTypesFromDb);

            return Ok(socketTypesReadDto);
        }

        /// <summary>
        /// Returns socket types with their id, name and all motherboards that use this socket type
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/sockettypes/motherboard
        ///
        /// </remarks>
        /// <response code="200">if okay</response>
        [HttpGet("motherboard")]
        public async Task<IActionResult> GetSocketTypesWithMotherboards()
        {
            var socketTypesFromDb = await _repo.GetSocketTypes();

            var socketTypesReadDto = _mapper.Map<IEnumerable<SocketTypeReadMotherboardsDto>>(socketTypesFromDb);

            return Ok(socketTypesReadDto);
        }

        /// <summary>
        /// Returns single socket type with id and name
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/sockettypes/5
        ///
        /// </remarks>
        /// <response code="200">if okay</response>
        /// <response code="404">if not okay</response>
        [HttpGet("{id}", Name = "GetSocketTypeById")]
        public async Task<IActionResult> GetSocketTypeById(int id)
        {
            var socketTypeFromDb = await _repo.GetSingleSocketTypeById(id);

            if (socketTypeFromDb == null)
                return NotFound($"Socket Type with id {id} was not found!");

            var socketTypeReadDto = _mapper.Map<SocketTypesReadDto>(socketTypeFromDb);
            return Ok(socketTypeReadDto);
        }

        /// <summary>
        /// Returns single socket type with id, name and all motherboards and cpus that use this socket type
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/sockettypes/cpu/motherboard/5
        ///
        /// </remarks>
        /// <response code="200">if okay</response>
        /// <response code="404">if not okay</response>
        [HttpGet("cpu/motherboard/{id}")]
        public async Task<IActionResult> GetSocketTypesWithCpusAndMobosById(int id)
        {
            var socketTypeFromDb = await _repo.GetSingleSocketTypeById(id);

            if (socketTypeFromDb == null)
                return NotFound($"Socket Type with id {id} was not found!");

            var socketTypeReadDto = _mapper.Map<SocketTypeReadCPUAndMotherboards>(socketTypeFromDb);
            return Ok(socketTypeReadDto);
        }

        /// <summary>
        /// Returns single socket type with id, name and all cpus that use this socket type
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/sockettypes/cpu/5
        ///
        /// </remarks>
        /// <response code="200">if okay</response>
        /// <response code="404">if not okay</response>
        [HttpGet("cpu/{id}")]
        public async Task<IActionResult> GetSocketTypesWithCpusById(int id)
        {
            var socketTypeFromDb = await _repo.GetSingleSocketTypeById(id);

            if (socketTypeFromDb == null)
                return NotFound($"Socket Type with id {id} was not found!");

            var socketTypeReadDto = _mapper.Map<SocketTypeReadCPUDto>(socketTypeFromDb);
            return Ok(socketTypeReadDto);
        }

        /// <summary>
        /// Returns single socket type with id, name and all motherboards that use this socket type
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/sockettypes/motherboard/5
        ///
        /// </remarks>
        /// <response code="200">if okay</response>
        /// <response code="404">if not okay</response>
        [HttpGet("motherboard/{id}")]
        public async Task<IActionResult> GetSocketTypesWithMotherboardsById(int id)
        {
            var socketTypeFromDb = await _repo.GetSingleSocketTypeById(id);

            if (socketTypeFromDb == null)
                return NotFound($"Socket Type with id {id} was not found!");

            var socketTypeReadDto = _mapper.Map<SocketTypeReadMotherboardsDto>(socketTypeFromDb);
            return Ok(socketTypeReadDto);
        }

        /// <summary>
        /// Creates a new Socket Type
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/sockettypes
        ///     
        ///         {
        ///             "name": "LGA1150"
        ///         }
        ///
        /// </remarks>
        /// <response code="201">if okay</response>
        /// <response code="400">if not okay</response>
        [HttpPost]
        public async Task<IActionResult> CreateSocketType(SocketTypeCreateDto socketTypeCreateDto)
        {
            var socketType = _mapper.Map<SocketType>(socketTypeCreateDto);
            await _repo.CreateSocketType(socketType);
            
            if(await _repo.Done())
            {
                var socketTypeReadDto = _mapper.Map<SocketTypesReadDto>(socketType);
                return CreatedAtRoute(nameof(GetSocketTypeById), new { id = socketTypeReadDto.Id }, socketTypeReadDto);
            }

            return BadRequest("Something went wrong");
        }

    }
}