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
    public class GetAllShiftsModel : PageModel
    {
        [BindProperty (SupportsGet = true)]
        public IEnumerable<Shift> Shifts { get; set; }

        [BindProperty] 
        public Shift Shift { get; set; }

        private IShiftService shiftService;

        public GetAllShiftsModel(IShiftService sService)
        {
            shiftService = sService;
        }


        public async Task OnGetAsync()
        {
            Shifts = await shiftService.GetAllShiftAsync();
        }
    }
}
