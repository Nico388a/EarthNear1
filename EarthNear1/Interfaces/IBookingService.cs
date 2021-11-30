using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EarthNear1.Models;

namespace EarthNear1.Interfaces
{
   public interface IBookingService
   {
       Task<IEnumerable<Booking>> GetAllBookingsAsync();
       Task AddBookingAsync(Booking booking);
       Task<Booking> GetBookingByIdAsync(int id);
       Task<List<Booking>> GetBookingByUserId(int userId);
       Task DeleteBookingAsync(Booking booking);
        //Task<List<Shift>> GetBookingByBoatId(int boatId);

    }
}
