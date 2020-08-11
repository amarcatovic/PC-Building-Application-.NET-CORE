using PC_Building_Application.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data.Repositories.Interfaces
{
    public interface IUserRepo
    {
        Task<User> Login(string username, string password);

        Task<User> Register(User newUser, string password);

        Task<bool> UserExsists(string username);

        Task<User> GetUserById(string id);
        Task<IEnumerable<User>> GetUsers();
    }
}
