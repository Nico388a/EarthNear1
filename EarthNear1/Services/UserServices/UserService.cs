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

        public async Task AddUserAsync(User user)
        {
            await userService.CreateUserAsync(user);
        }

        public Task DeleteUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserFromIdAsync(int id)
        {
            return await userService.GetUserFormIdAsync(id);
        }

        public Task UpdateUserAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
