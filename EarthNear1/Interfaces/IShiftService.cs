using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EarthNear1.Models;

namespace EarthNear1.Interfaces
{
   public interface IShiftService
   {
       Task<IEnumerable<Shift>> GetAllShiftAsync();
       Task AddShiftAsync(Shift shift);
       Task<Shift> GetShiftByIdAsync(int id);
       Task DeleteShiftAsync(Shift shift);
       Task UpdateShiftAsync(Shift shift);
   }
}
