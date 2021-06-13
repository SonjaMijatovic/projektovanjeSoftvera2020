using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PSV.Model;

namespace PSV.Controllers
{
    [ApiController]
    public class UserController : DefaultController
    {
        [Authorize]
        [Route("/api/users/all")]
        [HttpGet]
        public PageResponse<User> GetAll([FromQuery(Name = "page")] int page, [FromQuery(Name = "perPage")] int perPage, [FromQuery(Name = "search")] string search)
        {
            return userService.GetPage(new PageModel(page, perPage, search));
        }

        [Authorize]
        [Route("/api/users/current")]
        [HttpGet]
        public async Task<IActionResult> GetCurrent()
        {
            return Ok(GetCurrentUser());
        }

        [Route("/api/users")]
        [HttpPost]
        public async Task<IActionResult> Register(User userData)
        {
            throw new NotImplementedException();
        }

        [Route("/api/users/block/{id}")]
        [HttpPost]
        public async Task<IActionResult> Block(int id)
        {
            userService.Block(id);

            return Ok();
        }

        [Route("/api/users/unblock/{id}")]
        [HttpPost]
        public async Task<IActionResult> Unblock(int id)
        {
            userService.Unlock(id);

            return Ok();
        }
    }
}
