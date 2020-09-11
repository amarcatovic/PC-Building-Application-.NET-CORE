using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PC_Building_Application.Data.Models;
using PC_Building_Application.Data.Models.Dtos.PC_Dtos;
using PC_Building_Application.Data.Repositories.Interfaces;

namespace PC_Building_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PCsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPCRepo _repo;
        private readonly IPCRamRepo _pCRamRepo;
        private readonly IPCStorageRepo _pCStorageRepo;

        public PCsController(IMapper mapper, IPCRepo repo, IPCRamRepo pCRamRepo, IPCStorageRepo pCStorageRepo)
        {
            _mapper = mapper;
            _repo = repo;
            _pCRamRepo = pCRamRepo;
            _pCStorageRepo = pCStorageRepo;
        }

        [HttpGet("build/{id}", Name = "GetPCById")]
        public async Task<IActionResult> GetPCById(int id)
        {
            var pcFromDb = await _repo.GetPCById(id);
            if (pcFromDb == null)
                return NotFound($"PC Build with an id {id} was not found");

            var pcReadDto = _mapper.Map<PCReadDto>(pcFromDb);
            return Ok(pcReadDto);
        }

        [HttpGet("build/{id}/validate")]
        public async Task<IActionResult> ValidatePCPartsCompatibility(int id)
        {
            var validationErrors = new List<string>();

            var pcFromDb = await _repo.GetPCById(id);

            var rams = pcFromDb.PCRAMs.Select(pcram => pcram.RAM);
            var storages = pcFromDb.PCStorages.Select(pcs => pcs.Storage);

            //--------------------------------------------------------------------------------------------------------------------
            //                                       MOTHERBOARD CHECKS
            //--------------------------------------------------------------------------------------------------------------------
            var moboCPUCheck = pcFromDb.Motherboard.CheckMotherboardAndCpuCompatibility(pcFromDb.CPU);
            if(moboCPUCheck.Count > 0)
            {
                foreach (var error in moboCPUCheck)
                    validationErrors.Add(error);
            }

            var moboRAMCheck = pcFromDb.Motherboard.CheckMotherboardAndRamsCompatibility(rams);
            if (moboRAMCheck.Count > 0)
            {
                foreach (var error in moboRAMCheck)
                    validationErrors.Add(error);
            }

            var moboCoolerCheck = pcFromDb.Motherboard.CheckMotherboardAndCoolerCompatibility(pcFromDb.Cooler);
            if (moboCoolerCheck.Count > 0)
            {
                foreach (var error in moboCoolerCheck)
                    validationErrors.Add(error);
            }

            var moboStorageCheck = pcFromDb.Motherboard.CheckMotherboardAndStorageCompatibility(storages);
            if (moboStorageCheck.Count > 0)
            {
                foreach (var error in moboStorageCheck)
                    validationErrors.Add(error);
            }

            //--------------------------------------------------------------------------------------------------------------------
            //                                                       GPU CHECKS
            //--------------------------------------------------------------------------------------------------------------------
            var gpuPowerSupplyCheck = pcFromDb.GPU.CheckGpuAndPowerSupplyCompatibility(pcFromDb.PowerSupply);
            if (gpuPowerSupplyCheck.Count > 0)
            {
                foreach (var error in gpuPowerSupplyCheck)
                    validationErrors.Add(error);
            }

            //--------------------------------------------------------------------------------------------------------------------
            //                                                       PSU CHECKS
            //--------------------------------------------------------------------------------------------------------------------
            var psuSataStorageCheck = pcFromDb.PowerSupply.CheckPsuAndStoragesompatibility(storages);
            if (psuSataStorageCheck.Count > 0)
            {
                foreach (var error in psuSataStorageCheck)
                    validationErrors.Add(error);
            }



            if (validationErrors.Count > 0)
                return Ok(validationErrors);

            return NoContent();
        }

        [HttpPost("build/create")]
        public async Task<IActionResult> CreatePC(PCCreateDto pCCreateDto)
        {
            var pc = _mapper.Map<PC>(pCCreateDto);
            await _repo.CreatePC(pc);

            if (!(await _repo.Done()))
                return BadRequest("There was an error with saving new PC build to the database. Please review inputs and try again");

            if(await _pCRamRepo.InsertRAMIntoPC(pc.Id, pCCreateDto.ramIds) && await _pCStorageRepo.InsertStorageInPC(pc.Id, pCCreateDto.ramIds))
            {
                var pcReadDto = _mapper.Map<PCReadDto>(pc);
                return CreatedAtRoute(nameof(GetPCById), new { id = pcReadDto.Id }, pcReadDto);
            }

            return BadRequest("There was an error with saving new PC build to the database. Please review inputs and try again");
        }

        [HttpPut("build/{id}/replace/case/{caseId}")]
        public async Task<IActionResult> ReplacePcCase(int id, int caseId)
        {
            await _repo.ReplaceCase(id, caseId);
            if (await _repo.Done())
                return NoContent();

            return BadRequest("There was an error with replacing case, review the data and try again");
        }

        [HttpPut("build/{id}/replace/cooler/{coolerId}")]
        public async Task<IActionResult> ReplacePcCooler(int id, int coolerId)
        {
            await _repo.ReplaceCooler(id, coolerId);
            if (await _repo.Done())
                return NoContent();

            return BadRequest("There was an error with replacing cooler, review the data and try again");
        }

        [HttpPut("build/{id}/replace/cpu/{cpuId}")]
        public async Task<IActionResult> ReplacePcCpu(int id, int cpuId)
        {
            await _repo.ReplaceCpu(id, cpuId);
            if (await _repo.Done())
                return NoContent();

            return BadRequest("There was an error with replacing cpu, review the data and try again");
        }

        [HttpPut("build/{id}/replace/gpu/{gpuId}")]
        public async Task<IActionResult> ReplacePcGpu(int id, int gpuId)
        {
            await _repo.ReplaceGpu(id, gpuId);
            if (await _repo.Done())
                return NoContent();

            return BadRequest("There was an error with replacing gpu, review the data and try again");
        }

        [HttpPut("build/{id}/replace/motherboard/{motherboardId}")]
        public async Task<IActionResult> ReplacePcMotherboard(int id, int motherboardId)
        {
            await _repo.ReplaceMotherboard(id, motherboardId);
            if (await _repo.Done())
                return NoContent();

            return BadRequest("There was an error with replacing motherboard, review the data and try again");
        }

        [HttpPut("build/{id}/replace/psu/{psuId}")]
        public async Task<IActionResult> ReplacePcPowerSupply(int id, int psuId)
        {
            await _repo.ReplacePowerSupply(id, psuId);
            if (await _repo.Done())
                return NoContent();

            return BadRequest("There was an error with replacing Power Supply, review the data and try again");
        }

        [HttpPut("build/{id}/remove/ram/{ramId}")]
        public async Task<IActionResult> RemovePcRam(int id, int ramId)
        {
            await _pCRamRepo.RemoveRam(id, ramId);
            if (await _repo.Done())
                return NoContent();

            return BadRequest("There was an error with removing RAM, review the data and try again");
        }

        [HttpPut("build/{id}/add/ram/{ramId}")]
        public async Task<IActionResult> AddPcRam(int id, int ramId)
        {
            await _pCRamRepo.AddRam(id, ramId);
            if (await _repo.Done())
                return NoContent();

            return BadRequest("There was an error with adding RAM, review the data and try again");
        }

        [HttpPut("build/{id}/remove/storage/{storageId}")]
        public async Task<IActionResult> RemovePcStorage(int id, int storageId)
        {
            await _pCStorageRepo.RemoveStorage(id, storageId);
            if (await _repo.Done())
                return NoContent();

            return BadRequest("There was an error with removing Storage, review the data and try again");
        }

        [HttpPut("build/{id}/add/storage/{storageId}")]
        public async Task<IActionResult> AddPcStorage(int id, int storageId)
        {
            await _pCStorageRepo.AddStorage(id, storageId);
            if (await _repo.Done())
                return NoContent();

            return BadRequest("There was an error with adding Storage, review the data and try again");
        }
    }
}