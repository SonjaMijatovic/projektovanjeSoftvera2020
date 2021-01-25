using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PSV.Model;

namespace PSV.Controllers
{
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
                string url = "http://localhost:8080/recepies/all";
                using (HttpClient client = new HttpClient())
                {
                    return await client.GetStringAsync(url);
                }
            }
            catch (Exception e) { }

            return Ok();
        }

        [HttpPost]
        [Route("/api/recepies/")]
        public async Task<HttpResponseMessage> Add(Recepie recepie)
        {
            try
            {
                var newRecepie = new
                {
                    id = -1,
                    patient = new
                    {
                        firstName = recepie.Patient.FirstName,
                        lastName = recepie.Patient.LastName,
                    },
                    items = new[] {
                        new {
                            medicine = new { name = recepie.Medicine.Name },
                            count = recepie.Amount
                        }}
                };
                string url = "http://localhost:8080/recepies/";
                using (HttpClient client = new HttpClient())
                {
                    return await client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(newRecepie), UnicodeEncoding.UTF8, "application/json"));
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
    }
}
