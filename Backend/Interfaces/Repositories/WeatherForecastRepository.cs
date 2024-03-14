using SmartTrade.Models;

namespace Backend.Interfaces
{
    public interface IWeatherForecastRepository
    {
        void createWeatherForecast(WeatherForecast forecast);
        IEnumerable<WeatherForecast> GetWeatherForecasts();
        WeatherForecast GetWeatherForecast(int id);
        void editWeatherForecast(int id, WeatherForecast forecast);
        void deleteWeatherForecast(int id);
    }
}