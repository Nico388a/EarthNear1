using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EarthNear1.Interfaces;
using EarthNear1.Models;
using EarthNear1.Services;
using EarthNear1.Services.UserServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EarthNear1.Pages.Book
{
    public class CreateBookModel : PageModel
    {
        [BindProperty] 
        public Booking Booking { get; set; }

        public User User1 { get; set; }
        private IBookingService bookingService;
        private LogInService logIn;
        //public SelectList userList;

        public CreateBookModel(IBookingService bService, IUserService uService, LogInService log)
        {
            Booking = new Booking();
            bookingService = bService;
            Task<IEnumerable<User>> users = uService.GetAllUsersAsync();
            logIn = log;
            //userList = new SelectList(users.Result, "UserId", "Name");
        }
        public IActionResult OnGetAsync(int id)
        {
            Booking.ShiftId = id;
            User1 = logIn.GetLoggedUser();
            Booking.UserId = User1.UserId;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await bookingService.AddBookingAsync(Booking);
            return RedirectToPage("/Shifts/GetAllShifts");
        }
    }
}
