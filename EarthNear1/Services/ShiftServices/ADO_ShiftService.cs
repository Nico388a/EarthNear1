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
                        shift.DateFrom = Convert.ToDateTime(dataReader["DateFrom"]);
                        shift.DateTo = Convert.ToDateTime(dataReader["DateTo"]);
                        shift.Description = Convert.ToString(dataReader["Description"]);
                        shifts.Add(@shift);
                    }
                }
            }

            return shifts;
        }
    }
}
