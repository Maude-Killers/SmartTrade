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

        public void CreateForecast(WeatherForecast forecast)
        {
            _service.createWeatherForecast(forecast);
        }

        public void EditForecast(int id, WeatherForecast forecast)
        {
            _service.editWeatherForecast(id, forecast);
        }

        public void DeleteForecast(int id)
        {
            _service.deleteWeatherForecast(id);
        }
    }
}