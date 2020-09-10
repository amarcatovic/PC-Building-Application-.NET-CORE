using PC_Building_Application.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data.Repositories.Interfaces
{
    public interface IManufacturerRepo
    {
        Task<IEnumerable<Manufacturer>> GetAllManufacturers();
        Task<Manufacturer> GetManufacturerById(int id);
        Task<Manufacturer> GetManufacturerCpusById(int id);
        Task<Manufacturer> GetManufacturerGpusById(int id);
        Task<Manufacturer> GetManufacturerCoolersById(int id);
        Task<Manufacturer> GetManufacturerMotherboardsById(int id);
        Task<Manufacturer> GetManufacturerRamsById(int id);
        Task<Manufacturer> GetManufacturerPowerSuppliesById(int id);
        Task<Manufacturer> GetManufacturerCasesById(int id);
        Task<Manufacturer> GetManufacturerStoragesById(int id);
    }
}
