using PC_Building_Application.Data.Models;
using PC_Building_Application.Data.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data.Repositories.Interfaces
{
    public interface IManufacturerRepo
    {
        Task<IEnumerable<Manufacturer>> GetAllManufacturersLight();
        Task<IEnumerable<Manufacturer>> GetAllManufacturers();
        Task<IEnumerable<Manufacturer>> GetManufacturerCpus();
        Task<IEnumerable<Manufacturer>> GetManufacturerGpus();
        Task<IEnumerable<Manufacturer>> GetManufacturerCoolers();
        Task<IEnumerable<Manufacturer>> GetManufacturerMotherboards();
        Task<IEnumerable<Manufacturer>> GetManufacturerRams();
        Task<IEnumerable<Manufacturer>> GetManufacturerPowerSupplies();
        Task<IEnumerable<Manufacturer>> GetManufacturerCases();
        Task<IEnumerable<Manufacturer>> GetManufacturerStorages();
        Task<Manufacturer> GetManufacturerByIdLight(int id);
        Task<Manufacturer> GetManufacturerById(int id);
        Task<Manufacturer> GetManufacturerCpusById(int id);
        Task<Manufacturer> GetManufacturerGpusById(int id);
        Task<Manufacturer> GetManufacturerCoolersById(int id);
        Task<Manufacturer> GetManufacturerMotherboardsById(int id);
        Task<Manufacturer> GetManufacturerRamsById(int id);
        Task<Manufacturer> GetManufacturerPowerSuppliesById(int id);
        Task<Manufacturer> GetManufacturerCasesById(int id);
        Task<Manufacturer> GetManufacturerStoragesById(int id);

        Task CraeteManufacturer(Manufacturer manufacturer, PhotoToCreateDto photo);

        Task<bool> Done();
    }
}
