using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EarthNear1.Models;
using EarthNear1.Interfaces;

namespace EarthNear1.Pages.Users
{
    public class GetAllUsersModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string FilterCriteria { get; set; }
        public IEnumerable<User> Users { get; private set; }
        public List<ShiftType> shiftUsers { get; set; }
        private IUserService userService { get; set; }
        private IShiftUserService shiftUserService;
        public GetAllUsersModel(IUserService service, IShiftUserService shiftUser)
        {
            userService = service;
            shiftUserService = shiftUser;
        }
        public async Task OnGetAsync(int id)
        {
            if (!String.IsNullOrEmpty(FilterCriteria))
            {
                Users = await userService.GetUserByNameAsync(FilterCriteria);
            }
            else
                Users = await userService.GetAllUsersAsync();
        }
    }
}
