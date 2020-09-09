using PC_Building_Application.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PC_Building_Application.Data.Repositories.Interfaces
{
    public interface ISocketTypeRepo
    {
        Task<IEnumerable<SocketType>> GetSocketTypes();
        Task<SocketType> GetSingleSocketTypeById(int id);
        Task CreateSocketType(SocketType socketType);
        bool Done();
    }
}
