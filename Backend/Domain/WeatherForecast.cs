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

        public async Task<IEnumerable<WeatherForecast>> GetAll()
        {
            return await _service.GetWeatherForecasts();
        }
    }
}