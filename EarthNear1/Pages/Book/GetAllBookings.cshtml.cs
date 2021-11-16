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
        [BindProperty] public User User1 { get; set; }
        private IBookingService bookingService;

        public GetAllBookingsModel(IBookingService bService)
        {
            bookingService = bService;
        }
        public async Task OnGetAsync()
        {
            Bookings = await bookingService.GetAllBookingsAsync();
        }

    }
}
