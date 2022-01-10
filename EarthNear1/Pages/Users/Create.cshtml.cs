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
        public IEnumerable<ShiftType> shiftTypes { get; set; }
        private readonly IUserService userService;
        private IShiftTypeService ShiftTypeService;
        private IWebHostEnvironment webHostEnvironment;
        [BindProperty]
        public IFormFile Photo { get; set; }
        public CreateModel(IUserService service, IWebHostEnvironment webHost, IShiftTypeService shiftType)
        {
            userService = service;
            webHostEnvironment = webHost;
            ShiftTypeService = shiftType;
        }
        public async Task OnGetAsync()
        {
            InfoText = "Opret profil";
            shiftTypes = await ShiftTypeService.GetAllShiftTypesAsync();
            Users = await userService.GetAllUsersAsync();
        }
        public async Task<IActionResult> OnPostAsync(User user)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (Photo == null)
            {
                user.UserImage = "noimage.jpg";
            }
            try
            {
                if (Photo != null)
                {
                    if (user.UserImage != null)
                    {
                        string filePath = Path.Combine(webHostEnvironment.WebRootPath, "/images/Photos",
                            user.UserImage);
                        System.IO.File.Delete(filePath);
                    }
                    user.UserImage = ProcessUploadedFile();
                }
                await userService.AddUserAsync(user);
                Users = await userService.GetAllUsersAsync();
            }
            catch (ExistsException e)
            {
                InfoText = $"Noget gik gik galt! {e.Message}";
                return Page();
            }
            catch (Exception ex)
            {
                InfoText = $"Noget gik gik galt! {ex.Message}";
                return Page();
            }
            return RedirectToPage("./Log/LogIn");
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
