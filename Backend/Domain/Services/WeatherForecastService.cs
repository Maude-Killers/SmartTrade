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

        public Task<IEnumerable<WeatherForecast>> createWeatherForecast(WeatherForecast forecast)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<WeatherForecast>> deleteWeatherForecast(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<WeatherForecast>> editWeatherForecast(int id, WeatherForecast forecast)
        {
            throw new NotImplementedException();
        }

        public WeatherForecast GetWeatherForecast(int id)
        {
            return _repository.GetWeatherForecast(id);
        }

        public IEnumerable<WeatherForecast> GetWeatherForecasts()
        {
            return _repository.GetWeatherForecasts();
        }
    }
}