using Moq;
using PSV.Core;
using PSV.Model;
using PSV.Service;
using Xunit;

namespace PSVTests
{
    public class UserServiceTest
    {
        [Fact]
        public void GivenExistingUserEmailThenReturnUserExists()
        {
            var mockUserEmail = "existingUser@test.com";

            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(m => m.GetUserWithEmail(mockUserEmail)).Returns(new User()).Verifiable();

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(m => m.Users).Returns(userRepositoryMock.Object);

            var userService = new UserService(unitOfWorkMock.Object);
            Assert.True(userService.DoesUserExist(mockUserEmail));
        }

        [Fact]
        public void GivenNewUserEmailThenReturnUserDoesNotExist()
        {
            var mockUserEmail = "newUser@test.com";

            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(m => m.GetUserWithEmail(mockUserEmail)).Returns((User) null).Verifiable();

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(m => m.Users).Returns(userRepositoryMock.Object);

            var userService = new UserService(unitOfWorkMock.Object);
            Assert.False(userService.DoesUserExist(mockUserEmail));
        }
    }
}