using PC_Building_Application.Data.Models;
using PC_Building_Application.Data.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data.Repositories.Interfaces
{
    public interface ICoolerRepo
    {
        Task<IEnumerable<Cooler>> GetCoolers();
        Task<Cooler> GetCoolerById(int id);
        Task CreateCooler(Cooler cooler, PhotoToCreateDto photo);
        Task<bool> Done();
    }
}
