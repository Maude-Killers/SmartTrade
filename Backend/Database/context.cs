using Microsoft.EntityFrameworkCore;
using SmartTrade.Models;

public class AppDbContext : DbContext
{

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }

    public DbSet<WeatherForecast> WeatherForecasts { get; set; }
    public DbSet<TechnoProduct> TechnoProduct { get; set; }
    public DbSet<SportProduct> SportProduct { get; set; }
    public DbSet<GrocerieProduct> GrocerieProduct { get; set; }
    public DbSet<Product> Product { get; set; }
    public DbSet<Gallery> Gallery { get; set; }

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
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
            })
            .ToArray()
        );
        modelBuilder.Entity<SportProduct>().HasData(
            Enumerable.Range(1, 5).Select(index => new SportProduct
            {
                Product_code = index,
                Name = "product" + index,
                Price = 10 + index,
                Description = "descripción" + index,
                Features = "características" + index,
                Huella = Random.Shared.Next(-20, 55),
                Category = "Sports",
            })
            .ToArray()
        );
        modelBuilder.Entity<GrocerieProduct>().HasData(
            Enumerable.Range(1, 5).Select(index => new GrocerieProduct
            {
                Product_code = index,
                Name = "product" + index,
                Price = 10 + index,
                Description = "descripción" + index,
                Features = "características" + index,
                Huella = Random.Shared.Next(-20, 55),
                Category = "Grocerie",
            })
            .ToArray()
        );
        modelBuilder.Entity<TechnoProduct>().HasData(
            Enumerable.Range(1, 5).Select(index => new TechnoProduct
            {
                Product_code = index,
                Name = "product" + index,
                Price = 10 + index,
                Description = "descripción" + index,
                Features = "características" + index,
                Huella = Random.Shared.Next(-20, 55),
                Category = "Techno",
            })
            .ToArray()
        );
    }
}