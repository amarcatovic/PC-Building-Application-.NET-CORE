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
using PC_Building_Application.Data.Models.Dtos.Case_Dtos;
using PC_Building_Application.Data.Repositories.Interfaces;

namespace PC_Building_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CasesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICaseRepo _repo;
        public CasesController(IMapper mapper, ICaseRepo repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        /// <summary>
        /// Returns all cases
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/cases
        ///
        /// </remarks>
        /// <response code="200">Returns cases info if okay</response> 
        [HttpGet]
        public async Task<IActionResult> GetCases()
        {
            var casesFromDb = await _repo.GetCases();
            var caseReadDto = _mapper.Map<IEnumerable<CaseReadDto>>(casesFromDb);

            return Ok(caseReadDto);
        }

        /// <summary>
        /// Returns single case which id matches requested id
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/cases/5
        ///
        /// </remarks>
        /// <response code="200">Returns single case info if okay</response>
        /// <response code="404">If something goes wrong</response> 
        [HttpGet("{id}", Name = "GetCaseById")]
        public async Task<IActionResult> GetCaseById(int id)
        {
            var caseFromDb = await _repo.GetCaseById(id);
            if (caseFromDb == null)
                return NotFound($"CPU with an id {id} was not found!");

            var caseReadDto = _mapper.Map<CaseReadDto>(caseFromDb);
            return Ok(caseReadDto);
        }

        /// <summary>
        /// Creates case from form-data
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/cases
        ///     form-data:
        ///         Name:                   "New Case",
        ///         Released:               "01/01/2020",
        ///         NoOfUSB3Ports:          2,
        ///         HasRGB:                 true
        ///         HasScreen:              false,
        ///         Size:                   "Mid Tower",
        ///         ManufacturerId:         1,
        ///         Price:                  49.99,
        ///         PhotoFile:              type: File,
        ///         PhotoDescription:       "Awesome New CPU"
        ///
        /// </remarks>
        /// <response code="201">Returns case info if okay</response>
        /// <response code="400">If something goes wrong</response>  
        [HttpPost]
        public async Task<IActionResult> AddCase([FromForm] CaseCreateDto caseCreateDto)
        {
            var photoToCreateDto = new PhotoToCreateDto()
            {
                Description = caseCreateDto.PhotoDescription,
                File = caseCreateDto.PhotoFile
            };

            var @case = _mapper.Map<Case>(caseCreateDto);
            await _repo.CreateCase(@case, photoToCreateDto);
            if (await _repo.Done())
            {
                var caseReadDto = _mapper.Map<CaseReadDto>(@case);
                return CreatedAtRoute(nameof(GetCaseById), new { id = caseReadDto.Id }, caseReadDto);
            }

            return BadRequest("Something went wrong. Review data and try again");
        }

        /// <summary>
        /// Updates values given in JSON document array
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PATCH /api/cases/5
        ///     [
        ///         {
        ///             "op": "replace",
        ///             "path": "/Price",
        ///             "value": "300"
        ///         }
        ///     ]
        ///
        /// </remarks>
        /// <response code="204">Returns no content if okay</response>
        /// <response code="404">If something goes wrong</response>  
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchCase(int id, JsonPatchDocument<CasePatchDto> patchDocument)
        {
            var caseFromDb = await _repo.GetCaseById(id);
            if (caseFromDb == null)
                return NotFound($"Case with an id {id} was not found!");

            var casePatch = _mapper.Map<CasePatchDto>(caseFromDb);
            patchDocument.ApplyTo(casePatch, ModelState);
            if (!TryValidateModel(casePatch))
                return ValidationProblem(ModelState);

            _mapper.Map(casePatch, caseFromDb);
            if (await _repo.Done())
                return NoContent();

            return BadRequest("Something went wrong!");
        }
    }
}
