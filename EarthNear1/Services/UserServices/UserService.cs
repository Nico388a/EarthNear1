using EarthNear1.Models;
using EarthNear1.Services.UserServices;
using EarthNear1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EarthNear1.Services.UserServices
{
    public class UserService : IUserService
    {
        private ADO_UserService userService { get; set; }
        public UserService(ADO_UserService service)
        {
            userService = service;
        }
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await userService.GetAllUsersAsync();
        }

        public async Task<bool> AddUserAsync(User user)
        {
           return await userService.CreateUserAsync(user);
        }

        public async Task DeleteUserAsync(User user)
        {
            await userService.DeleteUserAsync(user);
        }

        public async Task<User> GetUserFromIdAsync(int id)
        {
            return await userService.GetUserFormIdAsync(id);
        }

        public async Task UpdateUserAsync(User user)
        {
            await userService.UpdateUserAsync(user);
        }

        public async Task<IEnumerable<User>> GetUserByNameAsync(string name)
        {
            return await userService.GetUserByNameAsync(name);
        }
    }
}
