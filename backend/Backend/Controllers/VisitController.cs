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
    public class VisitController : DefaultController
    {
        [Authorize]
        [Route("/api/visit/all")]
        [HttpGet]
        public PageResponse<Visit> GetAll([FromQuery(Name = "page")] int page, [FromQuery(Name = "perPage")] int perPage, [FromQuery(Name = "search")] string search)
        {

            return visitService.GetPage(new PageModel(page, perPage, search));
        }

        [Route("/api/visit")]
        [HttpPost]
        public async Task<IActionResult> Register(Visit visitData)
        {
            Visit visit = visitService.Add(visitData);

            return Ok(visit);
        }
    }
}