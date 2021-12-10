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
            string sql = "Select * From Users";
            await using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    await command.Connection.OpenAsync();
                    SqlDataReader dataReader = await command.ExecuteReaderAsync();
                    while (await dataReader.ReadAsync())
                    {
                        User @user = new User();
                        @user.UserId = Convert.ToInt32(dataReader["UserId"]);
                        @user.Name = Convert.ToString(dataReader["Name"]);
                        @user.AfterName = Convert.ToString(dataReader["AfterName"]);
                        @user.PhoneNumber = Convert.ToString(dataReader["PhoneNumber"]);
                        @user.Email = Convert.ToString(dataReader["Email"]);
                        @user.Password = Convert.ToString(dataReader["Password"]);
                        @user.Admin = Convert.ToBoolean(dataReader["Admin"]);
                        @user.UserImage = Convert.ToString(dataReader["UserImage"]);
                        users.Add(@user);
                    }
                }
            }
            return users;
        }
        public async Task<List<User>> GetUserByNameAsync(string name)
        {
            string sql = $"Select * From Users Where Name LIKE'" + @name + "%" + "'";
            await using(SqlConnection connection = new SqlConnection(connectionString))
            {
                await using(SqlCommand command = new SqlCommand(sql, connection))
                {
                    await command.Connection.OpenAsync();
                    command.Parameters.AddWithValue("@name", name);
                    SqlDataReader dataReader = await command.ExecuteReaderAsync();
                    while (await dataReader.ReadAsync())
                    {
                        User @user = new User();
                        @user.UserId = Convert.ToInt32(dataReader["UserId"]);
                        @user.Name = Convert.ToString(dataReader["Name"]);
                        @user.AfterName = Convert.ToString(dataReader["AfterName"]);
                        @user.Email = Convert.ToString(dataReader["Email"]);
                        @user.PhoneNumber = Convert.ToString(dataReader["PhoneNumber"]);
                        @user.Password = Convert.ToString(dataReader["Password"]);
                        @user.Admin = Convert.ToBoolean(dataReader["Admin"]);
                        @user.UserImage = Convert.ToString(dataReader["UserImage"]);
                        users.Add(@user);
                    }
                }
            }
            return users;
        }
        public async Task<User> GetUserFormIdAsync(int id)
        {
            User @user = new User();
            string sql = $"Select * From Users Where UserId = @id";
            await using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await using (SqlCommand command=new SqlCommand(sql, connection))
                {
                    await command.Connection.OpenAsync();
                    command.Parameters.AddWithValue("@id", id);
                    SqlDataReader dataReader = await command.ExecuteReaderAsync();
                    if (dataReader.Read())
                    {
                        @user.UserId = Convert.ToInt32(dataReader["UserId"]);
                        @user.Name = Convert.ToString(dataReader["Name"]);
                        @user.AfterName = Convert.ToString(dataReader["AfterName"]);
                        @user.PhoneNumber = Convert.ToString(dataReader["PhoneNumber"]);
                        @user.Email = Convert.ToString(dataReader["Email"]);
                        @user.Password = Convert.ToString(dataReader["Password"]);
                        @user.Admin = Convert.ToBoolean(dataReader["Admin"]);
                        @user.UserImage = Convert.ToString(dataReader["UserImage"]);
                    }
                }
            }
            return @user;
        }

        public async Task<bool> CreateUserAsync(User user)
        {
            string sql = $"Insert Into Users(Name, AfterName, PhoneNumber, Email, Password, Admin, UserImage) " +
                $"Values(@Name, @AfterName, @PhoneNumber, @Email, @Password, @Admin, @UserImage)";
            await using(SqlConnection connection= new SqlConnection(connectionString))
            {
                await using(SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Name", user.Name);
                    command.Parameters.AddWithValue("@AfterName", user.AfterName);
                    command.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
                    command.Parameters.AddWithValue("@Email", user.Email);
                    command.Parameters.AddWithValue("@Password", user.Password);
                    command.Parameters.AddWithValue("@Admin", user.Admin);
                    command.Parameters.AddWithValue("@UserImage", user.UserImage);
                    if (UserEmailExist(user.Email))
                    {
                        throw new ExistsException("Denne email eksisterer allerede");
                    }
                    await command.Connection.OpenAsync();
                    int affectedRows = await command.ExecuteNonQueryAsync();
                    if (affectedRows == 1)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
        private bool UserEmailExist(string email)
        {
            foreach (User u in GetAllUsersAsync().Result)
            {
                if (u.Email == email)
                    return true;
            }
            return false;
        }
        public async Task<User> UpdateUserAsync(User user)
        {
            string sql = $"Update Users Set Name=@Name, AfterName=@AfterName, PhoneNumber=@PhoneNumber, Email=@Email, Password=@Password, UserImage=@UserImage Where UserId=@id";
            await using (SqlConnection connection=new SqlConnection(connectionString))
            {
                await using(SqlCommand command = new SqlCommand(sql, connection))
                {
                    await command.Connection.OpenAsync();
                    command.Parameters.AddWithValue("@id", user.UserId);
                    command.Parameters.AddWithValue("@Name", user.Name);
                    command.Parameters.AddWithValue("@AfterName", user.AfterName);
                    command.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
                    command.Parameters.AddWithValue("@Email", user.Email);
                    command.Parameters.AddWithValue("@Password", user.Password);
                    command.Parameters.AddWithValue("@UserImage", user.UserImage);
                    int affectedRows = await command.ExecuteNonQueryAsync();
                }
            }
            return user;
        }
        public async Task<User> DeleteUserAsync(User user)
        {
            string sql = $"Delete From Users Where UserId=@id";
            await using (SqlConnection connection= new SqlConnection(connectionString))
            {
                await using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    await command.Connection.OpenAsync();
                    command.Parameters.AddWithValue("@id", user.UserId);
                    int affectedRows = await command.ExecuteNonQueryAsync();
                }
            }
            return user;
        }
    }
}
