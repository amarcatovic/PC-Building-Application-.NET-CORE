using AutoMapper;
using PC_Building_Application.Data.Models;
using PC_Building_Application.Data.Models.Dtos.GPU_Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Profiles
{
    public class GPUProfiles : Profile
    {
        public GPUProfiles()
        {
            CreateMap<GPU, GPUReadDto>()
                .ForMember(dest => dest.Manufacturer, opt => opt.MapFrom(src => src.Manufacturer.Name));

            CreateMap<GPU, GPUPatchDto>().ReverseMap();
            CreateMap<GPUCreateDto, GPU>();
        }
    }
}
