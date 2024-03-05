using SmartTrade.Models;

namespace Backend.Interfaces
{
    public interface IWeatherForecastRepository
    {
        Task<IEnumerable<WeatherForecast>> GetWeatherForecasts();
    }
}