using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EarthNear1.Models;

namespace EarthNear1.Interfaces
{
    public interface IShiftTypeService
    {
        Task<IEnumerable<ShiftType>> GetAllShiftTypesAsync();
        Task AddShiftTypeAsync(ShiftType shift);
        Task<ShiftType> GetShiftTypeByIdAsync(int id);
        Task DeleteShiftTypeAsync(ShiftType shiftType);
        Task UpdateShiftTypeAsync(ShiftType shiftType);
    }
}
