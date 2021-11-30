using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EarthNear1.Models;

namespace EarthNear1.Interfaces
{
    public interface IShiftUserService
    {
        Task<IEnumerable<ShiftUser>> GetAllShiftUsersAsync();
        Task AddShiftUserAsync(ShiftUser shiftUser);
        Task<ShiftUser> GetShiftUserById(int id);
        Task<List<ShiftUser>> GetShiftUserByUserId(int userId);
    }
}
