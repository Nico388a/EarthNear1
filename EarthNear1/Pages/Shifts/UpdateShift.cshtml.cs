using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EarthNear1.Interfaces;
using EarthNear1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EarthNear1.Pages.Shifts
{
    public class UpdateShiftModel : PageModel
    {
        [BindProperty] 
        public Shift Shift { get; set; }

        private IShiftService shiftService;

        public SelectList ShiftNames { get; set; }

        public UpdateShiftModel(IShiftService sService, IShiftTypeService tService)
        {
            shiftService = sService;
            Task<IEnumerable<ShiftType>> shiftTypes = tService.GetAllShiftTypesAsync();
            ShiftNames = new SelectList(shiftTypes.Result, "ShiftTypeId", "ShiftName");
        }
        public async Task OnGet(int id)
        {
            Shift = await shiftService.GetShiftByIdAsync(id);
        }

        public async Task<IActionResult> OnPostAsync(Shift shift)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await shiftService.UpdateShiftAsync(shift);
            return RedirectToPage("GetAllShifts");
        }
    }
}
