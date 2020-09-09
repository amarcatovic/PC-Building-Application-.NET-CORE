using PC_Building_Application.Data.Models;
using PC_Building_Application.Data.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data.Repositories.Interfaces
{
    public interface ICPURepo
    {
        Task<ICollection<CPU>> GetCPUs();
        Task<CPU> GetCPUById(int id);
        Task CreateCPU(CPU cpu, PhotoToCreateDto photo);
        Task<bool> Done();
    }
}
