using Backend.Interfaces;

namespace SmartTrade.Models
{
    public partial class WeatherForecastEntity
    {
        private readonly IWeatherForecastService _service;

        public WeatherForecastEntity(IWeatherForecastService service)
        {
            _service = service;
        }

        public IEnumerable<WeatherForecast> GetAll()
        {
            return _service.GetAll();
        }

        public WeatherForecast? GetById(int id)
        {
            return _service.Get(id);
        }

        public void CreateForecast(WeatherForecast forecast)
        {
            _service.Create(forecast);
        }

        public void EditForecast(int id, WeatherForecast forecast)
        {
            _service.Set(id, forecast);
        }

        public void DeleteForecast(int id)
        {
            _service.Delete(id);
        }
    }
}