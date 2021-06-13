using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PSV.Model;
using PSV.Service;

namespace PSV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        protected UserService userService = new UserService();

        protected User GetCurrentUser()
        {
            var email = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Email")?.Value;

            return userService.FindUserByEmail(email);
        }
    }
    
}
