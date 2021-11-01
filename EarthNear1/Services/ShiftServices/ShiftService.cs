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

        public async Task AddShiftAsync(Shift shift)
        {
          await shiftService.CreateShiftAsync(shift);
        }

        public Task<Shift> GetShiftByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteShiftAsync(Shift shift)
        {
            throw new NotImplementedException();
        }

        public Task UpdateShiftAsync(Shift shift)
        {
            throw new NotImplementedException();
        }
    }
}
