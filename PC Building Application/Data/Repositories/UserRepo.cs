using Microsoft.EntityFrameworkCore;
using PC_Building_Application.Data.Models;
using PC_Building_Application.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data.Repositories
{
    public class UserRepo : IUserRepo
    {
        private readonly DataContext _context;

        public UserRepo(DataContext context)
        {
            _context = context;
        }
        public async Task<User> Login(string username, string password)
        {
            var userFromDb = await _context.Users.SingleOrDefaultAsync(u => u.UserName == username);

            if (userFromDb == null)
                return null;

            if (!CheckPasswordValidity(password, userFromDb.PasswordHash, userFromDb.PasswordSalt))
                return null;

            return userFromDb;
            
        }
        public async Task<User> Register(User newUser, string password)
        {
            byte[] passwordHash, passwordSalt;

            CreateSecuredPassword(password, out passwordHash, out passwordSalt);

            newUser.PasswordHash = passwordHash;
            newUser.PasswordSalt = passwordSalt;

            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();

            return newUser;
        }

        private bool CheckPasswordValidity(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var sha = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var calculatedHash = sha.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for(int i = 0; i < calculatedHash.Length; ++i)
                {
                    if (calculatedHash[i] != passwordHash[i])
                        return false;
                }
            }

            return true;
        }

        private void CreateSecuredPassword(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var sha = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = sha.Key;
                passwordHash = sha.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> UserExsists(string username)
        {
            if (await _context.Users.SingleOrDefaultAsync(u => u.UserName == username) == null)
                return false;

            return true;
        }
    }
}
