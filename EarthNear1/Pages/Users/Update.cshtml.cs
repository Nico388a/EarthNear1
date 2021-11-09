using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EarthNear1.Exceptions;
using EarthNear1.Models;
using EarthNear1.Interfaces;

namespace EarthNear1.Pages.Users
{
    public class UpdateModel : PageModel
    {
        [BindProperty]
        public User User { get; set; }
        IUserService userService { get; set; }
        public IEnumerable<User> Users { get; private set; }
        public UpdateModel(IUserService service)
        {
            userService = service;
        }
        public async Task OnGetAsync(int id)
        {
            User = await userService.GetUserFromIdAsync(id);
            Users = await userService.GetAllUsersAsync();
        }
        public async Task <IActionResult> OnPostAsync(User user)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await userService.UpdateUserAsync(user);
            Users = await userService.GetAllUsersAsync();
            return RedirectToPage("GetAllUsers");
        }
    }
}
