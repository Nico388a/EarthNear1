using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EarthNear1.Services;

namespace EarthNear1.Pages.Users.Log
{
    public class LogOutModel : PageModel
    {
        private LogInService logOutService;
        public LogOutModel(LogInService logOut)
        {
            logOutService = logOut;
        }
        public IActionResult OnGet()
        {
            logOutService.UserLogOut();
            return RedirectToPage("/Index");
        }
    }
}
