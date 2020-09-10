using AutoMapper;
using PC_Building_Application.Data.Models;
using PC_Building_Application.Data.Models.Dtos.Cooler_Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Profiles
{
    public class CoolerProfiles : Profile
    {
        public CoolerProfiles()
        {
            CreateMap<Cooler, CoolerReadDto>()
                .ForMember(dest => dest.Manufacturer, opt => opt.MapFrom(src => src.Manufacturer.Name));

            CreateMap<Cooler, CoolerPatchDto>().ReverseMap();
            CreateMap<CoolerCreateDto, Cooler>();
        }
    }
}
