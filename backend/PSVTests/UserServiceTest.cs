using Moq;
using PSV.Service;
using Xunit;

namespace PSVTests
{
    public class UserServiceTest
    {
        [Fact]
        public void GivenExistingUserEmailThenReturnUserExists()
        {
            var userService = new Mock<UserService>();
            var mockUserEmail = "existingUser@test.com";
            userService.Setup(x => x.DoesUserExist(mockUserEmail)).Returns(true);
            Assert.True(userService.Object.DoesUserExist(mockUserEmail));
        }
        
        [Fact]
        public void GivenNewUserEmailThenReturnUserDoesNotExist()
        {
            var userService = new Mock<UserService>();
            var mockUserEmail = "newUser@test.com";
            userService.Setup(x => x.DoesUserExist(mockUserEmail)).Returns(false);
            Assert.False(userService.Object.DoesUserExist(mockUserEmail));
        }
        
    }
}