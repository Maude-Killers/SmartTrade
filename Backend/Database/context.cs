using Microsoft.EntityFrameworkCore;
using SmartTrade.Models;
using System.Reflection.Metadata.Ecma335;

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
        var mondongo = Enumerable.Range(1, 5).Select(index => new SportProduct
        {
            Product_code = index,
            Name = "product" + index,
            Price = 10 + index,
            Description = "descripcion" + index,
            Features = "caracteristicas" + index,
            Huella = Random.Shared.Next(-20, 55),
        }).ToArray();

        modelBuilder.Entity<SportProduct>().HasData(mondongo);

        var creeper = Enumerable.Range(6, 5).Select(index => new GroceryProduct
        {
            Product_code = index,
            Name = "product" + index,
            Price = 10 + index,
            Description = "descripcion" + index,
            Features = "caracteristicas" + index,
            Huella = Random.Shared.Next(-20, 55),
        }).ToArray();

        modelBuilder.Entity<GroceryProduct>().HasData(creeper);

        var patricioApruebame = Enumerable.Range(11, 5).Select(index => new TechnoProduct
        {
            Product_code = index,
            Name = "product" + index,
            Price = 10 + index,
            Description = "descripcion" + index,
            Features = "caracteristicas" + index,
            Huella = Random.Shared.Next(-20, 55),
        }).ToArray();

        modelBuilder.Entity<TechnoProduct>().HasData(patricioApruebame);

        Gallery[] images = {
            new Gallery {
                Image ="https://i.imgur.com/WtfQOF3.png",
                Product_code=1,
            },
            new Gallery
            {
                Image = "https://i.imgur.com/bRFgYfL.png",
                Product_code=2,
            },
            new Gallery {
                Image = "https://i.imgur.com/0kTxfNT.png",
                Product_code=3,
            },
            new Gallery {
                Image = "https://i.imgur.com/tewVKu5.png",
                Product_code=4,
            },
            new Gallery {
                Image = "https://i.imgur.com/VcVlhzr.png",
                Product_code=5,
            },
            new Gallery {
                Image = "https://i.imgur.com/9ZpZZfe.png",
                Product_code=6,
            },
            new Gallery {
                Image="https://i.imgur.com/YgKapTz.png",
                Product_code=7,
            },
            new Gallery {
                Image="https://i.imgur.com/kgj7C77.png",
                Product_code=8,
            },
            new Gallery {
                Image="https://i.imgur.com/ATQsdPb.png",
                Product_code=9,
            },
            new Gallery {
                Image = "https://i.imgur.com/ADMjfOX.png",
                Product_code=10,
            },
            new Gallery {
                Image="https://i.imgur.com/IMMlRaG.png",
                Product_code=11,
            },
            new Gallery {
                Image = "https://i.imgur.com/qNLCqrT.png",
                Product_code=12,
            },
            new Gallery {
                Image = "https://i.imgur.com/qImnFwc.png",
                Product_code=13,
            },
            new Gallery {
                Image = "https://i.imgur.com/icpDfTu.png",
                Product_code=14,
            },
            new Gallery {
                Image="https://i.imgur.com/B9UeUnE.png",
                Product_code=15,
            },
            new Gallery
            {
                Image="https://www.timeshighereducation.com/student/sites/default/files/styles/default/public/different_sports.jpg",
                Category_name=SmartTrade.Models.Gallery.Category.Sport
            },
            new Gallery
            {
                Image="https://hips.hearstapps.com/hmg-prod/images/online-buying-and-delivery-concept-royalty-free-image-1675370119.jpg",
                Category_name=SmartTrade.Models.Gallery.Category.Grocery
            },
            new Gallery
            {
                Image="https://miro.medium.com/v2/resize:fit:720/format:webp/1*f9N5gbBNXLGqD7NgjzVg5g.jpeg",
                Category_name=SmartTrade.Models.Gallery.Category.Techno
            }
        };
        modelBuilder.Entity<Gallery>().HasData(images);

       /* for (int mindingi = 0; mindingi< mondongo.Length; mindingi++)
        {
            mondongo[mindingi].Images.Add(images[mindingi]);
        }
        modelBuilder.Entity<SportProduct>().HasData(mondongo);

        for (int mindingi = 0; mindingi < creeper.Length; mindingi++)
        {
            creeper[mindingi].Images.Add(images[mindingi + 5]);
        }
        modelBuilder.Entity<GroceryProduct>().HasData(creeper);

        for (int mindingi = 0; mindingi < patricioApruebame.Length; mindingi++)
        {
            patricioApruebame[mindingi].Images.Add(images[mindingi+10]);
        }
        modelBuilder.Entity< Add(images[mindingi + 10])TechnoProduct >().HasData(patricioApruebame);*/

    }
}