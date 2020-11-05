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
        private readonly IMotherboardRepo _repo;

        public MotherboardsController(IMotherboardRepo repo)
        {
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
            var result = await _repo.GetAllMotherboards();
            return Ok(result);
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
            var result = await _repo.GetMotherboardById(id);
            if (result == null)
                return NotFound($"Motherboard with id {id} was not found!");

            return Ok(result);
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
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            
            var result = await _repo.CreateMotherboard(motherboardCreateDto);
            if(await _repo.Done() >= 0)
            {
                return CreatedAtRoute(nameof(GetMotherboardById), new { id = result.Id }, result);
            }

            return BadRequest("Something went wrong. Review data and try again");
        }
    }
}