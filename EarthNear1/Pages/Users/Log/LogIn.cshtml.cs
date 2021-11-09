using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EarthNear1.Models;
using EarthNear1.Interfaces;
using EarthNear1.Services;

namespace EarthNear1.Pages.Users.Log
{
    public class LogInModel : PageModel
    {
        private IUserService userService;
        private LogInService logInService;
        public string AccessDenied = "";
        [BindProperty]
        public User User { get; set; }
        public LogInModel(IUserService service, LogInService logIn)
        {
            userService = service;
            logInService = logIn;
        }
        public IActionResult OnGet()
        {
            return Page();
        }
        public IActionResult OnPost()
        {
            foreach(User user in userService.GetAllUsersAsync().Result)
            {
                if (user.Email == User.Email)
                {
                    if (user.Password == User.PasswordCheck)
                    {
                        logInService.UserLogIn(user);
                        return RedirectToPage("/Index");
                    }
                }
                AccessDenied = "Email/kodeord er ikke korrekt";
            }
            return Page();
        }
    }
}
