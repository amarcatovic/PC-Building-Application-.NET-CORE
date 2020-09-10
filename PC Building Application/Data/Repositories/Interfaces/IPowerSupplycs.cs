using PC_Building_Application.Data.Models;
using PC_Building_Application.Data.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data.Repositories.Interfaces
{
    public interface IPowerSupplycs
    {
        Task<IEnumerable<PowerSupply>> GetAllPowerSupplys();
        Task<PowerSupply> GetPowerSupplyById(int id);
        Task CreatePowerSupply(PowerSupply powerSupply, PhotoToCreateDto photo);
        Task<int> Done();
    }
}
