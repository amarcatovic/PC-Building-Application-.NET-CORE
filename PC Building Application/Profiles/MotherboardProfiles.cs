using AutoMapper;
using PC_Building_Application.Data.Models;
using PC_Building_Application.Data.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Profiles
{
    public class MotherboardProfiles : Profile
    {
        public MotherboardProfiles()
        {
            CreateMap<Motherboard, MotherboardReadDto>();
            CreateMap<MotherboardCreateDto, Motherboard>();
        }
    }
}
