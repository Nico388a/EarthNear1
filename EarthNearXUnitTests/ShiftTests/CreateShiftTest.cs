using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EarthNear1.Interfaces;
using EarthNear1.Models;
using EarthNear1.Pages.Shifts;
using EarthNear1.Services.ShiftServices;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace EarthNearXUnitTests.ShiftTests
{
   public class CreateShiftTest
    {
        //[Fact]
        //public void Test1()
        //{
        //    //Arrange
        //    var mockService = new Mock<IShiftService>();
        //    mockService.Setup(service => service.AddShiftAsync(It.IsAny<Shift>())).Verifiable();
        //    var @shift = new Shift() {ShiftId = 1, Date = DateTime.Now, DateTo = DateTime.Now, Description = "Dagvagt"};
        //    var createModel = new CreateShiftModel(mockService.Object);
        //    createModel.Shift = @shift;
        //    //Act
        //    var result = createModel.OnPostAsync(shift);
        //    //Assert
        //    var redirectToActionResult = Assert.IsType<RedirectToPageResult>(result);
        //    mockService.Verify((s) => s.AddShiftAsync(@shift), Times.Once);
        //}
    }
}
