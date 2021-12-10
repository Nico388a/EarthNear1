using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using EarthNear1.Interfaces;
using EarthNear1.Models;
using Microsoft.Extensions.Configuration;

namespace EarthNear1.Services.ShiftUserServices
{
    public class ADO_ShiftUserService
    {
        private List<ShiftUser> shiftUsers;
        private string connectionString;
        public IConfiguration Configuration { get; }
        private IShiftTypeService shiftTypeService;

        public ADO_ShiftUserService(IConfiguration configuration, IShiftTypeService shiftType)
        {
            Configuration = configuration;
            shiftTypeService = shiftType;
            connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            shiftUsers = new List<ShiftUser>();
        }

        public async Task<List<ShiftUser>> GetAllShiftUsers()
        {
            string sql = "Select * From ShiftUser";
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
                        shiftUsers.Add(shiftUser);
                    }
                }
            }
            return shiftUsers;
        }
        public async Task<ShiftUser> GetShiftUserById(int id)
        {
            ShiftUser @shiftUser = new ShiftUser();
            string sql = $"Select * From ShiftUser Where ShiftUserId = @id";
            await using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    await command.Connection.OpenAsync();
                    command.Parameters.AddWithValue("@id", id);
                    SqlDataReader dataReader = await command.ExecuteReaderAsync();
                    if (dataReader.Read())
                    {
                        shiftUser.ShiftUserId = Convert.ToInt32(dataReader["ShiftUserId"]);
                        shiftUser.UserId = Convert.ToInt32(dataReader["UserId"]);
                        shiftUser.ShiftTypeId = Convert.ToInt32(dataReader["ShiftTypeId"]);
                    }
                }
            }
            return shiftUser;
        }
        public async Task<List<ShiftUser>> GetShiftUserByUserId(int id)
        {
            List<ShiftUser> shiftUsers = new List<ShiftUser>();
            string sql = "Select * From ShiftUser Where UserId=@id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    await command.Connection.OpenAsync();
                    SqlDataReader dataReader = await command.ExecuteReaderAsync();
                    while (dataReader.Read())
                    {
                        ShiftUser @shiftUser = new ShiftUser();
                        shiftUser.ShiftUserId = Convert.ToInt32(dataReader["ShiftUserId"]);
                        shiftUser.UserId = Convert.ToInt32(dataReader["UserId"]);
                        shiftUser.ShiftTypeId = Convert.ToInt32(dataReader["ShiftTypeId"]);
                        shiftUsers.Add(shiftUser);
                    }
                }
            }
            return shiftUsers;
        }
        public async Task CreateShiftUser(ShiftUser shiftUser)
        {
            string sql = "Insert Into ShiftUser(ShiftTypeId, UserId) Values(@ShiftTypeId, @UserId)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@ShiftTypeId", shiftUser.ShiftTypeId);
                    command.Parameters.AddWithValue("@UserId", shiftUser.UserId);
                    int affectedRow = await command.ExecuteNonQueryAsync();
                }
            }
        }
        public async Task UpdateShiftUser(ShiftUser shiftUser)
        {
            string sql = "Update ShiftUser Set ShiftTypeId=@ShiftTypeId, UserId=@Userid Where ShiftUserId=@id";
            await using(SqlConnection connection = new SqlConnection(connectionString))
            {
                await using(SqlCommand command = new SqlCommand(sql, connection))
                {
                    await command.Connection.OpenAsync();
                    command.Parameters.AddWithValue("@id", shiftUser.ShiftUserId);
                    command.Parameters.AddWithValue("@ShiftTypeId", shiftUser.ShiftTypeId);
                    command.Parameters.AddWithValue("@UserId", shiftUser.UserId);
                    int affectedRows = await command.ExecuteNonQueryAsync();
                }
            }
        }
        public async Task DeleteShiftUser(ShiftUser shiftUser)
        {
            string sql = "Delete From ShiftUser Where ShiftUserId=@id";
            await using(SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using(SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", shiftUser.ShiftUserId);
                    int affectedRows = await command.ExecuteNonQueryAsync();
                }
            }
        }
        public async Task<List<ShiftType>> GetUserTypes(int id)
        {
            ShiftType st = new ShiftType();
            List<ShiftType> shiftTypes = new List<ShiftType>();
            foreach(ShiftUser su in GetShiftUserByUserId(id).Result)
            {
                st = await shiftTypeService.GetShiftTypeByIdAsync(su.ShiftTypeId);
                shiftTypes.Add(st);
            }
            return shiftTypes;
        }

    }
}
