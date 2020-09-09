using AutoMapper;
using PC_Building_Application.Data.Models;
using PC_Building_Application.Data.Models.Dtos.Socket_Type_Dtos;

namespace PC_Building_Application.Profiles
{
    public class SocketTypeProfiles : Profile
    {
        public SocketTypeProfiles()
        {
            CreateMap<SocketTypeCreateDto, SocketType>();
            CreateMap<SocketType, SocketTypesReadDto>();
            CreateMap<SocketType, SocketTypeReadCPUAndMotherboards>();
            CreateMap<SocketType, SocketTypeReadCPUDto>();
            CreateMap<SocketType, SocketTypeReadMotherboardsDto>();
        }
    }
}
