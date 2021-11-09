using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using EarthNear1.Interfaces;
using EarthNear1.Models;
using Microsoft.Extensions.Configuration;

namespace EarthNear1.Services.ShiftServices
{
    public class ShiftService: IShiftService
    {
        private ADO_ShiftService shiftService { get; set; }

        public ShiftService(ADO_ShiftService service)
        {
            shiftService = service;
        }

        public async Task<IEnumerable<Shift>> GetAllShiftAsync()
        {
            return await shiftService.GetAllShiftsAsync();
        }

        public async Task<Shift> GetShiftById(int id)
        {
            return await shiftService.GetShiftByIdAsync(id);
        }

        public async Task AddShiftAsync(Shift shift)
        {
          await shiftService.CreateShiftAsync(shift);
        }

        public Task<Shift> GetShiftByIdAsync(int id)
        {
            return shiftService.GetShiftByIdAsync(id);
        }

        public async Task DeleteShiftAsync(Shift shift)
        {
            await shiftService.DeleteShiftAsync(shift);
        }

        public async Task UpdateShiftAsync(Shift shift)
        {
            await shiftService.UpdateShiftAsync(shift);
        }
    }
}
