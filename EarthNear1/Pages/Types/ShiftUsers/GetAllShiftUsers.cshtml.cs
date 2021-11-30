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
    public class GetAllShiftUsersModel : PageModel
    {
        public IEnumerable<ShiftUser> ShiftUsers { get; private set; }
        public IEnumerable<User> Users { get; private set; }
        [BindProperty]
        public ShiftType ShiftType1 { get; set; }
        public User User1 { get; set; }
        private IShiftUserService shiftUserService;
        private IShiftTypeService shiftTypeService;
        private IUserService userService;
        public GetAllShiftUsersModel(IShiftUserService sUserService, IShiftTypeService sTypeService, IUserService uService)
        {
            shiftUserService = sUserService;
            shiftTypeService = sTypeService;
            userService = uService;
            //User1.UserId = ShiftType1.ShiftTypeId;
        }
        public async Task OnGetAsync()
        {
            Users = await userService.GetAllUsersAsync();
            //ShiftType1 = await shiftTypeService.GetShiftTypeByIdAsync(ShiftType1.ShiftTypeId);
            ShiftUsers = await shiftUserService.GetAllShiftUsersAsync();
        }
    }
}
