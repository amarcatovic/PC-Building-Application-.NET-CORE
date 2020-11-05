using PC_Building_Application.Data.Models;
using PC_Building_Application.Data.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data.Repositories.Interfaces
{
    public interface IMotherboardRepo
    {
        Task<IEnumerable<MotherboardReadDto>> GetAllMotherboards();
        Task<MotherboardReadDto> GetMotherboardById(int id);
        Task<MotherboardReadDto> CreateMotherboard(MotherboardCreateDto motherboardCreateDto);
        Task<int> Done();
    }
}
