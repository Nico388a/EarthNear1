using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EarthNear1.Interfaces;
using EarthNear1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EarthNear1.Pages.Shifts
{
    public class DeleteShiftModel : PageModel
    {
        [BindProperty]
        public Shift Shift { get; set; }

        private IShiftService shiftService;

        public DeleteShiftModel(IShiftService sService)
        {
            shiftService = sService;
        }

        public async Task OnGetAsync(int id)
        {
            Shift = await shiftService.GetShiftByIdAsync(id);
        }

        public async Task<IActionResult> OnPostAsync()
        { 
            await shiftService.DeleteShiftAsync(Shift);
            return RedirectToPage("GetAllShifts");
        }
    }
}
