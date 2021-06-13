using Microsoft.AspNetCore.Mvc;
using PSV.Controllers;
using PSV.Model;
using Xunit;
using static PSVTests.UserTestUtil;

namespace PSVTests
{
    public class UserControllerTest
    {
        [Fact]
        public void UserController_RegisterUser()
        {
            var controller = new UserController();
            var email = GenerateRandomString(10);
            var name = GenerateRandomString(6);
            var lastName = GenerateRandomString(6);
            var pass = GenerateRandomString(12);
            const string patientType = "PATIENT";
            
            var result = controller.Register(new User
            {
                Email = email, FirstName = name, LastName = lastName, Password = pass, UserType = patientType
            });

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var user = Assert.IsType<User>(okResult.Value);
            Assert.NotNull(user);
            Assert.Equal(email, user.Email);
            Assert.Equal(name, user.FirstName);
            Assert.Equal(lastName, user.LastName);
            Assert.Equal(patientType, user.UserType);
        }
    }
}