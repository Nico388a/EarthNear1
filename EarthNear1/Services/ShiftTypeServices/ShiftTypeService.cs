using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using EarthNear1.Interfaces;
using EarthNear1.Models;
using Microsoft.Extensions.Configuration;

namespace EarthNear1.Services.ShiftTypeServices
{
    public class ShiftTypeService : IShiftTypeService
    {
        private ADO_ShiftTypeService shiftTypeService { get; set; }

        public ShiftTypeService(ADO_ShiftTypeService sService)
        {
            shiftTypeService = sService;
        }
        
        public async Task AddShiftTypeAsync(ShiftType shiftType)
        {
            await shiftTypeService.CreateShiftTypeAsync(shiftType);
        }

        public async Task DeleteShiftTypeAsync(ShiftType shiftType)
        {
            await shiftTypeService.DeleteShiftTypeAsync(shiftType);
        }

        public async Task<IEnumerable<ShiftType>> GetAllShiftTypesAsync()
        {
            return await shiftTypeService.GetAllShiftTypesAsync();
        }

        public async Task<ShiftType> GetShiftTypeByIdAsync(int id)
        {
            return await shiftTypeService.GetShiftTypeById(id);
        }

        public async Task UpdateShiftTypeAsync(ShiftType shiftType)
        {
            await shiftTypeService.UpdateShiftypeAsync(shiftType);
        }
    }
}
