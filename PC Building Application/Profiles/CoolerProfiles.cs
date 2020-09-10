using AutoMapper;
using PC_Building_Application.Data.Models;
using PC_Building_Application.Data.Models.Dtos.Cooler_Dtos;
using PC_Building_Application.Data.Models.Dtos.Socket_Type_Dtos;
using PC_Building_Application.Data.Models.Join_Classes;
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
                .ForMember(dest => dest.Manufacturer, opt => opt.MapFrom(src => src.Manufacturer.Name))
                .ForMember(dest => dest.Sockets, opt => opt.MapFrom(src => src.CoolerSocketTypes
                                                                .Select(st => st.SocketType)
                                                                .Select(st => st.Name)));

            CreateMap<Cooler, CoolerPatchDto>().ReverseMap();
            CreateMap<CoolerCreateDto, Cooler>();
            CreateMap<Cooler, CoolerCreatedReadDto>();
        }
    }
}
