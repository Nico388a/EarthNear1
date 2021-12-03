using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EarthNear1.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int UserId { get; set; }
        public int ShiftId { get; set; }
    }
}
