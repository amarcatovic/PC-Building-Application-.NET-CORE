using PC_Building_Application.Data.Models;
using PC_Building_Application.Data.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data.Repositories.Interfaces
{
    public interface IRAMRepo
    {
        Task<IEnumerable<RAM>> GetAllRAMs();
        Task<RAM> GetRAMById(int id);
        Task CreateRAM(RAM ram, PhotoToCreateDto photo);
        Task<int> Done();
    }
}
