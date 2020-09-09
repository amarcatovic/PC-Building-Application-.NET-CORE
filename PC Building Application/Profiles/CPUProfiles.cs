using AutoMapper;
using PC_Building_Application.Data.Models;
using PC_Building_Application.Data.Models.Dtos.CPU_Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Profiles
{
    public class CPUProfiles : Profile
    {
        public CPUProfiles()
        {
            CreateMap<CPU, CPUReadDto>()
                .ForMember(dest => dest.SocketType, opt => opt.MapFrom(src => src.SocketType.Name))
                .ForMember(dest => dest.Manufacturer, opt => opt.MapFrom(src => src.Manufacturer.Name));
            CreateMap<CPUCreateDto, CPU>();
            CreateMap<CPUPatchDto, CPU>();
            CreateMap<CPU, CPUPatchDto>();
        }
    }
}
