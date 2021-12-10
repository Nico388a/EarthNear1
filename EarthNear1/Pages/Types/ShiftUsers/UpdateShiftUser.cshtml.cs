using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EarthNear1.Interfaces;
using EarthNear1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EarthNear1.Pages.Types.ShiftUsers
{
    public class UpdateShiftUserModel : PageModel
    {
        [BindProperty]
        public ShiftUser ShiftUser { get; set; }
        public User User { get; set; }
        public IEnumerable<ShiftType> shiftTypes { get; set; }
        public List<ShiftUser> shiftUsers { get; set; }
        private IShiftUserService sUserService;
        private IShiftTypeService sTypeService;
        private IUserService uService;
        public UpdateShiftUserModel(IShiftUserService shiftUserService, IShiftTypeService shifttypeService, IUserService userService)
        {
            ShiftUser = new ShiftUser();
            sUserService = shiftUserService;
            sTypeService = shifttypeService;
            uService = userService;
            
        }
        public async Task OnGetAsync(int id)
        {
            //ShiftUser.ShiftTypeId = id;
            User = await uService.GetUserFromIdAsync(id);
            ShiftUser.UserId = User.UserId;
            shiftTypes = await sTypeService.GetAllShiftTypesAsync();
            shiftUsers = await sUserService.GetShiftUserByUserId(User.UserId);
        }
        public async Task<IActionResult> OnPostAsync(ShiftUser shiftUser)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await sUserService.UpdateShiftUserAsync(shiftUser);
            return RedirectToPage("GetAllShiftUsers");
        }
    }
}
