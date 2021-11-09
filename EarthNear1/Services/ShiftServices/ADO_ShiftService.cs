using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using EarthNear1.Models;
using Microsoft.Extensions.Configuration;

namespace EarthNear1.Services.ShiftServices
{
    public class ADO_ShiftService
    {
        private List<Shift> shifts;
        private string connectionString;
        public IConfiguration Configuration { get; }

        public ADO_ShiftService(IConfiguration configuration)
        {
            Configuration = configuration;
            connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            shifts = new List<Shift>();
        }

        public async Task<List<Shift>> GetAllShiftsAsync()
        {
            string sql = $"Select * From Shifts";
            await using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand(sql, connection);
                using (SqlDataReader dataReader = await command.ExecuteReaderAsync())
                {
                    while (await dataReader.ReadAsync())
                    {
                        Shift @shift = new Shift();
                        shift.ShiftId = Convert.ToInt32(dataReader["ShiftId"]);
                        shift.TimeFrom = (TimeSpan)dataReader["TimeFrom"];
                        shift.TimeTo = (TimeSpan)dataReader["TimeTo"];
                        shift.Date = Convert.ToDateTime(dataReader["Date"]);
                        shift.ShiftType = Convert.ToString(dataReader["ShiftType"]);
                        shift.ShiftStatus = Convert.ToString(dataReader["ShiftStatus"]);
                        shifts.Add(@shift);
                    }
                }
            }
            return shifts;
        }

        public async Task<Shift> GetShiftByIdAsync(int id)
        {
            Shift shift = new Shift();
            string sql = $"Select * From Shifts Where ShiftId=@Id";
            await using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    SqlDataReader dataReader = await command.ExecuteReaderAsync();
                    while (dataReader.Read())
                    {
                        shift.ShiftId = Convert.ToInt32(dataReader["ShiftId"]);
                        shift.Date = Convert.ToDateTime(dataReader["Date"]);
                        shift.TimeFrom = (TimeSpan)dataReader["TimeFrom"];
                        shift.TimeTo = (TimeSpan)dataReader["TimeTo"];
                        shift.ShiftType = Convert.ToString(dataReader["ShiftType"]);
                        shift.ShiftStatus = Convert.ToString(dataReader["ShiftStatus"]);
                    }
                }
            }
            return shift;
        }

        public async Task CreateShiftAsync(Shift shift)
        {
            string sql = $"Insert Into Shifts(Date, TimeFrom, TimeTo, ShiftType, ShiftStatus) Values(@Date, @TimeFrom, @TimeTo, @ShiftType, @ShiftStatus)";
            await using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await using (SqlCommand command = new SqlCommand(sql, connection))
                { 
                    await command.Connection.OpenAsync();
                    command.Parameters.AddWithValue("@Date", shift.Date);
                    command.Parameters.AddWithValue("@TimeFrom", shift.TimeFrom);
                    command.Parameters.AddWithValue("@TimeTo", shift.TimeTo);
                    command.Parameters.AddWithValue("@ShiftType", shift.ShiftType);
                    command.Parameters.AddWithValue("@ShiftStatus", shift.ShiftStatus);
                    int affectedRows = await command.ExecuteNonQueryAsync();
                }
            }

        }

        public async Task DeleteShiftAsync(Shift shift)
        {
            string sql = $"Delete From Shifts Where ShiftId = @Id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", shift.ShiftId);
                    int affectedRows = await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task UpdateShiftAsync(Shift shift)
        {
            string sql = $"Update Shifts Set Date=@Date, TimeFrom=@TimeFrom, TimeTo=@TimeTo, ShiftType=@ShiftType, ShiftStatus=@ShiftStatus Where ShiftId = @Id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", shift.Date);
                    command.Parameters.AddWithValue("@Date", shift.Date);
                    command.Parameters.AddWithValue("@TimeFrom", shift.TimeFrom);
                    command.Parameters.AddWithValue("@TimeTo", shift.TimeTo);
                    command.Parameters.AddWithValue("@ShiftType", shift.ShiftType);
                    command.Parameters.AddWithValue("@ShiftStatus", shift.ShiftStatus);
                    int affectedRows = await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
