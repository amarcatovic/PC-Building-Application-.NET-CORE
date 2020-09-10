using AutoMapper;
using PC_Building_Application.Data.Models;
using PC_Building_Application.Data.Models.Dtos.Manufacturer_Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Profiles
{
    public class ManufacturerProfiles : Profile
    {
        public ManufacturerProfiles()
        {
            CreateMap<Manufacturer, ManufacturerReadDto>();
            CreateMap<Manufacturer, ManufacturerReadAllDto>();
            CreateMap<Manufacturer, ManufacturerReadAllCasesDto>();
            CreateMap<Manufacturer, ManufacturerReadAllCoolersDto>();
            CreateMap<Manufacturer, ManufacturerReadAllGpusDto>();
            CreateMap<Manufacturer, ManufacturerReadAllMotherboardsDto>();
            CreateMap<Manufacturer, ManufacturerReadAllPowerSuppliesDto>();
            CreateMap<Manufacturer, ManufacturerReadAllRamsDto>();
            CreateMap<Manufacturer, ManufacturerReadAllStoragesDto>();
            CreateMap<Manufacturer, ManufacturerReadCpusDto>();
            CreateMap<ManufacturerCreateDto, Manufacturer>();
            CreateMap<Manufacturer, ManufacturersPatchDto>().ReverseMap();
        }
    }
}
