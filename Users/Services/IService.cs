using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Users.Models;

namespace Users.Services
{
    public interface IService
    {
        Task<User> CreateAsync(User user);
        Task<User> GetByIdAsync(int id);
        Task<User> UpdateAsync(int id, User user);
        Task<bool> DeleteAsync(int id);
        Task<List<User>> GetAllAsync();
    }
}
