﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PC_Building_Application.Data.Models;
using PC_Building_Application.Data.Models.Dtos;
using PC_Building_Application.Data.Repositories.Interfaces;

namespace PC_Building_Application.Controllers
{
    [Authorize]
    [Route("api/Users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserRepo _repo;
        private readonly IConfiguration _config;

        public UsersController(IMapper mapper, IUserRepo repo, IConfiguration config)
        {
            _mapper = mapper;
            _repo = repo;
            _config = config;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _repo.GetUsers();

            var mappedUsers = _mapper.Map<IEnumerable<UserReadDto>>(users);

            return Ok(mappedUsers);
        }

        [HttpGet("{id}", Name = "GetUserById")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var user = await _repo.GetUserById(id);
            if (user == null)
                return NotFound($"User with id {id} is not found!");

            var mappedUser = _mapper.Map<UserReadDto>(user);

            return Ok(mappedUser);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> RegisterNewUser(UserRegisterDto newUser)
        {
            if (await _repo.UserExsists(newUser.UserName))
                return BadRequest();

            var newUserMapped = _mapper.Map<User>(newUser);

            var createdUser = _repo.Register(newUserMapped, newUser.Password);

            if(await _repo.Done() > 0)
            {
                return CreatedAtRoute(nameof(GetUserById), new { id = createdUser.Id }, createdUser);
            }

            return BadRequest("Something went bad!");

        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto user)
        {
            var userFromDb = await _repo.Login(user.UserName, user.Password);

            if (userFromDb == null)
                return Unauthorized();

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFromDb.Id),
                new Claim(ClaimTypes.Name, userFromDb.UserName),
                new Claim(ClaimTypes.Email, userFromDb.Email),
                new Claim("Email Confirmed", userFromDb.EmailConfirmed.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new
            {
                token = tokenHandler.WriteToken(token)
            });
        }
    }
}