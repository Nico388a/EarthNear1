using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EarthNear1.Interfaces;
using EarthNear1.Models;

namespace EarthNear1.Services.BookingServices
{
    public class BookingService: IBookingService
    {
        private ADO_BookingService bookingService { get; }

        public BookingService(ADO_BookingService bservice)
        {
            bookingService = bservice;
        }
        public async Task<IEnumerable<Booking>> GetAllBookingsAsync()
        {
            return await bookingService.GetAllBookingsAsync();
        }

        public async Task AddBookingAsync(Booking booking)
        {
            await bookingService.AddBookingAsync(booking);
        }

        public async Task<Booking> GetBookingByIdAsync(int id)
        {
            return await bookingService.GetBookingByIdAsync(id);
        }

        public async Task<List<Booking>> GetBookingByUserId(int userId)
        {
            return await bookingService.GetBookingByUserIdAsync(userId);
        }

        public async Task<List<Booking>> GetBookingByShiftId(int shiftId)
        {
            return await bookingService.GetBookingByShiftIdAsync(shiftId);
        }

        public async Task DeleteBookingAsync(Booking booking)
        {
            await bookingService.DeleteBookingAsync(booking);
        }
    }
}
