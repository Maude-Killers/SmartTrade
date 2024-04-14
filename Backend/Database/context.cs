using Microsoft.EntityFrameworkCore;
using SmartTrade.Models;

public class AppDbContext : DbContext
{

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging();
        optionsBuilder.EnableDetailedErrors();
    }

    public DbSet<WeatherForecast> WeatherForecasts { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<TechnoProduct> TechnoProduct { get; set; }
    public DbSet<SportProduct> SportProduct { get; set; }
    public DbSet<GroceryProduct> GroceryProduct { get; set; }
    public DbSet<Gallery> Gallery { get; set; }
    public DbSet<List> List { get; set; }

    public DbSet<WishList> WishList { get; set; }
    public DbSet<LaterList> LaterList { get; set; }

    public DbSet<Person> Person { get; set; }
    public DbSet<Client> Client { get; set; }
    public DbSet<SalesPerson> SalesPerson { get; set; }
    public DbSet<ListProduct> ListProducts { get; set; }

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

        modelBuilder.Entity<ListProduct>()
            .HasKey(ce => new { ce.Product_code, ce.List_code });

        var clients = Enumerable.Range(1, 5).Select(index => new Client
        {
            Email = $"prueba{index}@prueba.com",
            Password = $"cliente{index}",
            FullName = $"Cliente {index}",
            PhoneNumber = 654654654 + index,
        }).ToArray();
        modelBuilder.Entity<Client>().HasData(clients);

        var wishLists = Enumerable.Range(1, 5).Select(index => new WishList
        {
            List_code = index,
            Name = "WishList",
            ClientEmail = clients[index - 1].Email
        }).ToArray();
        modelBuilder.Entity<WishList>().HasData(wishLists);

        var laterLists = Enumerable.Range(6, 10).Select(index => new LaterList
        {
            List_code = index,
            Name = "LaterList",
            ClientEmail = clients[index - 1].Email
        }).ToArray();
        modelBuilder.Entity<LaterList>().HasData(laterLists);

        var sportProducts = Enumerable.Range(1, 5).Select(index => new SportProduct
        {
            Product_code = index,
            Name = "product" + index,
            Price = 10 + index,
            Description = "descripcion" + index,
            Features = "caracteristicas" + index,
            Huella = Random.Shared.Next(-20, 55),
        }).ToArray();
        modelBuilder.Entity<SportProduct>().HasData(sportProducts);

        var groceryProducts = Enumerable.Range(6, 5).Select(index => new GroceryProduct
        {
            Product_code = index,
            Name = "product" + index,
            Price = 10 + index,
            Description = "descripcion" + index,
            Features = "caracteristicas" + index,
            Huella = Random.Shared.Next(-20, 55),
        }).ToArray();
        modelBuilder.Entity<GroceryProduct>().HasData(groceryProducts);

        var technoProducts = Enumerable.Range(11, 5).Select(index => new TechnoProduct
        {
            Product_code = index,
            Name = "product" + index,
            Price = 10 + index,
            Description = "descripcion" + index,
            Features = "caracteristicas" + index,
            Huella = Random.Shared.Next(-20, 55),
        });
        modelBuilder.Entity<TechnoProduct>().HasData(technoProducts);

        var listProducts = Enumerable.Range(1, 5).Select(index => new ListProduct
        {
            Product_code = index + 10,
            List_code = index
        });
        modelBuilder.Entity<ListProduct>().HasData(listProducts);

    }
}