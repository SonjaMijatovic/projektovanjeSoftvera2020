using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PSV.Model;
using PSV.Service;

namespace PSV.Controllers
{
    [ApiController]
    public class DoctorTypeController : DefaultController
    {
        private DoctorTypeService doctorTypeService = new DoctorTypeService();

        [Authorize]
        [Route("/api/doctor-type/all")]
        [HttpGet]
        public PageResponse<DoctorType> GetAll([FromQuery(Name = "page")] int page, [FromQuery(Name = "perPage")] int perPage, [FromQuery(Name = "search")] string search)
        {

            return doctorTypeService.GetPage(new PageModel(page, perPage, search));
        }

        [Route("/api/doctor-type")]
        [HttpPost]
        public async Task<IActionResult> Add(DoctorType doctorType)
        {
            return Ok(doctorTypeService.Add(doctorType));
        }
    }
}