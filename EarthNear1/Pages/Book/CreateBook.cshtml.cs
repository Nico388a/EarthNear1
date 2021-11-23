using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EarthNear1.Interfaces;
using EarthNear1.Models;
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

        private IBookingService bookingService;
        public SelectList userList;

        public CreateBookModel(IBookingService bService, ADO_UserService uService)
        {
            Booking = new Booking();
            bookingService = bService;
            Task<List<User>> users = uService.GetAllUsersAsync();
            userList = new SelectList(users.Result, "UserId", "Name");
        }
        public IActionResult OnGetAsync(int id)
        {
            Booking.ShiftId = id;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await bookingService.AddBookingAsync(Booking);
            return RedirectToPage("GetAllBookings");
        }
    }
}
