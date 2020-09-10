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

        [HttpGet]
        public async Task<IActionResult> GetManufacturers()
        {
            var manufacturersFromDb = await _repo.GetAllManufacturersLight();
            var manufacturerReadDto = _mapper.Map<IEnumerable<ManufacturerReadDto>>(manufacturersFromDb);

            return Ok(manufacturerReadDto);
        }

        [HttpGet("products/all")]
        public async Task<IActionResult> GetManufacturersWithAllProducts()
        {
            var manufacturersFromDb = await _repo.GetAllManufacturers();
            var manufacturerReadAllDto = _mapper.Map<IEnumerable<ManufacturerReadAllDto>>(manufacturersFromDb);

            return Ok(manufacturerReadAllDto);
        }

        [HttpGet("products/cpus")]
        public async Task<IActionResult> GetManufacturersWithAllCpuProducts()
        {
            var manufacturersFromDb = await _repo.GetManufacturerCpus();
            var manufacturerReadAllDto = _mapper.Map<IEnumerable<ManufacturerReadCpusDto>>(manufacturersFromDb);

            return Ok(manufacturerReadAllDto);
        }

        [HttpGet("products/coolers")]
        public async Task<IActionResult> GetManufacturersWithAllCoolerProducts()
        {
            var manufacturersFromDb = await _repo.GetManufacturerCoolers();
            var manufacturerReadAllDto = _mapper.Map<IEnumerable<ManufacturerReadAllCoolersDto>>(manufacturersFromDb);

            return Ok(manufacturerReadAllDto);
        }

        [HttpGet("products/motherboards")]
        public async Task<IActionResult> GetManufacturersWithAllMotherboardProducts()
        {
            var manufacturersFromDb = await _repo.GetManufacturerMotherboards();
            var manufacturerReadAllDto = _mapper.Map<IEnumerable<ManufacturerReadAllMotherboardsDto>>(manufacturersFromDb);

            return Ok(manufacturerReadAllDto);
        }

        [HttpGet("products/gpus")]
        public async Task<IActionResult> GetManufacturersWithAllGpuProducts()
        {
            var manufacturersFromDb = await _repo.GetManufacturerGpus();
            var manufacturerReadAllDto = _mapper.Map<IEnumerable<ManufacturerReadAllGpusDto>>(manufacturersFromDb);

            return Ok(manufacturerReadAllDto);
        }

        [HttpGet("products/rams")]
        public async Task<IActionResult> GetManufacturersWithAllRamProducts()
        {
            var manufacturersFromDb = await _repo.GetManufacturerRams();
            var manufacturerReadAllDto = _mapper.Map<IEnumerable<ManufacturerReadAllRamsDto>>(manufacturersFromDb);

            return Ok(manufacturerReadAllDto);
        }

        [HttpGet("products/psus")]
        public async Task<IActionResult> GetManufacturersWithAllPowerSupplyProducts()
        {
            var manufacturersFromDb = await _repo.GetManufacturerPowerSupplies();
            var manufacturerReadAllDto = _mapper.Map<IEnumerable<ManufacturerReadAllPowerSuppliesDto>>(manufacturersFromDb);

            return Ok(manufacturerReadAllDto);
        }

        [HttpGet("products/cases")]
        public async Task<IActionResult> GetManufacturersWithAllCaseProducts()
        {
            var manufacturersFromDb = await _repo.GetManufacturerCases();
            var manufacturerReadAllDto = _mapper.Map<IEnumerable<ManufacturerReadAllCasesDto>>(manufacturersFromDb);

            return Ok(manufacturerReadAllDto);
        }

        [HttpGet("products/storages")]
        public async Task<IActionResult> GetManufacturersWithAllStorageProducts()
        {
            var manufacturersFromDb = await _repo.GetManufacturerStorages();
            var manufacturerReadAllDto = _mapper.Map<IEnumerable<ManufacturerReadAllStoragesDto>>(manufacturersFromDb);

            return Ok(manufacturerReadAllDto);
        }

        /* 
         * ---------------------------------------------------------------------------------------------------------------------------
         *                                                          BY IDS
         * ---------------------------------------------------------------------------------------------------------------------------      
         */

        [HttpGet("{id}", Name = "GetManufacturerById")]
        public async Task<IActionResult> GetManufacturerById(int id)
        {
            var manufacturerFromDb = await _repo.GetManufacturerByIdLight(id);
            if (manufacturerFromDb == null)
                return NotFound($"Manufacturer with an id {id} was not found!");

            var manufacturerReadDto = _mapper.Map<ManufacturerReadDto>(manufacturerFromDb);
            return Ok(manufacturerReadDto);
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
            var manufacturerFromDb = await _repo.GetManufacturerCpusById(id); 
            if (manufacturerFromDb == null)
                return NotFound($"Manufacturer with an id {id} was not found!");

            var manufacturerReadDto = _mapper.Map<ManufacturerReadCpusDto>(manufacturerFromDb);
            return Ok(manufacturerReadDto);
        }

        [HttpGet("products/gpus/{id}")]
        public async Task<IActionResult> GetManufacturerWithAllGPUProductsById(int id)
        {
            var manufacturerFromDb = await _repo.GetManufacturerGpusById(id);
            if (manufacturerFromDb == null)
                return NotFound($"Manufacturer with an id {id} was not found!");

            var manufacturerReadDto = _mapper.Map<ManufacturerReadAllGpusDto>(manufacturerFromDb);
            return Ok(manufacturerReadDto);
        }

        [HttpGet("products/coolers/{id}")]
        public async Task<IActionResult> GetManufacturerWithAllCoolerProductsById(int id)
        {
            var manufacturerFromDb = await _repo.GetManufacturerCoolersById(id);
            if (manufacturerFromDb == null)
                return NotFound($"Manufacturer with an id {id} was not found!");

            var manufacturerReadDto = _mapper.Map<ManufacturerReadAllCoolersDto>(manufacturerFromDb);
            return Ok(manufacturerReadDto);
        }

        [HttpGet("products/motherboards/{id}")]
        public async Task<IActionResult> GetManufacturerWithAllMotherboardProductsById(int id)
        {
            var manufacturerFromDb = await _repo.GetManufacturerMotherboardsById(id);
            if (manufacturerFromDb == null)
                return NotFound($"Manufacturer with an id {id} was not found!");

            var manufacturerReadDto = _mapper.Map<ManufacturerReadAllMotherboardsDto>(manufacturerFromDb);
            return Ok(manufacturerReadDto);
        }

        [HttpGet("products/rams/{id}")]
        public async Task<IActionResult> GetManufacturerWithAllRAMProductsById(int id)
        {
            var manufacturerFromDb = await _repo.GetManufacturerRamsById(id);
            if (manufacturerFromDb == null)
                return NotFound($"Manufacturer with an id {id} was not found!");

            var manufacturerReadDto = _mapper.Map<ManufacturerReadAllRamsDto>(manufacturerFromDb);
            return Ok(manufacturerReadDto);
        }

        [HttpGet("products/psus/{id}")]
        public async Task<IActionResult> GetManufacturerWithAllPowerSupplyProductsById(int id)
        {
            var manufacturerFromDb = await _repo.GetManufacturerPowerSuppliesById(id);
            if (manufacturerFromDb == null)
                return NotFound($"Manufacturer with an id {id} was not found!");

            var manufacturerReadDto = _mapper.Map<ManufacturerReadAllPowerSuppliesDto>(manufacturerFromDb);
            return Ok(manufacturerReadDto);
        }

        [HttpGet("products/cases/{id}")]
        public async Task<IActionResult> GetManufacturerWithAllCaseById(int id)
        {
            var manufacturerFromDb = await _repo.GetManufacturerCasesById(id);
            if (manufacturerFromDb == null)
                return NotFound($"Manufacturer with an id {id} was not found!");

            var manufacturerReadDto = _mapper.Map<ManufacturerReadAllCasesDto>(manufacturerFromDb);
            return Ok(manufacturerReadDto);
        }

        [HttpGet("products/storages/{id}")]
        public async Task<IActionResult> GetManufacturerWithAllStorageById(int id)
        {
            var manufacturerFromDb = await _repo.GetManufacturerStoragesById(id);
            if (manufacturerFromDb == null)
                return NotFound($"Manufacturer with an id {id} was not found!");

            var manufacturerReadDto = _mapper.Map<ManufacturerReadAllStoragesDto>(manufacturerFromDb);
            return Ok(manufacturerReadDto);
        }

        /* 
         * ---------------------------------------------------------------------------------------------------------------------------
         *                                                          POST
         * ---------------------------------------------------------------------------------------------------------------------------   
         */

        [HttpPost]
        public async Task<IActionResult> CreateManufacturer([FromForm] ManufacturerCreateDto manufacturerCreateDto)
        {
            var photoToCreateDto = new PhotoToCreateDto()
            {
                Description = manufacturerCreateDto.PhotoDescription,
                File = manufacturerCreateDto.PhotoFile
            };

            var manufacturer = _mapper.Map<Manufacturer>(manufacturerCreateDto);
            await _repo.CraeteManufacturer(manufacturer, photoToCreateDto);
            if (await _repo.Done())
            {
                var manufacturerReadDto = _mapper.Map<ManufacturerReadDto>(manufacturer);
                return CreatedAtRoute(nameof(GetManufacturerById), new { id = manufacturerReadDto.Id }, manufacturerReadDto);
            }

            return BadRequest("Something went wrong. Review data and try again");
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchCase(int id, JsonPatchDocument<ManufacturersPatchDto> patchDocument)
        {
            var manufacturerFromDb = await _repo.GetManufacturerByIdLight(id);
            if (manufacturerFromDb == null)
                return NotFound($"Manufacturer with an id {id} was not found!");

            var manufacturerPatch = _mapper.Map<ManufacturersPatchDto>(manufacturerFromDb);
            patchDocument.ApplyTo(manufacturerPatch, ModelState);
            if (!TryValidateModel(manufacturerPatch))
                return ValidationProblem(ModelState);

            _mapper.Map(manufacturerPatch, manufacturerFromDb);
            if (await _repo.Done())
                return NoContent();

            return BadRequest("Something went wrong!");
        }
    }
}