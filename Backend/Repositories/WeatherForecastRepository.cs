using Backend.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
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

        public void createWeatherForecast(WeatherForecast forecast)
        {
            _context.WeatherForecasts.Add(forecast);
            _context.SaveChanges();
        }

        public void deleteWeatherForecast(int id)
        {
            var targetForecast = _context.WeatherForecasts
                .Where(forecast => forecast.Id == id)
                .FirstOrDefault();
            
            if (targetForecast == null) throw new InvalidOperationException();

            _context.WeatherForecasts.Remove(targetForecast);
            _context.SaveChanges();
        }

        public void editWeatherForecast(int id, WeatherForecast newForecast)
        {
            var actualForecast = _context.WeatherForecasts
                .Where(forecast => forecast.Id == id)
                .FirstOrDefault();

            if (actualForecast == null) throw new InvalidOperationException();

            actualForecast.TemperatureC = newForecast.TemperatureC;
            actualForecast.Summary = newForecast.Summary;
            actualForecast.Date = newForecast.Date.ToUniversalTime();
            _context.SaveChanges();

        }

        public WeatherForecast GetWeatherForecast(int id)
        {
            var forecast = _context.WeatherForecasts
                .Where(forecast => forecast.Id == id)
                .FirstOrDefault();

            return forecast;

        }

        public IEnumerable<WeatherForecast> GetWeatherForecasts()
        {
            return _context.WeatherForecasts.ToList();
        }
    }
}