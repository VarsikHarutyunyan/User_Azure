using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Users.DataContexts;
using Users.Models;

namespace Users.Services
{
    public class Service : IService
    {
        private readonly DataContext _dataContext;
        public Service(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<User> CreateAsync(User user)
        {
          
                if (await UserExists(user.Name))
                    return null;
                _dataContext.User.Add(user);
                await _dataContext.SaveChangesAsync();
                return user;
           
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var user = await GetByIdAsync(id);
            if (user == null)
            {
                return false;
            }
            _dataContext.User.Remove(user);
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<User>> GetAllAsync()
        {
            var userList = await _dataContext.User.ToListAsync();
            return userList;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            var user = await _dataContext.User.FindAsync(id);
            return user;
        }

        public async Task<User> UpdateAsync(int id, User user)
        {
            var userToBeUpdated = await GetByIdAsync(id);
            if (userToBeUpdated == null || user == null)
            {
                return null;
            }
            userToBeUpdated.Name = user.Name;
            userToBeUpdated.Password = user.Password;
            await _dataContext.SaveChangesAsync();
            return userToBeUpdated;
        }

        public async Task<bool> UserExists(string username)
        {

            return await _dataContext.User.FirstOrDefaultAsync(x => x.Name == username) != null;
        }
    }
}
