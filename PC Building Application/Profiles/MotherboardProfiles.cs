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
            CreateMap<Motherboard, MotherboardReadDto>()
                .ForMember(dest => dest.Manufacturer, opt => opt.MapFrom(src => src.Manufacturer.Name))
                .ForMember(dest => dest.SocketType, opt => opt.MapFrom(src => src.SocketType.Name));
            CreateMap<MotherboardCreateDto, Motherboard>();
        }
    }
}
