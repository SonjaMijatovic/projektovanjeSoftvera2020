using Microsoft.AspNetCore.Mvc;
using PSV.Controllers;
using PSV.Model;
using Xunit;
using static PSVTests.UserTestUtil;

namespace PSVTests
{
    public class FeedbackControllerTest
    {
        [Fact]
        public void FeedbackControllerTest_AddFeedback()
        {
            var controller = new FeedbackController();
            var content = GenerateRandomString(30);
            var email = GenerateRandomString(10);
            var name = GenerateRandomString(6);
            var lastName = GenerateRandomString(6);
            var pass = GenerateRandomString(12);
            const string patientType = "PATIENT";
            var user = new User
            {
                Email = email, FirstName = name, LastName = lastName, Password = pass, UserType = patientType
            };
            var result = controller.Add(new Feedback
            {
                Content = content, User = user, Visible = false
            });

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var feedback = Assert.IsType<Feedback>(okResult.Value);
            Assert.NotNull(feedback);
            Assert.Equal(content, feedback.Content);
            Assert.Equal(user, feedback.User);
            Assert.False(feedback.Visible);
        }
        
        [Fact]
        public void FeedbackControllerTest_PublishFeedback()
        {
            var controller = new FeedbackController();
            var feedbackId = 1;
            var result = controller.Publish(feedbackId);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
        }
        
        [Fact]
        public void FeedbackControllerTest_UnpublishFeedback()
        {
            var controller = new FeedbackController();
            var feedbackId = 1;
            var result = controller.Publish(feedbackId);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
        }
    }
}