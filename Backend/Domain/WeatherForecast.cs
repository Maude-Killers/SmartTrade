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
            return _service.GetWeatherForecasts();
        }

        public WeatherForecast GetById(int id)
        {
            return _service.GetWeatherForecast(id);
        }
    }
}