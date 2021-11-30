using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EarthNear1.Interfaces;
using EarthNear1.Models;
using EarthNear1.Services;
using EarthNear1.Services.ShiftTypeServices;
using EarthNear1.Services.UserServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EarthNear1.Pages.Types.ShiftUsers
{
    public class CreateShiftUsersModel : PageModel
    {
        [BindProperty]
        public ShiftUser shiftUser { get; set; }
        private IShiftUserService shiftUserService;
        private LogInService logService;
        public SelectList typesList { get; set; }
        [BindProperty]
        public User User { get; set; }
        public CreateShiftUsersModel(IShiftUserService uShiftService, ADO_ShiftTypeService sTypeService, LogInService lService)
        {
            shiftUser = new ShiftUser();
            shiftUserService = uShiftService;
            logService = lService;
            Task<List<ShiftType>> shifttypes = sTypeService.GetAllShiftTypesAsync();
            typesList = new SelectList(shifttypes.Result, "ShiftTypeId", "ShiftName");
        }
        public IActionResult OnGetAsync(int id)
        {
            User = logService.GetLoggedUser();
            shiftUser.UserId = User.UserId;
            shiftUser.ShiftTypeId = id;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            await shiftUserService.AddShiftUserAsync(shiftUser);
            return RedirectToPage("GetAllShiftUsers");
        }
    }
}
