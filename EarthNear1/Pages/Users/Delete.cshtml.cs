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
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public User User { get; set; }
        private readonly IUserService userService;
        public DeleteModel(IUserService service)
        {
            userService = service;
        }
        public async Task OnGetAsync(int id)
        {
            User = await userService.GetUserFromIdAsync(id);
        }
        public async Task<IActionResult> OnPostAsync()
        {
            await userService.DeleteUserAsync(User);
            return RedirectToPage("Log/LogOut");
        }
    }
}
