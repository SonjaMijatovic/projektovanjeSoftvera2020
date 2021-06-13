using Microsoft.AspNetCore.Mvc;
using PSV.Controllers;
using PSV.Model;
using Xunit;

namespace PSVTests
{
    public class UserControllerTest
    {
        [Fact]
        public void UserController_RegisterUser()
        {
            var controller = new UserController();
            var result = controller.Register(new User
            {
                Email = "test@test.com", FirstName = "Name", LastName = "LastName", Password = "12345",
                UserType = "PATIENT"
            });

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var user = Assert.IsType<User>(okResult.Value);
            Assert.NotNull(user);
            Assert.Equal("test@test.com", user.Email);
            Assert.Equal("Name", user.FirstName);
            Assert.Equal("LastName", user.LastName);
            Assert.Equal("PATIENT", user.UserType);
        }
    }
}