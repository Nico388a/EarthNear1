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
        private IShiftUserService shiftUserService;
        private IUserService userService;
        public GetAllShiftUsersModel(IShiftUserService sUserService, IUserService uService)
        {
            shiftUserService = sUserService;
            userService = uService;
        }
        public async Task OnGetAsync()
        {
            Users = await userService.GetAllUsersAsync();
            ShiftUsers = await shiftUserService.GetAllShiftUsersAsync();
        }
    }
}
