using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using EarthNear1.Models;
using Microsoft.Extensions.Configuration;

namespace EarthNear1.Services.ShiftUserServices
{
    public class ADO_ShiftUserService
    {
        private List<ShiftUser> shiftUsers;
        private string connectionString; 
        public IConfiguration Configuration { get; }

        public ADO_ShiftUserService(IConfiguration configuration)
        {
            Configuration = configuration;
            connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            shiftUsers = new List<ShiftUser>();
        }

        public async Task<List<ShiftUser>> GetAllShiftUsers()
        {
            string sql = "Select * From Shift";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
               await connection.OpenAsync();
               SqlCommand command = new SqlCommand(sql, connection);
               using (SqlDataReader dataReader = await command.ExecuteReaderAsync())
               {
                   while (await dataReader.ReadAsync())
                   {
                       ShiftUser shiftUser = new ShiftUser();
                       shiftUser.ShiftUserId = Convert.ToInt32(dataReader["ShiftUserId"]);
                       shiftUser.ShiftTypeId = Convert.ToInt32(dataReader["ShiftTypeId"]);
                       shiftUser.UserId = Convert.ToInt32(dataReader["UserId"]);
                       shiftUser.ShiftId = Convert.ToInt32(dataReader["ShiftId"]);
                       shiftUsers.Add(shiftUser);
                   }
               }
            }
            return shiftUsers;
        }

        public async Task CreateShiftUser(ShiftUser shiftUser)
        {
            string sql = "Insert Into ShiftUser(ShiftTypeId, UserId, ShiftId) Values(@ShiftTypeId, @UserId, @ShiftId)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@ShiftTypeId", shiftUser.ShiftTypeId);
                    command.Parameters.AddWithValue("@UserId", shiftUser.UserId);
                    command.Parameters.AddWithValue("@ShiftId", shiftUser.ShiftId);
                    int affectedRow = await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
