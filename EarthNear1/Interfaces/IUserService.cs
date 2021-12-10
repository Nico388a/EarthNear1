using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EarthNear1.Models;

namespace EarthNear1.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<IEnumerable<User>> GetUserByNameAsync(string name);
        Task<bool> AddUserAsync(User user);
        Task DeleteUserAsync(User user);
        Task<User> GetUserFromIdAsync(int id);
        Task UpdateUserAsync(User user);

    }
}
