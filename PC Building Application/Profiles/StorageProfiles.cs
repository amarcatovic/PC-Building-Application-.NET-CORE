using AutoMapper;
using PC_Building_Application.Data;
using PC_Building_Application.Data.Models.Dtos.Storage_Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Profiles
{
    public class StorageProfiles : Profile
    {
        public StorageProfiles()
        {
            CreateMap<Storage, StorageReadDto>()
                .ForMember(dest => dest.StorageType, opt => opt.MapFrom(src => src.StorageType.Name))
                .ForMember(dest => dest.Manufacturer, opt => opt.MapFrom(src => src.Manufacturer.Name));

            CreateMap<Storage, StoragePatchDto>().ReverseMap();
            CreateMap<StorageCreateDto, Storage>();
        }
    }
}
