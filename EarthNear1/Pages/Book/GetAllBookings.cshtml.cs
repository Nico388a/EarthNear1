using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EarthNear1.Interfaces;
using EarthNear1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EarthNear1.Pages.Book
{
    public class GetAllBookingsModel : PageModel
    {
        public IEnumerable<Booking> Bookings { get; private set; }

        private IBookingService bookingService;
        private IUserService userService;
        public GetAllBookingsModel(IBookingService bService, IUserService uService)
        {
            bookingService = bService;
            userService = uService;
        }
        public async Task OnGetAsync()
        {
            Bookings = await bookingService.GetAllBookingsAsync();
        }

        public async Task OnGetBookingAsync(int id)
        {
            Bookings = await bookingService.GetBookingByUserId(id);
        }
    }
}
