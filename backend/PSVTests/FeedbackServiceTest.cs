using System;
using Moq;
using PSV.Core;
using PSV.Model;
using PSV.Service;
using Xunit;

namespace PSVTests
{
    public class FeedbackServiceTest
    {
        [Fact]
        public void GivenValidFeedbackThenAddingFeedbackReturnsCreatedFeedback()
        {
            var mockUser = new User
                {Email = "user@test.com", Password = "password", FirstName = "name", LastName = "lastName"};
            var mockFeedback = new Feedback {Content = "Test content", User = mockUser, Visible = false};

            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(m => m.Get(1)).Returns(mockUser).Verifiable();

            var feedbackRepositoryMock = new Mock<IFeedbackRepository>();
            feedbackRepositoryMock.Setup(m => m.Add(mockFeedback));

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(m => m.Feedback).Returns(feedbackRepositoryMock.Object);
            unitOfWorkMock.Setup(m => m.Users).Returns(userRepositoryMock.Object);

            var feedbackService = new FeedbackService(unitOfWorkMock.Object);
            var addedFeedback = feedbackService.Add(mockFeedback);
            Assert.Equal(mockFeedback, addedFeedback);
            Assert.False(addedFeedback.Visible);
            Assert.False(addedFeedback.Deleted);
            Assert.NotEqual(addedFeedback.DateCreated, DateTime.MinValue);
            Assert.NotEqual(addedFeedback.DateUpdated, DateTime.MinValue);
        }

        [Fact]
        public void GivenFeedbackThatIsNullThenAddingFeedbackReturnsNull()
        {
            var feedbackRepositoryMock = new Mock<IFeedbackRepository>();
            feedbackRepositoryMock.Setup(m => m.Add(null));

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(m => m.Feedback).Returns(feedbackRepositoryMock.Object);

            var feedbackService = new FeedbackService(unitOfWorkMock.Object);
            var addedFeedback = feedbackService.Add(null);
            Assert.Null(addedFeedback);
        }
    }
}