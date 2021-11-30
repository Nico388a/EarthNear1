using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EarthNear1.Exceptions;
using EarthNear1.Models;
using EarthNear1.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace EarthNear1.Pages.Users
{
    public class UpdateModel : PageModel
    {
        [BindProperty]
        public User User { get; set; }
        IUserService userService { get; set; }
        private IWebHostEnvironment webHostEnvironment;
        public IEnumerable<User> Users { get; private set; }
        public IFormFile Photo { get; set; }
        public UpdateModel(IUserService service, IWebHostEnvironment webHost)
        {
            userService = service;
            webHostEnvironment = webHost;
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
            if (Photo != null)
            {
                if (user.UserImage != null)
                {
                    string filePath = Path.Combine(webHostEnvironment.WebRootPath, "/images/Photos", user.UserImage);
                    System.IO.File.Delete(filePath);
                }
                user.UserImage = ProcessUploadedFile();
            }
            await userService.UpdateUserAsync(user);
            Users = await userService.GetAllUsersAsync();
            return RedirectToPage("GetAllUsers");
        }
        private string ProcessUploadedFile()
        {
            string uniqueFileName = null;
            if (Photo != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images/Photos");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    Photo.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}
