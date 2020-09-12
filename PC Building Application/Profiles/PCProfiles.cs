using AutoMapper;
using PC_Building_Application.Data.Models;
using PC_Building_Application.Data.Models.Dtos.PC_Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Profiles
{
    public class PCProfiles : Profile
    {
        public PCProfiles()
        {
            CreateMap<PC, PCReadDto>()
                .ForMember(dest => dest.RAM, opt => opt.MapFrom(src => src.PCRAMs
                                                                    .Select(pcrams => pcrams.RAM)))
                .ForMember(dest => dest.Storage, opt => opt.MapFrom(src => src.PCStorages
                                                                    .Select(pcs => pcs.Storage)))
                .ForMember(dest => dest.GPU, opt => opt.MapFrom(src => src.PCGPUs
                                                                    .Select(pcgpu => pcgpu.GPU)));
            CreateMap<PCCreateDto, PC>();
            CreateMap<PCCreateWithPartsDto, PC>();
        }
    }
}
