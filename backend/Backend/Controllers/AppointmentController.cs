using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentCar.Model;
using RentCar.Service;

namespace RentCar.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : DefaultController
    {
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