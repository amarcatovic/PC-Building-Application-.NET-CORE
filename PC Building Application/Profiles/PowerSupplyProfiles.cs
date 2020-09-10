using AutoMapper;
using PC_Building_Application.Data.Models;
using PC_Building_Application.Data.Models.Dtos.Power_Supply_Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Profiles
{
    public class PowerSupplyProfiles : Profile
    {
        public PowerSupplyProfiles()
        {
            CreateMap<PowerSupply, PowerSupplyReadDto>()
                .ForMember(dest => dest.Manufacturer, opt => opt.MapFrom(src => src.Manufacturer.Name));
            
            CreateMap<PowerSupply, PowerSupplyPatchDto>().ReverseMap();
            CreateMap<PowerSupplyCreateDto, PowerSupply>();
        }
    }
}
