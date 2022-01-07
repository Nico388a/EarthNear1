using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EarthNear1.Interfaces;
using EarthNear1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EarthNear1.Pages.Types.ShiftTypes
{
    public class CreateShiftTypeModel : PageModel
    {
        [BindProperty] 
        public ShiftType ShiftType { get; set; }
        private IShiftTypeService shiftTypeService;

        public CreateShiftTypeModel(IShiftTypeService shiftTypeService)
        {
            this.shiftTypeService = shiftTypeService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(ShiftType shiftType)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await shiftTypeService.AddShiftTypeAsync(shiftType);
            return RedirectToPage("GetAllShiftTypes");
        }
    }
}
