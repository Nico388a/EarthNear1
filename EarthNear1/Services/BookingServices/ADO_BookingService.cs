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
                        bookings.Add(booking);
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

        public async Task<Booking> GetBookingByIdAsync(int id)
        {
            Booking booking = new Booking();
            string sql = $"Select * From Booking Where BookingId = @Id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
               await connection.OpenAsync();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    SqlDataReader dataReader = await command.ExecuteReaderAsync();
                    while (dataReader.Read())
                    {
                        booking.BookingId = Convert.ToInt32(dataReader["BookingId"]);
                        booking.ShiftId = Convert.ToInt32(dataReader["ShiftId"]);
                        booking.UserId = Convert.ToInt32(dataReader["UserId"]);
                    }
                }
            }
            return booking;
        }

        public async Task<List<Booking>> GetBookingByUserIdAsync(int id)
        {
            string sql = $"Select * From Booking Where UserId = @Id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Id", id);
                using (SqlDataReader dataReader = await command.ExecuteReaderAsync())
                {
                    while (dataReader.Read())
                    {
                        Booking @booking = new Booking();
                        @booking.BookingId = Convert.ToInt32(dataReader["BookingId"]);
                        @booking.UserId = Convert.ToInt32(dataReader["UserId"]);
                        @booking.ShiftId = Convert.ToInt32(dataReader["ShiftId"]);
                        bookings.Add(@booking);
                    }
                }
            }
            return bookings;
        }
        public async Task<List<Booking>> GetBookingByShiftIdAsync(int id)
        {
            List<Booking> bookingList = new List<Booking>();
            string sql = $"Select * From Booking Where ShiftId = @Id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Id", id);
                using (SqlDataReader dataReader = await command.ExecuteReaderAsync())
                {
                    while (dataReader.Read())
                    {
                        Booking @booking = new Booking();
                        @booking.BookingId = Convert.ToInt32(dataReader["BookingId"]);
                        @booking.UserId = Convert.ToInt32(dataReader["UserId"]);
                        @booking.ShiftId = Convert.ToInt32(dataReader["ShiftId"]);
                        bookingList.Add(@booking);
                    }
                }
            }
            return bookingList;
        }
        public async Task DeleteBookingAsync(Booking booking)
        {
            string sql = $"Delete From Booking Where BookingId = @Id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
               await connection.OpenAsync();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", booking.BookingId);
                    int affectedRow = await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
