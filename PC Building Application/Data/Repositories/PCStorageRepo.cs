using PC_Building_Application.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data.Repositories
{
    public class PCStorageRepo : IPCStorageRepo
    {
        private readonly DataContext _context;

        public PCStorageRepo(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> InsertStorageInPC(int pcId, IEnumerable<int> storageIds)
        {
            foreach (var storageId in storageIds)
            {
                await _context.PCStorage.AddAsync(new PCStorage() { StorageId = storageId, PCId = pcId });
            }

            if ((await _context.SaveChangesAsync()) >= 0)
                return true;

            return false;
        }
    }
}
