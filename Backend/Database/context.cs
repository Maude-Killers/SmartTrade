using Microsoft.EntityFrameworkCore;
using SmartTrade.Models;
using System.Linq;

public class AppDbContext : DbContext
{

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }

    public DbSet<WeatherForecast> WeatherForecasts { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<TechnoProduct> TechnoProduct { get; set; }
    public DbSet<SportProduct> SportProduct { get; set; }
    public DbSet<GroceryProduct> GroceryProduct { get; set; }
    public DbSet<Gallery> Gallery { get; set; }
    public DbSet<List> List { get; set; }
    public DbSet<WishList> WishList { get; set; }
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
        modelBuilder.Entity<SportProduct>().HasData(
            Enumerable.Range(1, 5).Select(index => new SportProduct
            {
                Product_code = index,
                Name = "product" + index,
                Price = 10 + index,
                Description = "descripcion" + index,
                Features = "caracteristicas" + index,
                Huella = Random.Shared.Next(-20, 55),
            })
            .ToArray()
        );
        modelBuilder.Entity<GroceryProduct>().HasData(
            Enumerable.Range(6, 5).Select(index => new GroceryProduct
            {
                Product_code = index,
                Name = "product" + index,
                Price = 10 + index,
                Description = "descripcion" + index,
                Features = "caracteristicas" + index,
                Huella = Random.Shared.Next(-20, 55),
            })
            .ToArray()
        );
        modelBuilder.Entity<TechnoProduct>().HasData(
            Enumerable.Range(11, 5).Select(index => new TechnoProduct
            {
                Product_code = index,
                Name = "product" + index,
                Price = 10 + index,
                Description = "descripcion" + index,
                Features = "caracteristicas" + index,
                Huella = Random.Shared.Next(-20, 55),
            })
            .ToArray()
        );
        //crear wishlist

        var existingProducts = new TechnoProduct
        {
            Product_code = 50,
            Name = "product" + 50,
            Price = 10 + 1,
            Description = "descripcion" + 50,
            Features = "caracteristicas" + 50,
            Huella = Random.Shared.Next(-20, 55)
        };

        var wishlistC = new WishList
        {
            List_code = 50,
            Name = "WishList" + 50,
            Products = { existingProducts }
        };
        


        modelBuilder.Entity<Client>().HasData(
            Enumerable.Range(1, 5).Select(index => new Client()
             {
                Email = $"prueba{index}@prueba.com",
                Password = $"cliente{index}",
                FullName = $"Cliente {index}",
                PhoneNumber = 654654654 + index,
                wishList= wishlistC
            })
            .ToArray()
        );

        

    }
}