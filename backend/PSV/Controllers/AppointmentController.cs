using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PSV.Model;
using PSV.Service;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PSV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : DefaultController
    {
        private AppointmentService appointmentService = new AppointmentService();

        [Authorize]
        [Route("/api/appointment/all")]
        [HttpGet]
        public PageResponse<Appointment> GetAll([FromQuery(Name = "page")] int page, [FromQuery(Name = "perPage")] int perPage, [FromQuery(Name = "search")] string search)
        {

            return appointmentService.GetPage(new PageModel(page, perPage, search));
        }


        [Route("/api/appointment")]
        [HttpPost]
        public async Task<IActionResult> Register(Appointment appointmentData)
        {
            Appointment appointment = appointmentService.Add(appointmentData);

            return Ok(appointment);
        }
    }
}
}
