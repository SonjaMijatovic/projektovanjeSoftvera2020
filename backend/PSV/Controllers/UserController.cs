using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PSV.Model;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PSV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : DefaultController
    {
        [Authorize]
        [Route("/api/user/all")]
        [HttpGet]
        public PageResponse<User> GetAll([FromQuery(Name = "page")] int page, [FromQuery(Name = "perPage")] int perPage, [FromQuery(Name = "search")] string search)
        {

            return userService.GetPage(new PageModel(page, perPage, search));
        }

        [Authorize]
        [Route("/api/user/current")]
        [HttpGet]
        public async Task<IActionResult> GetCurrent()
        {
            return Ok(GetCurrentUser());
        }

        [Route("/api/user")]
        [HttpPost]
        public async Task<IActionResult> Register(User userData)
        {
            if (userData.Email == null || userData.Password == null || userData.FirstName == null || userData.LastName == null)
            {
                return BadRequest();
            }

            User user = userService.GetUserWithEmail(userData.Email);

            if (user != null)
            {
                return BadRequest("User exists");
            }

            user = userService.Add(userData);

            return Ok(user);
        }
    }
}
