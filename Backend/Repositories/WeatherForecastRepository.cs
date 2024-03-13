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

        public Task<IEnumerable<WeatherForecast>> createWeatherForecast(WeatherForecast forecast)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<WeatherForecast>> deleteWeatherForecast(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<WeatherForecast>> editWeatherForecast(int id, WeatherForecast forecast)
        {
            throw new NotImplementedException();
        }

        public WeatherForecast GetWeatherForecast(int id)
        {
            var forecast = _context.WeatherForecasts.Find(id) ?? throw new InvalidOperationException("Forecast no encontrado");
            return forecast;

        }

        public IEnumerable<WeatherForecast> GetWeatherForecasts()
        {
            return _context.WeatherForecasts.ToList();
        }
    }
}