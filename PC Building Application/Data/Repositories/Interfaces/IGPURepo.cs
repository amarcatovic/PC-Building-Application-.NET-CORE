using PC_Building_Application.Data.Models;
using PC_Building_Application.Data.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data.Repositories.Interfaces
{
    public interface IGPURepo
    {
        Task<IEnumerable<GPU>> GetAllGPUs();
        Task<GPU> GetGPUById(int id);
        Task CreateGPU(GPU gpu, PhotoToCreateDto photo);
        Task<int> Done();
    }
}
