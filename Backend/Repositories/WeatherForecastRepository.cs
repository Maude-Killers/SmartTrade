using Backend.Interfaces;
using SmartTrade.Models;

namespace Backend.Repositories
{
    public class WeatherForecastsRepository : IWeatherForecastRepository
    {
        private readonly AppDbContext _context;

        public WeatherForecastsRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Create(WeatherForecast item)
        {
            _context.WeatherForecasts.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var targetForecast = _context.WeatherForecasts
                .Where(forecast => forecast.Id == id)
                .FirstOrDefault();

            if (targetForecast == null) throw new InvalidOperationException();

            _context.WeatherForecasts.Remove(targetForecast);
            _context.SaveChanges();
        }

        public WeatherForecast? Get(int id)
        {
            var forecast = _context.WeatherForecasts
                .Where(forecast => forecast.Id == id)
                .FirstOrDefault() ?? throw new ResourceNotFound("Cannot find Weatherforecast", id);
            return forecast;
        }

        public IEnumerable<WeatherForecast> GetAll()
        {
            return _context.WeatherForecasts.ToList();
        }

        public void Set(int id, WeatherForecast item)
        {
            var actualForecast = _context.WeatherForecasts
                .Where(forecast => forecast.Id == id)
                .FirstOrDefault();

            if (actualForecast == null) throw new InvalidOperationException();

            actualForecast.TemperatureC = item.TemperatureC;
            actualForecast.Summary = item.Summary;
            actualForecast.Date = item.Date.ToUniversalTime();
            _context.SaveChanges();
        }
    }
}