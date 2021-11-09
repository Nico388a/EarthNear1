using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EarthNear1.Exceptions;
using EarthNear1.Models;
using EarthNear1.Interfaces;
using System.Text;

namespace EarthNear1.Pages.Users
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public User User { get; set; }
        public string InfoText { get; set; }
        public IEnumerable<User> Users { get; private set; }
        private readonly IUserService userService;
        public string RndPass { get; private set; }
        public CreateModel(IUserService service)
        {
            userService = service;
        }
        public async Task OnGetAsync()
        {
            InfoText = "Enter new user";
            RndPass = ChangePassword(5);
            Users = await userService.GetAllUsersAsync();
        }
        public string ChangePassword(int length)
        {
            const string valid = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder bld = new StringBuilder();
            Random rnd = new Random();
            while(0< length--)
            {
                bld.Append(valid[rnd.Next(valid.Length)]);
            }
            return bld.ToString();
        }
        public async Task<IActionResult> OnPostAsync(User user)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await userService.AddUserAsync(user);
            return RedirectToPage("GetAllUsers");
        }
    }
}
