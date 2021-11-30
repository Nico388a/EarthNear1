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

        public async Task<ShiftUser> GetShiftUserById(int id)
        {
            return await shiftUserService.GetShiftUserById(id);
        }

        public async Task<List<ShiftUser>> GetShiftUserByUserId(int userId)
        {
            return await shiftUserService.GetShiftUserByUserId(userId);
        }

        public async Task<List<ShiftType>> GetUserTypes(int id)
        {
            return await shiftUserService.GetUserTypes(id);
        }
    }
}
