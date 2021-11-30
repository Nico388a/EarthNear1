using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EarthNear1.Exceptions;
using EarthNear1.Models;
using EarthNear1.Interfaces;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace EarthNear1.Pages.Users
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public User User { get; set; }
        public string InfoText { get; set; }
        public IEnumerable<User> Users { get; private set; }
        private readonly IUserService userService;
        private IWebHostEnvironment webHostEnvironment;
        public string RndPass { get; private set; }
        [BindProperty]
        public IFormFile Photo { get; set; }
        public CreateModel(IUserService service, IWebHostEnvironment webHost)
        {
            userService = service;
            webHostEnvironment = webHost;
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
            if(Photo != null)
            {
                if (user.UserImage != null)
                {
                    string filePath = Path.Combine(webHostEnvironment.WebRootPath, "/images/Photos", user.UserImage);
                    System.IO.File.Delete(filePath);
                }
                user.UserImage = ProcessUploadedFile();
            }
            await userService.AddUserAsync(user);
            Users = await userService.GetAllUsersAsync();
            return RedirectToPage("GetAllUsers");
        }

        private string ProcessUploadedFile()
        {
            string uniqueFileName = null;
            if(Photo != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images/Photos");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using(var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    Photo.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}
