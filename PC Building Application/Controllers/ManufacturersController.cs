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
    }
}