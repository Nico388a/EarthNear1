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
        private IShiftUserService sUserService;
        private IShiftTypeService sTypeService;
        private LogInService logService;
        public SelectList typesList { get; set; }
        public IEnumerable<ShiftType> shifttypes { get; set; } 
        [BindProperty]
        public User User { get; set; }
        [BindProperty]
        public List<int> AreChecked { get; set; }
        public CreateShiftUsersModel(IShiftUserService shiftuserService, IShiftTypeService shifttypeService, LogInService lService)
        {
            shiftUser = new ShiftUser();
            sUserService = shiftuserService;
            sTypeService = shifttypeService;
            logService = lService;
            shifttypes = sTypeService.GetAllShiftTypesAsync().Result;
            //typesList = new SelectList(shifttypes.Result, "ShiftTypeId", "ShiftName");
        }
        public IActionResult OnGetAsync(int id)
        {
            User = logService.GetLoggedUser();
            shiftUser.UserId = User.UserId;
            shiftUser.ShiftTypeId = id;
            return Page();
        }
        private readonly List<String> _users;
        public List<string> Users => _users;
        public async Task<IActionResult> OnPostAsync()
        {
            
            await sUserService.AddShiftUserAsync(shiftUser);
            return RedirectToPage("GetAllShiftUsers");
        }
    }
}
