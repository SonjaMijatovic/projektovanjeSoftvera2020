using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
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
            
            var mockedUser = new ClaimsPrincipal(new ClaimsIdentity(new[]
            {
                new Claim("Email", "test@test.com"),
            }, "mock"));
            
            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = mockedUser }
            };
            
            var content = GenerateRandomString(30);
            var result = controller.Add(new Feedback
            {
                Content = content, Visible = false
            });
            
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var feedback = Assert.IsType<Feedback>(okResult.Value);
            Assert.NotNull(feedback);
            Assert.Equal(content, feedback.Content);
            Assert.False(feedback.Visible);
        }

        [Fact]
        public void FeedbackControllerTest_PublishFeedback()
        {
            var controller = new FeedbackController();
            Random random = new Random();
            int feedbackId = random.Next();
            var result = controller.Publish(feedbackId);

            Assert.IsType<OkResult>(result.Result);
        }

        [Fact]
        public void FeedbackControllerTest_UnpublishFeedback()
        {
            var controller = new FeedbackController();
            Random random = new Random();
            int feedbackId = random.Next();
            var result = controller.Unpublish(feedbackId);

            Assert.IsType<OkResult>(result.Result);
        }
    }
}