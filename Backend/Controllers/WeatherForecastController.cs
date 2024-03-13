using Backend.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SmartTrade.Models;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly WeatherForecastEntity _domain;

        public WeatherForecastController(WeatherForecastEntity domain, ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            _domain = domain;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return _domain.GetAll();
        }

        [HttpGet("/weatherforecast/{id}", Name = "GetWeatherForecastById")]
        public ActionResult<WeatherForecast> Get(int id)
        {
            var forecast = _domain.GetById(id);

            if (forecast == null)
            {
                return NotFound();
            }

            return forecast;
        }
    }
}