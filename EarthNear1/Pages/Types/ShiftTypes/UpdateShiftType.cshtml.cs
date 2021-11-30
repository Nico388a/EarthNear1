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
    public class UpdateShiftTypeModel : PageModel
    {
        [BindProperty] 
        public ShiftType ShiftType { get; set; }
        private IShiftTypeService ShiftTypeService { get; }

        public UpdateShiftTypeModel(IShiftTypeService shiftTypeService)
        {
            this.ShiftTypeService = shiftTypeService;
        }
        public async Task OnGetAsync(int id)
        {
            ShiftType = await ShiftTypeService.GetShiftTypeByIdAsync(id);
        }

        public async Task<IActionResult> OnPostAsync(ShiftType shiftType)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await ShiftTypeService.UpdateShiftTypeAsync(shiftType);
           return RedirectToPage("GetAllShiftTypes");
        }
    }
}
