using Backend.Interfaces;
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

        public async Task<IEnumerable<WeatherForecast>> GetWeatherForecasts()
        {
            return await _context.WeatherForecasts.ToListAsync();
        }
    }
}