using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using EarthNear1.Interfaces;
using EarthNear1.Models;
using Microsoft.Extensions.Configuration;

namespace EarthNear1.Services.BookingServices
{
    public class ADO_BookingService
    {
        private List<Booking> bookings;
        private string connectionString;
        public IConfiguration Configuration { get; }

        public ADO_BookingService(IConfiguration configuration)
        {
            Configuration = configuration;
            connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            bookings = new List<Booking>();
        }

        public async Task<List<Booking>> GetAllBookingsAsync()
        {
            string sql = $"Select * From Booking";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand(sql, connection);
                using (SqlDataReader dataReader = await command.ExecuteReaderAsync())
                {
                    while (await dataReader.ReadAsync())
                    {
                        Booking @booking = new Booking();
                        @booking.BookingId = Convert.ToInt32(dataReader["BookingId"]);
                        @booking.UserId = Convert.ToInt32(dataReader["UserId"]);
                        @booking.ShiftId = Convert.ToInt32(dataReader["ShiftId"]);
                    }
                }
            }
            return bookings;
        }

        public async Task AddBookingAsync(Booking booking)
        {
            string sql = $"Insert Into Booking(UserId, ShiftId) Values(@UserId, @ShiftId)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@UserId", booking.UserId);
                    command.Parameters.AddWithValue("@ShiftId", booking.ShiftId);
                    int affectedRows = await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
