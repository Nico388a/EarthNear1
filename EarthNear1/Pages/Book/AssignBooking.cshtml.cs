using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EarthNear1.Interfaces;
using EarthNear1.Models;
using EarthNear1.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EarthNear1.Pages.Book
{
    public class AssignBookingModel : PageModel
    {
        [BindProperty]
        public Booking Booking { get; set; }
        [BindProperty]
        public IEnumerable<Shift> Shifts { get; set; }
        [BindProperty]
        public Shift Shift { get; set; }
        public User User1 { get; set; }
        private IShiftService shiftService;
        private IBookingService bookingService;
        public SelectList userList;
        public AssignBookingModel(IBookingService bService, IUserService uService, IShiftService shiftServ)
        {
            Booking = new Booking();
            User1 = new User();
            bookingService = bService;
            shiftService = shiftServ;
            Task<IEnumerable<User>> users = uService.GetAllUsersAsync();
            Shifts = shiftService.GetAllShiftAsync().Result;
            userList = new SelectList(users.Result, "UserId", "Name");
        }
        public IActionResult OnGetAsync(int id)
        {
            Booking.ShiftId = id;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Booking.ShiftId = id;
            await bookingService.AddBookingAsync(Booking);
            return RedirectToPage("GetAllBookings");
        }
    }
}
