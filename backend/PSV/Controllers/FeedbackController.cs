using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PSV.Model;
using PSV.Service;

namespace PSV.Controllers
{
    [ApiController]
    public class FeedbackController : DefaultController
    {
        private FeedbackService feedbackService = new FeedbackService();

        [Authorize]
        [Route("/api/feedbacks/all")]
        [HttpGet]
        public PageResponse<Feedback> GetAll([FromQuery(Name = "page")] int page,
            [FromQuery(Name = "perPage")] int perPage, [FromQuery(Name = "search")] string search)
        {
            throw new NotImplementedException();
        }

        [Authorize]
        [Route("/api/feedbacks/public")]
        [HttpGet]
        public PageResponse<Feedback> GetPublic()
        {
            throw new NotImplementedException();
        }

        [Route("/api/feedbacks")]
        [HttpPost]
        public async Task<IActionResult> Add(Feedback feedbackData)
        {
            throw new NotImplementedException();
        }

        [Route("/api/feedbacks/publish/{id}")]
        [HttpPost]
        public async Task<IActionResult> Publish(int id)
        {
            throw new NotImplementedException();
        }

        [Route("/api/feedbacks/unpublish/{id}")]
        [HttpPost]
        public async Task<IActionResult> Unpublish(int id)
        {
            throw new NotImplementedException();
        }
    }
}