using Microsoft.Extensions.Configuration;
using EarthNear1.Exceptions;
using EarthNear1.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EarthNear1.Services.UserServices
{
    public class ADO_UserService
    {
        private List<User> users;
        private string connectionString;
        public IConfiguration Configuration { get; }
        public ADO_UserService(IConfiguration configuration)
        {
            Configuration = configuration;
            connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            users = new List<User>();
        }
        public async Task<List<User>> GetAllUsersAsync()
        {
            string sql = "Select * From User";
            await using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    await command.Connection.OpenAsync();
                    SqlDataReader dataReader = await command.ExecuteReaderAsync();
                    while (await dataReader.ReadAsync())
                    {
                        User @user = new User();
                        user.UserId = Convert.ToInt32(dataReader["UserId"]);
                        user.Name = Convert.ToString(dataReader["Name"]);
                        user.AfterName = Convert.ToString(dataReader["AfterName"]);
                        user.PhoneNumber = Convert.ToString(dataReader["PhoneNumber"]);
                        user.Email = Convert.ToString(dataReader["Email"]);
                        user.Password = Convert.ToString(dataReader["Password"]);
                    }
                }
            }
            return users;
        }
    }
}
