using SmartTrade.Models;

namespace Backend.Interfaces
{
    public interface IWeatherForecastService
    {
        void createWeatherForecast(WeatherForecast forecast);
        IEnumerable<WeatherForecast> GetWeatherForecasts();
        WeatherForecast GetWeatherForecast(int id);

        void editWeatherForecast(int i, WeatherForecast forecast);
        void deleteWeatherForecast(int i);
    }

}