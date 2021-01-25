using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PSV.Model;
using PSV.Service;
using System.Threading.Tasks;

namespace PSV.Controllers
{
    [ApiController]
    public class MedicineController : DefaultController
    {
        private MedsService mediciniService = new MedsService();

        [Authorize]
        [Route("/api/medicines/all")]
        [HttpGet]
        public PageResponse<Medicine> GetAll([FromQuery(Name = "page")] int page, [FromQuery(Name = "perPage")] int perPage, [FromQuery(Name = "search")] string search)
        {

            return mediciniService.GetPage(new PageModel(page, perPage, search));
        }

        [Route("/api/medicines")]
        [HttpPost]
        public async Task<IActionResult> Add(Medicine medicine)
        {
            return Ok(mediciniService.Add(medicine));
        }

        [Route("/api/medicines/{id}/{amount}")]
        [HttpPost]
        public async Task<IActionResult> AddMore(int id, double amount) {

            mediciniService.AddMore(id, amount);
            return Ok();
        }

    }
}
