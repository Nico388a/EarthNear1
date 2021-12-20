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
    public class ProfileModel : PageModel
    {
        private IUserService userService;
        [BindProperty]
        public User User { get; set; }
        public ProfileModel(IUserService service)
        {
            userService = service;
        }
        public async Task<IActionResult> OnGetAsync (int? id)
        {
            if (id == null)
                return NotFound();

            User = await userService.GetUserFromIdAsync((int)id);

            if (User == null)
                return NotFound();

            return Page();
        }
        public IActionResult OnPostUpdateUser(int id)
        {
            return RedirectToPage("/Users/Update", new { id = id });
        }
        public IActionResult OnPostDeleteUser(int id)
        {
            return RedirectToPage("/Users/Delete", new { id = id });
        }
        public IActionResult OnPostCreateShiftUser(int id)
        {
            return RedirectToPage("/Types/ShiftUsers/CreateShiftUsers", new { id = id });
        }
    }
}
