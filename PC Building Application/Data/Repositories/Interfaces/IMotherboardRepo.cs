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
        Task<Motherboard> GetAllMotherboards();
        Task<Motherboard> GetMotherboardById(int id);
        Task<Motherboard> CreateMotherboard(Motherboard mobo, PhotoToCreateDto photo);
    }
}
