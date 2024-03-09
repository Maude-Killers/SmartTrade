using Backend.Interfaces;
using SmartTrade.Models;

namespace Backend.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly IWeatherForecastRepository _repository;

        public WeatherForecastService(IWeatherForecastRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<WeatherForecast>> GetWeatherForecasts()
        {
            return await _repository.GetWeatherForecasts();
        }
    }
}