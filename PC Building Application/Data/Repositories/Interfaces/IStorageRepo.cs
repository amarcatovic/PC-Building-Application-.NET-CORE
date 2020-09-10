using PC_Building_Application.Data.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data.Repositories.Interfaces
{
    public interface IStorageRepo
    {
        Task<IEnumerable<Storage>> GetStorages();
        Task<Storage> GetStorageById(int id);
        Task CreateStorage(Storage storage, PhotoToCreateDto photo);
        Task<bool> Done();
    }
}
