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
    public class CreateShiftModel : PageModel
    {
        [BindProperty] 
        public Shift Shift { get; set; }

        private IShiftService shiftService;
        public CreateShiftModel(IShiftService sService)
        {
            shiftService = sService;
        }
        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Shift shift)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await shiftService.AddShiftAsync(shift);
            return RedirectToPage("GetAllShifts");
        }
    }
}
