using SmartTrade.Models;

namespace Backend.Interfaces
{
    public interface IWeatherForecastRepository
    {
        Task<IEnumerable<WeatherForecast>> createWeatherForecast(WeatherForecast forecast);
        IEnumerable<WeatherForecast> GetWeatherForecasts();
        WeatherForecast GetWeatherForecast(int id);
        Task<IEnumerable<WeatherForecast>> editWeatherForecast(int id, WeatherForecast forecast);
        Task<IEnumerable<WeatherForecast>> deleteWeatherForecast(int id);
    }
}