using AutoMapper;
using PC_Building_Application.Data.Models;
using PC_Building_Application.Data.Models.Dtos.RAM_Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Profiles
{
    public class RAMProfiles : Profile
    {
        public RAMProfiles()
        {
            CreateMap<RAM, RAMReadDto>();
            CreateMap<RAM, RAMPatchDto>();
            CreateMap<RAMPatchDto, RAM>();
            CreateMap<RAMCreateDto, RAM>();
        }
    }
}
