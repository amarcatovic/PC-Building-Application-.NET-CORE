using PC_Building_Application.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data.Repositories.Interfaces
{
    public interface IPCRepo
    {
        Task CreatePC(PC pc);
        Task<PC> GetPCById(int id);
        Task<bool> Done();
        Task ReplaceMotherboard(int pcId, int motherboardId);
        Task ReplaceCpu(int pcId, int cpuId);
        Task ReplaceCooler(int pcId, int coolerId);
        Task ReplacePowerSupply(int pcId, int psuId);
        Task ReplaceCase(int pcId, int caseId);
    }
}
