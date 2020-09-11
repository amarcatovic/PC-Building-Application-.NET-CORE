using PC_Building_Application.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data.Repositories.Interfaces
{
    public interface IPCRepo
    {
        Task CreatePCInitial(PC pc);
        Task<PC> GetPCById(int id);
        Task<PC> CreatePCWithParts(int id, PC pc);
    }
}
