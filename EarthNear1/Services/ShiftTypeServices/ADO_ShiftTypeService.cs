using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using EarthNear1.Models;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.Extensions.Configuration;

namespace EarthNear1.Services.ShiftTypeServices
{
    public class ADO_ShiftTypeService
    {
        private List<ShiftType> shiftTypes;
        private string connectionString;
        public IConfiguration Configuration { get; }

        public ADO_ShiftTypeService(IConfiguration configuration)
        {
            Configuration = configuration;
            connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            shiftTypes = new List<ShiftType>();
        }

        public async Task<List<ShiftType>> GetAllShiftTypesAsync()
        {
            string sql = $"Select * From ShiftType";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand(sql, connection);
                using (SqlDataReader dataReader = await command.ExecuteReaderAsync())
                {
                    while (await dataReader.ReadAsync())
                    {
                        ShiftType shiftType = new ShiftType();
                        shiftType.ShiftTypeId = Convert.ToInt32(dataReader["ShiftTypeId"]);
                        shiftType.ShiftName = Convert.ToString(dataReader["ShiftName"]);
                        shiftTypes.Add(shiftType);
                    }
                }
            }
            return shiftTypes;
        }

        public async Task<ShiftType> GetShiftTypeById(int id)
        {
            ShiftType shiftType = new ShiftType();
            string sql = "Select * From ShiftType Where ShiftTypeId = @Id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    SqlDataReader dataReader = await command.ExecuteReaderAsync();
                    while (dataReader.Read())
                    {
                        shiftType.ShiftTypeId = Convert.ToInt32(dataReader["ShiftTypeId"]);
                        shiftType.ShiftName = Convert.ToString(dataReader["ShiftName"]);
                    }
                }
            }
            return shiftType;
        }

        public async Task CreateShiftTypeAsync(ShiftType shiftType)
        {
            string sql = "Insert Into ShiftType(ShiftName) Values(@ShiftName)";
            await using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    await command.Connection.OpenAsync();
                    command.Parameters.AddWithValue("@ShiftName", shiftType.ShiftName);
                    int affectedRows = await command.ExecuteNonQueryAsync();
                }
            }
        }

    }
}
