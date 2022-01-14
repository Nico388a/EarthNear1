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
    public class DeleteBookingModel : PageModel
    {
        [BindProperty] 
        public Booking Booking { get; set; }

        private IBookingService bookingService;

        public DeleteBookingModel(IBookingService bService)
        {
            bookingService = bService;
        }
        public async Task OnGetAsync(int id)
        {
           Booking = await bookingService.GetBookingByIdAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            await bookingService.DeleteBookingAsync(Booking);
            return RedirectToPage("/Shifts/GetAllShifts");
        }
    }
}
