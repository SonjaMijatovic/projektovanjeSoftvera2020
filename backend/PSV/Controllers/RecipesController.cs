using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PSV.Model;

namespace PSV.Controllers
{
    [ApiController]
    public class RecipesController : DefaultController
    {
        [HttpGet]
        [Route("/api/recepies/all")]
        public async Task<ActionResult<string>> GetAll()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("/api/recepies/")]
        public async Task<HttpResponseMessage> Add(Recipe recipe)
        {
            throw new NotImplementedException();
        }
    }
}