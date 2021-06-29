using System;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PSV.Controllers;
using PSV.Model;
using Xunit;
using static PSVTests.UserTestUtil;

namespace PSVTests
{
    public class RecipesControllerTest
    {
        [Fact]
        public void RecipesController_GetAll()
        {
            var controller = new RecipesController();

            var result = controller.GetAll();

            Assert.NotNull(result);
            Assert.NotNull(result.Result);
            var okResult = Assert.IsType<ActionResult<string>>(result.Result);
            Assert.Contains("Jovanovic", okResult.Value);
        }

        [Fact]
        public void RecipesController_Add_ValidRecipe()
        {
            var controller = new RecipesController();
            var randomRecipe = new Recipe
                {Patient = GenerateRandomUser(), Amount = new Random().Next(), Medicine = GenerateRandomMedicine()};

            var result = controller.Add(randomRecipe);

            var okResult = Assert.IsType<HttpResponseMessage>(result.Result);
            String content = okResult.Content.ReadAsStringAsync().Result;

            var addedRecipe = JsonConvert.DeserializeObject<JObject>(content);
            var addedPatient = addedRecipe["patient"];
            var addedItem = addedRecipe["items"].FirstOrDefault();
            Assert.NotNull(addedItem);
            var addedMedicine = addedItem["medicine"];

            Assert.Equal(addedPatient["firstName"], randomRecipe.Patient.FirstName);
            Assert.Equal(addedPatient["lastName"], randomRecipe.Patient.LastName);
            Assert.Equal(addedItem["count"], randomRecipe.Amount);
            Assert.Equal(addedMedicine["name"], randomRecipe.Medicine.Name);
        }
        
        [Fact]
        public void RecipesController_Add_InvalidRecipe()
        {
            var controller = new RecipesController();
            var randomRecipe = new Recipe
                {Patient = null, Amount = new Random().Next(), Medicine = GenerateRandomMedicine()};

            var result = controller.Add(randomRecipe);

            var okResult = Assert.IsType<HttpResponseMessage>(result.Result);
            Assert.Equal(HttpStatusCode.InternalServerError, okResult.StatusCode);
        }

        private Medicine GenerateRandomMedicine()
        {
            return new Medicine
            {
                Name = GenerateRandomString(10), Amount = 0
            };
        }

        private User GenerateRandomUser()
        {
            var email = GenerateRandomString(10);
            var name = GenerateRandomString(6);
            var lastName = GenerateRandomString(6);
            var pass = GenerateRandomString(12);
            const string patientType = "PATIENT";
            return new User
            {
                Email = email, FirstName = name, LastName = lastName, Password = pass, UserType = patientType
            };
        }
    }
}