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
        private IUserService userService { get; set; }
        public GetAllUsersModel(IUserService service)
        {
            userService = service;
        }
        public async Task OnGetAsync()
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
