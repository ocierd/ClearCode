using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Clear.CodeSample.WebUI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : BaseController
    {

        private static readonly IEnumerable<WeatherForecast> weatherForCastCollection = Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = new Random().Next(-20, 55),
            Summary = Summaries[new Random().Next(Summaries.Length)]
        });
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        => weatherForCastCollection;

        [HttpGet("{id}")]
        public ActionResult<WeatherForecast> Get(int id)
        {
            if (weatherForCastCollection.Count() - 1 < id)
            {
                return NoContent();
            }
            WeatherForecast weather = weatherForCastCollection.FirstOrDefault();
            return Ok(weather);
        }

    }
}
