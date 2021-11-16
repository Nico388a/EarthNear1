﻿using System;
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

        public Task<Booking> GetBookingById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Booking>> GetBookingByUserId(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
