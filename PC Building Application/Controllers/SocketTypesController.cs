using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public async Task<IActionResult> GetSocketTypes()
        {
            var socketTypesFromDb = await _repo.GetSocketTypes();



            return Ok(socketTypesFromDb);
        }
    }
}