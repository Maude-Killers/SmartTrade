using SmartTrade.Models;

namespace Backend.Interfaces
{
    public interface IWeatherForecastRepository : EntityRepository<WeatherForecast, int>
    {
    }
}