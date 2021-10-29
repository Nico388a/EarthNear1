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
        public string FilterCriteria { get; set; }
        public IEnumerable<User> Users { get; private set; }
        private IUserService userService { get; set; }
        public GetAllUsersModel(IUserService service)
        {
            userService = service;
        }
        public async Task OnGetAsync()
        {
            Users = await userService.GetAllUsersAsync();
        }
    }
}
