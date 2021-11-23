using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using EarthNear1.Interfaces;
using EarthNear1.Models;
using Microsoft.Extensions.Configuration;

namespace EarthNear1.Services.ShiftUserServices
{
    public class ShiftUserService : IShiftUserService
    {
        private ADO_ShiftUserService shiftUserService { get; set; }

        public ShiftUserService(ADO_ShiftUserService service)
        {
            shiftUserService = service;
        }
        public async Task AddShiftUserAsync(ShiftUser shiftUser)
        {
            await shiftUserService.CreateShiftUser(shiftUser);
        }

        public async Task<IEnumerable<ShiftUser>> GetAllShiftUsersAsync()
        {
            return await shiftUserService.GetAllShiftUsers();
        }

        public Task<ShiftUser> GetShiftUserById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ShiftUser>> GetShiftUserByUserId(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
