using System;
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

        [Fact]
        public void GivenValidUserDataReturnsCreatedUser()
        {
            var mockUser = new User{Email = "user@test.com", Password = "password", FirstName = "name", LastName = "lastName"};
            var expectedUser = new User{Email = "user@test.com", Password = "password", FirstName = "name", LastName = "lastName", UserType = "PATIENT", Blocked = false, Deleted = false, DateCreated = DateTime.Now, DateUpdated = DateTime.Now};

            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(m => m.Add(mockUser));

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(m => m.Users).Returns(userRepositoryMock.Object);
            
            var userService = new UserService(unitOfWorkMock.Object);
            var addedUser = userService.Add(mockUser);
            Assert.Equal(expectedUser.Email, addedUser.Email);
            Assert.Equal(expectedUser.Password, addedUser.Password);
            Assert.Equal(expectedUser.FirstName, addedUser.FirstName);
            Assert.Equal(expectedUser.LastName, addedUser.LastName);
            Assert.Equal(expectedUser.UserType, addedUser.UserType);
        }
    }
}
