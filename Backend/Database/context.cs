using Microsoft.EntityFrameworkCore;
using SmartTrade.Models;

public class AppDbContext : DbContext
{

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }

    public DbSet<WeatherForecast> WeatherForecasts { get; set; }
    public DbSet<Product> Product { get; set; }
    public DbSet<Gallery> Gallery { get; set; }
    public DbSet<Person> Person { get; set; }
    public DbSet<Client> Client { get; set; }
    public DbSet<SalesPerson> SalesPerson { get; set; }

    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<WeatherForecast>().HasData(
            Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Id = index,
                Date = DateTime.UtcNow.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
            })
            .ToArray()
        );

        modelBuilder.Entity<Client>().HasData(
            Enumerable.Range(1, 5).Select(index => new Client
            {
                
            })
            .ToArray()
        );
    }
}