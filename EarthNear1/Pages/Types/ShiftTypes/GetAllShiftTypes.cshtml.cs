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
    public class GetAllShiftTypesModel : PageModel
    {
        [BindProperty (SupportsGet = true)] 
        public IEnumerable<ShiftType> ShiftTypes { get; set; }
        
        [BindProperty] 
        public ShiftType ShiftType { get; set; }

        private IShiftTypeService shiftTypeService;
        private IShiftUserService shiftUserService;

        public GetAllShiftTypesModel(IShiftTypeService shiftTypeService, IShiftUserService shiftUserService)
        {
            this.shiftTypeService = shiftTypeService;
            this.shiftUserService = shiftUserService;
        }
        public async Task OnGetAsync()
        {
            ShiftTypes = await shiftTypeService.GetAllShiftTypesAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await shiftTypeService.DeleteShiftTypeAsync(ShiftType);
            return RedirectToPage("GetAllShiftTypes");
        }
    }
}
