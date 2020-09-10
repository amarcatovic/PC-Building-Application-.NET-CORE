using PC_Building_Application.Data.Models;
using PC_Building_Application.Data.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data.Repositories.Interfaces
{
    public interface ICaseRepo
    {
        Task<IEnumerable<Case>> GetCases();
        Task<Case> GetCaseById(int id);
        Task CreateCase(Case @case, PhotoToCreateDto photo);
        Task<bool> Done();
    }
}
