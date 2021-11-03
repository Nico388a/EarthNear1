using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EarthNear1.Interfaces;
using EarthNear1.Models;
using EarthNear1.Pages.Users;
using EarthNear1.Services.UserServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.Configuration;
using Moq;

namespace EarthNearXUnitTests.UserTests
{
    [TestClass()]
    public class CreateUserTest
    {
        private UserService US;
        [TestMethod()]
        public void CreateUserTest1()
        {
            // Arrange 
            User newUser = new User()
            {
                Name = "David",
                AfterName = "Twirl",
                Email = "Test@gmail.com",
                Password = "dude",
                PhoneNumber = "34452218"
            };
            bool result = false;
            US.DeleteUserAsync(newUser);

            // Act
            //if(US.AddUserAsync(newUser))
            //{
            //    result = true;
            //}

            // Assert
            Assert.AreEqual(true, result);
        }
    }
}
