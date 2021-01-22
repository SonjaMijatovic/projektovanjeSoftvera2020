using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PSV.Model;
using PSV.Service;


namespace PSV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecepieController : DefaultController
    {
        [HttpGet]
        [Route("/api/recepies/{id}")]
        public async Task<ActionResult<string>> Get(int id)
        {
            try
            {
                string url = "http://localhost:8080/recepies/" + id;
                using (HttpClient client = new HttpClient())
                {
                    return await client.GetStringAsync(url);
                }
            }
            catch (Exception e) { }

            return Ok();
        }

        [HttpGet]
        [Route("/api/recepies/all")]
        public async Task<ActionResult<string>> GetAll()
        {
            try
            {
                string url = "http://localhost:8080/recepies/";
                using (HttpClient client = new HttpClient())
                {
                    return await client.GetStringAsync(url);
                }
            }
            catch (Exception e) { }

            return Ok();
        }

        [HttpPost]
        [Route("/api/recepies")]
        public async Task<HttpResponseMessage> Add(Recepie recepie)
        {
            try
            {
                string url = "http://localhost:8080/recepies";
                using (HttpClient client = new HttpClient())
                {
                    return await client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(recepie)));
                }
            }
            catch (Exception e)
            {

            }

            return null;
        }
    }
}
