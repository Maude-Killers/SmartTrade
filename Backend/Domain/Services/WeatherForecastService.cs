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

        public void createWeatherForecast(WeatherForecast forecast)
        {
            _repository.createWeatherForecast(forecast);
        }

        public void deleteWeatherForecast(int id)
        {
            _repository.deleteWeatherForecast(id);
        }

        public void editWeatherForecast(int id, WeatherForecast forecast)
        {
            _repository.editWeatherForecast(id, forecast);
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