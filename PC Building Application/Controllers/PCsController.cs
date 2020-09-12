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
        private readonly IPCGPURepo _pcGpuRepo;

        public PCsController(IMapper mapper, IPCRepo repo, IPCRamRepo pCRamRepo, IPCStorageRepo pCStorageRepo, IPCGPURepo pCGPURepo)
        {
            _mapper = mapper;
            _repo = repo;
            _pCRamRepo = pCRamRepo;
            _pCStorageRepo = pCStorageRepo;
            _pcGpuRepo = pCGPURepo;
        }

        /// <summary>
        /// Returns single pc build which id matches requested id
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/pcs/build/5
        ///
        /// </remarks>
        /// <response code="200">Returns single pc build info if okay</response>
        /// <response code="404">If something goes wrong</response> 
        [HttpGet("build/{id}", Name = "GetPCById")]
        public async Task<IActionResult> GetPCById(int id)
        {
            var pcFromDb = await _repo.GetPCById(id);
            if (pcFromDb == null)
                return NotFound($"PC Build with an id {id} was not found");

            var pcReadDto = _mapper.Map<PCReadDto>(pcFromDb);
            return Ok(pcReadDto);
        }

        /// <summary>
        /// Checks if all pc parts are compatible
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/pcs/build/5/validate
        ///
        /// </remarks>
        /// <response code="204">Returns no content if all pc parts are compatible with other pc parts</response>
        /// <response code="200">Returns list of error messages if there are some incompatible parts</response> 
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
            var moboCPUCheck = pcFromDb.CheckMotherboardAndCpuCompatibility();
            if(moboCPUCheck.Count > 0)
            {
                foreach (var error in moboCPUCheck)
                    validationErrors.Add(error);
            }

            var moboRAMCheck = pcFromDb.CheckMotherboardAndRamsCompatibility();
            if (moboRAMCheck.Count > 0)
            {
                foreach (var error in moboRAMCheck)
                    validationErrors.Add(error);
            }

            var moboCoolerCheck = pcFromDb.CheckMotherboardAndCoolerCompatibility();
            if (moboCoolerCheck.Count > 0)
            {
                foreach (var error in moboCoolerCheck)
                    validationErrors.Add(error);
            }

            var moboStorageCheck = pcFromDb.CheckMotherboardAndStorageCompatibility();
            if (moboStorageCheck.Count > 0)
            {
                foreach (var error in moboStorageCheck)
                    validationErrors.Add(error);
            }

            //--------------------------------------------------------------------------------------------------------------------
            //                                                       GPU CHECKS
            //--------------------------------------------------------------------------------------------------------------------
            var gpuPowerSupplyCheck = pcFromDb.CheckGpuAndPowerSupplyCompatibility();
            if (gpuPowerSupplyCheck.Count > 0)
            {
                foreach (var error in gpuPowerSupplyCheck)
                    validationErrors.Add(error);
            }

            //--------------------------------------------------------------------------------------------------------------------
            //                                                       PSU CHECKS
            //--------------------------------------------------------------------------------------------------------------------
            var psuSataStorageCheck = pcFromDb.CheckPsuAndStoragesompatibility();
            if (psuSataStorageCheck.Count > 0)
            {
                foreach (var error in psuSataStorageCheck)
                    validationErrors.Add(error);
            }



            if (validationErrors.Count > 0)
                return Ok(validationErrors);

            return NoContent();
        }

        /// <summary>
        /// Creates pc build from json
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/pcs/build/create
        ///     {
        ///         "buildTitle": "Demo Build",
        ///         "buildDescription": "This is swagger build",
        ///         "motherboardId": 25,
        ///         "cpuId": 12,
        ///         "gpuId": 16,
        ///         "coolerId": 19,
        ///         "powerSupplyId": 23,
        ///         "caseId": 61,
        ///         "ramIds": [60, 60],
        ///         "storageIds": [51, 19, 67, 10],
        ///         "userId": "anonymous"  -> IF BUILD IS FROM GUEST USER, ELSE USE userId FROM LOGED USER
        ///     }
    ///
    /// </remarks>
    /// <response code="201">Returns pc build info if okay</response>
    /// <response code="400">If something goes wrong</response>  
    [HttpPost("build/create")]
        public async Task<IActionResult> CreatePC(PCCreateDto pCCreateDto)
        {
            if (pCCreateDto.ramIds.Count == 0 || pCCreateDto.storageIds.Count == 0)
                return BadRequest("You need to include at least one RAM Stick or package and One Storage device");

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

        /// <summary>
        /// Replaces case in PC build
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /api/pcs/build/{id}/replace/case/{caseId}
        ///
        /// </remarks>
        /// <response code="204">Returns no content if okay</response> 
        [HttpPut("build/{id}/replace/case/{caseId}")]
        public async Task<IActionResult> ReplacePcCase(int id, int caseId)
        {
            await _repo.ReplaceCase(id, caseId);
            if (await _repo.Done())
                return NoContent();

            return BadRequest("There was an error with replacing case, review the data and try again");
        }

        /// <summary>
        /// Replaces cooler in PC build
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /api/pcs/build/{id}/replace/cooler/{coolerId}
        ///
        /// </remarks>
        /// <response code="204">Returns no content if okay</response> 
        [HttpPut("build/{id}/replace/cooler/{coolerId}")]
        public async Task<IActionResult> ReplacePcCooler(int id, int coolerId)
        {
            await _repo.ReplaceCooler(id, coolerId);
            if (await _repo.Done())
                return NoContent();

            return BadRequest("There was an error with replacing cooler, review the data and try again");
        }

        /// <summary>
        /// Replaces CPU in PC build
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /api/pcs/build/{id}/replace/cpu/{cpuId}
        ///
        /// </remarks>
        /// <response code="204">Returns no content if okay</response> 
        [HttpPut("build/{id}/replace/cpu/{cpuId}")]
        public async Task<IActionResult> ReplacePcCpu(int id, int cpuId)
        {
            await _repo.ReplaceCpu(id, cpuId);
            if (await _repo.Done())
                return NoContent();

            return BadRequest("There was an error with replacing cpu, review the data and try again");
        }     

        /// <summary>
        /// Replaces Motherboard in PC build
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /api/pcs/build/{id}/replace/motherboard/{motherboardId}
        ///
        /// </remarks>
        /// <response code="204">Returns no content if okay</response> 
        [HttpPut("build/{id}/replace/motherboard/{motherboardId}")]
        public async Task<IActionResult> ReplacePcMotherboard(int id, int motherboardId)
        {
            await _repo.ReplaceMotherboard(id, motherboardId);
            if (await _repo.Done())
                return NoContent();

            return BadRequest("There was an error with replacing motherboard, review the data and try again");
        }

        /// <summary>
        /// Replaces Power Supply in PC build
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /api/pcs/build/{id}/replace/psu/{psuId}
        ///
        /// </remarks>
        /// <response code="204">Returns no content if okay</response> 
        [HttpPut("build/{id}/replace/psu/{psuId}")]
        public async Task<IActionResult> ReplacePcPowerSupply(int id, int psuId)
        {
            await _repo.ReplacePowerSupply(id, psuId);
            if (await _repo.Done())
                return NoContent();

            return BadRequest("There was an error with replacing Power Supply, review the data and try again");
        }

        /// <summary>
        /// Removes single gpu from PC build
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /api/pcs/build/{id}/remove/gpu/{gpuId}
        ///
        /// </remarks>
        /// <response code="204">Returns no content if okay</response> 
        [HttpPut("build/{id}/remove/gpu/{gpuId}")]
        public async Task<IActionResult> RemovePcGpu(int id, int gpuId)
        {
            await _pcGpuRepo.RemoveGpu(id, gpuId);
            if (await _repo.Done())
                return NoContent();

            return BadRequest("There was an error with removing GPU, review the data and try again");
        }

        /// <summary>
        /// Adds single GPU to the PC build
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /api/pcs/build/{id}/add/gpu/{gpuId}
        ///
        /// </remarks>
        /// <response code="204">Returns no content if okay</response> 
        [HttpPut("build/{id}/add/gpu/{gpuId}")]
        public async Task<IActionResult> AddPcGpu(int id, int gpuId)
        {
            await _pcGpuRepo.AddGpu(id, gpuId);
            if (await _repo.Done())
                return NoContent();

            return BadRequest("There was an error with adding GPU, review the data and try again");
        }

        /// <summary>
        /// Removes single RAM stick (or RAM package) in PC build
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /api/pcs/build/{id}/remove/ram/{ramId}
        ///
        /// </remarks>
        /// <response code="204">Returns no content if okay</response> 
        [HttpPut("build/{id}/remove/ram/{ramId}")]
        public async Task<IActionResult> RemovePcRam(int id, int ramId)
        {
            await _pCRamRepo.RemoveRam(id, ramId);
            if (await _repo.Done())
                return NoContent();

            return BadRequest("There was an error with removing RAM, review the data and try again");
        }

        /// <summary>
        /// Adds single RAM stick (or RAM package) in PC build
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /api/pcs/build/{id}/add/ram/{ramId}
        ///
        /// </remarks>
        /// <response code="204">Returns no content if okay</response> 
        [HttpPut("build/{id}/add/ram/{ramId}")]
        public async Task<IActionResult> AddPcRam(int id, int ramId)
        {
            await _pCRamRepo.AddRam(id, ramId);
            if (await _repo.Done())
                return NoContent();

            return BadRequest("There was an error with adding RAM, review the data and try again");
        }

        /// <summary>
        /// Removes single Storage Drive in PC build
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /api/pcs/build/{id}/remove/storage/{storageId}
        ///
        /// </remarks>
        /// <response code="204">Returns no content if okay</response> 
        [HttpPut("build/{id}/remove/storage/{storageId}")]
        public async Task<IActionResult> RemovePcStorage(int id, int storageId)
        {
            await _pCStorageRepo.RemoveStorage(id, storageId);
            if (await _repo.Done())
                return NoContent();

            return BadRequest("There was an error with removing Storage, review the data and try again");
        }

        /// <summary>
        /// Adds single Storage Drive in PC build
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /api/pcs/build/{id}/add/storage/{storageId}
        ///
        /// </remarks>
        /// <response code="204">Returns no content if okay</response> 
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