using AutoMapper;
using PC_Building_Application.Data.Models;
using PC_Building_Application.Data.Models.Dtos.Case_Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Profiles
{
    public class CaseProfiles : Profile
    {
        public CaseProfiles()
        {
            CreateMap<Case, CaseReadDto>()
                .ForMember(dest => dest.Manufacturer, opt => opt.MapFrom(src => src.Manufacturer.Name));

            CreateMap<Case, CasePatchDto>().ReverseMap();
            CreateMap<CaseCreateDto, Case>();
        }
    }
}
