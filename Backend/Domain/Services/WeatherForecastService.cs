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

        public void Create(WeatherForecast item)
        {
            _repository.Create(item);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public WeatherForecast? Get(int id)
        {
            return _repository.Get(id);
        }

        public IEnumerable<WeatherForecast> GetAll()
        {
            return _repository.GetAll();
        }

        public void Set(int id, WeatherForecast item)
        {
            _repository.Set(id, item);
        }
    }
}