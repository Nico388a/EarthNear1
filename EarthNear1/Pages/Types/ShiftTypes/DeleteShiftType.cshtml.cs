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
    public class DeleteShiftTypeModel : PageModel
    {
        [BindProperty] 
        public ShiftType ShiftType { get; set; }

        private IShiftTypeService shiftTypeService;

        public DeleteShiftTypeModel(IShiftTypeService shiftTypeService)
        {
            this.shiftTypeService = shiftTypeService;
        }
        public async Task OnGetAsync(int id)
        {
            ShiftType = await shiftTypeService.GetShiftTypeByIdAsync(id);
        }

        public async Task<IActionResult> OnPostAsync(ShiftType shiftType)
        {
            await shiftTypeService.DeleteShiftTypeAsync(shiftType);
            return RedirectToPage("GetAllShiftTypes");
        }
    }
}
