using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PSV.Model;
using PSV.Service;

namespace PSV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : DefaultController
    {

        [Authorize]
        [Route("/api/feedbacks/all")]
        [HttpGet]
        public PageResponse<Feedback> GetAll([FromQuery(Name = "page")] int page, [FromQuery(Name = "perPage")] int perPage, [FromQuery(Name = "search")] string search)
        {

            return feedbackService.GetPage(new PageModel(page, perPage, search, GetCurrentUser()));
        }

        [Authorize]
        [Route("/api/feedbacks/public")]
        [HttpGet]
        public PageResponse<Feedback> GetPublic()
        {

            return feedbackService.GetPublic(new PageModel());
        }


        [Route("/api/feedbacks")]
        [HttpPost]
        public async Task<IActionResult> Add(Feedback feedbackData)
        {
            feedbackData.User = GetCurrentUser();
            Feedback feedback = feedbackService.Add(feedbackData);

            return Ok(feedback);
        }

        [Route("/api/feedbacks/publish/{id}")]
        [HttpPost]
        public async Task<IActionResult> Publish(int id)
        {
            feedbackService.Publish(id);

            return Ok();
        }

        [Route("/api/feedbacks/unpublish/{id}")]
        [HttpPost]
        public async Task<IActionResult> Unpublish(int id)
        {
            feedbackService.Unpublish(id);

            return Ok();
        }
    }
}