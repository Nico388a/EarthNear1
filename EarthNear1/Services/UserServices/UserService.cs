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
    }
}
