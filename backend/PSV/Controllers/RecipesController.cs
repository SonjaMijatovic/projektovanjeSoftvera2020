﻿using System;
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
        private const String RecipesServiceBaseUrl = "http://localhost:8080/recipes/";

        [HttpGet]
        [Route("/api/recepies/{id}")]
        public async Task<ActionResult<string>> Get(int id)
        {
            try
            {
                string url = RecipesServiceBaseUrl + id;
                using HttpClient client = new HttpClient();
                return await client.GetStringAsync(url);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("/api/recepies/all")]
        public async Task<ActionResult<string>> GetAll()
        {
            try
            {
                string url = RecipesServiceBaseUrl + "all";
                using (HttpClient client = new HttpClient())
                {
                    return await client.GetStringAsync(url);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
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
                    items = new[]
                    {
                        new
                        {
                            medicine = new {name = recepie.Medicine.Name},
                            count = recepie.Amount
                        }
                    }
                };
                using (HttpClient client = new HttpClient())
                {
                    return await client.PostAsync(RecipesServiceBaseUrl,
                        new StringContent(JsonConvert.SerializeObject(newRecepie), Encoding.UTF8, "application/json"));
                }
            }
            catch (Exception e)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }
    }
}