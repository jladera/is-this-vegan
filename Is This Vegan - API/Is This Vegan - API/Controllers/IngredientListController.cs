using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Is_This_Vegan___API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Is_This_Vegan___API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IngredientListController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<IngredientListController> _logger;

        public IngredientListController(ILogger<IngredientListController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        // POST: /IngredientList
        [HttpPost]
        public IngredientListModel PostIngredientList([Bind("imageAsString,ingredientListRaw,ingredientListClean")] IngredientListModel ingredientList)
        {
            HttpResponseMessage response = null;

            response = new HttpResponseMessage(HttpStatusCode.OK);
            //response.Content = new StringContent(image);
            return ingredientList;
        }
    }
}
