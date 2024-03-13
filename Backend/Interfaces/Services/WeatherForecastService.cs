using SmartTrade.Models;

namespace Backend.Interfaces
{
    public interface IWeatherForecastService
    {
        Task<IEnumerable<WeatherForecast>> createWeatherForecast(WeatherForecast forecast);
        IEnumerable<WeatherForecast> GetWeatherForecasts();
        WeatherForecast GetWeatherForecast(int id);

        Task<IEnumerable<WeatherForecast>> editWeatherForecast(int i, WeatherForecast forecast);
        Task<IEnumerable<WeatherForecast>> deleteWeatherForecast(int i);
    }

}