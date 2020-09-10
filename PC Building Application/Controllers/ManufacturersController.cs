using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PC_Building_Application.Data.Models.Dtos.Manufacturer_Dtos;
using PC_Building_Application.Data.Repositories.Interfaces;

namespace PC_Building_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private IManufacturerRepo _repo;

        public ManufacturersController(IMapper mapper, IManufacturerRepo repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet("products/all")]
        public async Task<IActionResult> GetManufacturersWithAllProducts()
        {
            var manufacturersFromDb = await _repo.GetAllManufacturers();
            var manufacturerReadAllDto = _mapper.Map<IEnumerable<ManufacturerReadAllDto>>(manufacturersFromDb);

            return Ok(manufacturerReadAllDto);
        }

        [HttpGet("products/all/{id}")]
        public async Task<IActionResult> GetManufacturerWithAllItsProductsById(int id)
        {
            var manufacturerFromDb = await _repo.GetManufacturerById(id);
            if (manufacturerFromDb == null)
                return NotFound($"Manufacturer with an id {id} was not found!");

            var manufacturerReadDto = _mapper.Map<ManufacturerReadAllDto>(manufacturerFromDb);
            return Ok(manufacturerReadDto);
        }

        [HttpGet("products/cpus/{id}")]
        public async Task<IActionResult> GetManufacturerWithAllCPUProductsById(int id)
        {
            var manufacturerFromDb = await _repo.GetManufacturerById(id);
            if (manufacturerFromDb == null)
                return NotFound($"Manufacturer with an id {id} was not found!");

            var manufacturerReadDto = _mapper.Map<ManufacturerReadCpusDto>(manufacturerFromDb);
            return Ok(manufacturerReadDto);
        }

    }
}