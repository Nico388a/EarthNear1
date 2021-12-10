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
using Moq;
using Xunit;

namespace EarthNearXUnitTests.UserTests
{
    public class GetUserTest
    {
        //private readonly Mock<IUserService> mockService;
        //private readonly GetAllUsersModel getAllUsersModel;
        //public GetUserTest()
        //{
        //    mockService = new Mock<IUserService>();
        //    getAllUsersModel = new GetAllUsersModel(mockService.Object);
        //}
        //[Fact]
        //public async Task GetAllUsersAsyncTest()
        //{
        //    //Arrange
        //    mockService.Setup(mockservice => mockservice.GetAllUsersAsync()).ReturnsAsync(GetTestUsers);

        //    //Act
        //    var result = getAllUsersModel.OnGetAsync();
        //    IEnumerable<User> UserList = getAllUsersModel.Users;

        //    //Assert
            
        //    var veiwResult = Assert.IsType<PageResult>(result);
        //    var actuelMessages = Assert.IsType<List<User>>(UserList);
            
        //}
        //private List<User> GetTestUsers()
        //{
        //    var users = new List<User>();
        //    users.Add(new User()
        //    {
        //        UserId = 1,
        //        Name = "Test ",
        //        AfterName = "1",
        //        Email = "test1@gmail.com",
        //        PhoneNumber = "34897621",
        //        Password = "testCode",
        //    });
        //    users.Add(new User()
        //    {
        //        UserId = 2,
        //        Name = "Test ",
        //        AfterName = "2",
        //        Email = "test2@gmail.com",
        //        PhoneNumber = "59897621",
        //        Password = "testCheck",
        //    });
        //    return users;
        //}
    }
}
