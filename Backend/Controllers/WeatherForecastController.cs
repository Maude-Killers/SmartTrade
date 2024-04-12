using Backend.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartTrade.Models;
using System.IdentityModel.Tokens.Jwt;

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

        [Authorize(Roles = "client")]
        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            var token = HttpContext.Request.Cookies["JWTToken"];
            var Email= AuthHelpers.GetEmail(token);
            return _domain.GetAll();
        }

        [HttpGet("/weatherforecasts/{id}", Name = "GetWeatherForecastById")]
        public ActionResult<WeatherForecast> Get(int id)
        {
            var forecast = _domain.GetById(id);

            if (forecast == null)
            {
                return NotFound();
            }

            return forecast;
        }

        [HttpPost(Name = "CreateWeatherForecast")]
        public void Post(WeatherForecast forecast)
        {
            _domain.CreateForecast(forecast);
        }

        [HttpPut("/weatherforecasts/{id}", Name = "EditWeatherForecast")]
        public void Put(int id, WeatherForecast forecast)
        {
            _domain.EditForecast(id, forecast);
        }

        [HttpDelete("/weatherforecasts/{id}", Name = "DeleteWeatherForecast")]
        public void Delete(int id)
        {
            _domain.DeleteForecast(id);
        }
    }
}