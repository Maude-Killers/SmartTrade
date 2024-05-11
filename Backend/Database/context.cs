using Backend.Database;
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

    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<TechnoProductEntity> TechnoProduct { get; set; }
    public DbSet<SportProductEntity> SportProduct { get; set; }
    public DbSet<GroceryProductEntity> GroceryProduct { get; set; }
    public DbSet<GalleryEntity> Gallery { get; set; }
    public DbSet<ListEntity> List { get; set; }
    public DbSet<LaterListEntity> LaterLists { get; set; }
    public DbSet<WishListEntity> WishList { get; set; }
    public DbSet<GiftListEntity> GiftList { get; set; }
    public DbSet<ShoppingCartEntity> ShoppingCart { get; set; }
    public DbSet<PersonEntity> Person { get; set; }
    public DbSet<ClientEntity> Client { get; set; }
    public DbSet<SalesPersonEntity> SalesPerson { get; set; }
    public DbSet<ListProduct> ListProducts { get; set; }


    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ListProduct>()
            .HasKey(ce => new { ce.Product_code, ce.List_code });

        var clients = Enumerable.Range(1, 5).Select(index => new ClientEntity
        {
            Email = $"prueba{index}@prueba.com",
            Password = $"cliente{index}",
            FullName = $"Cliente {index}",
            PhoneNumber = 654654654 + index,
        }).ToArray();
        modelBuilder.Entity<ClientEntity>().HasData(clients);

        var wishLists = Enumerable.Range(1, 5).Select(index => new WishListEntity
        {
            List_code = index,
            Name = "WishList",
            ClientEmail = clients[index - 1].Email
        }).ToArray();
        modelBuilder.Entity<WishListEntity>().HasData(wishLists);

        var giftLists = Enumerable.Range(1, 5).Select(index => new GiftListEntity
        {
            List_code = index + 5,
            Name = "GiftList",
            ClientEmail = clients[index - 1].Email
        }).ToArray();
        modelBuilder.Entity<GiftListEntity>().HasData(giftLists);

        var shoppingCart = Enumerable.Range(1, 5).Select(index => new ShoppingCartEntity
        {
            List_code = index + 10,
            Name = "ShoppingCart",
            ClientEmail = clients[index - 1].Email
        }).ToArray();
        modelBuilder.Entity<ShoppingCartEntity>().HasData(shoppingCart);

        var laterList = Enumerable.Range(1, 5).Select(index => new LaterListEntity
        {
            List_code = index + 15,
            Name = "LaterList",
            ClientEmail = clients[index - 1].Email
        }).ToArray();
        modelBuilder.Entity<LaterListEntity>().HasData(laterList);

        var mondongo = Enumerable.Range(1, 5).Select(index => new SportProductEntity
        {
            Product_code = index,
            Name = "product" + index,
            Price = 10 + index,
            Description = "descripcion" + index,
            Features = "caracteristicas" + index,
            FingerPrint = Random.Shared.Next(-20, 55),
        }).ToArray();
        modelBuilder.Entity<SportProductEntity>().HasData(mondongo);

        var creeper = Enumerable.Range(6, 5).Select(index => new GroceryProductEntity
        {
            Product_code = index,
            Name = "product" + index,
            Price = 10 + index,
            Description = "descripcion" + index,
            Features = "caracteristicas" + index,
            FingerPrint = Random.Shared.Next(-20, 55),
        }).ToArray();
        modelBuilder.Entity<GroceryProductEntity>().HasData(creeper);

        var patricioApruebame = Enumerable.Range(11, 5).Select(index => new TechnoProductEntity
        {
            Product_code = index,
            Name = "product" + index,
            Price = 10 + index,
            Description = "descripcion" + index,
            Features = "caracteristicas" + index,
            FingerPrint = Random.Shared.Next(-20, 55),
        }).ToArray();
        modelBuilder.Entity<TechnoProductEntity>().HasData(patricioApruebame);

        var listProducts = Enumerable.Range(1, 5).Select(index => new ListProduct
        {
            Product_code = index + 10,
            List_code = index
        });
        modelBuilder.Entity<ListProduct>().HasData(listProducts);

        var giftProducts = Enumerable.Range(1, 5).Select(index => new ListProduct
        {
            Product_code = index + 5,
            List_code = index + 5
        });
        modelBuilder.Entity<ListProduct>().HasData(giftProducts);

        GalleryEntity[] images = {
            new GalleryEntity
             {
                Image ="https://i.imgur.com/WtfQOF3.png",
                Product_code=1,
            },
            new GalleryEntity
            {
                Image = "https://i.imgur.com/bRFgYfL.png",
                Product_code=2,
            },
            new GalleryEntity
             {
                Image = "https://i.imgur.com/0kTxfNT.png",
                Product_code=3,
            },
            new GalleryEntity
             {
                Image = "https://i.imgur.com/tewVKu5.png",
                Product_code=4,
            },
            new GalleryEntity
            {
                Image = "https://i.imgur.com/VcVlhzr.png",
                Product_code=5,
            },
            new GalleryEntity
             {
                Image = "https://i.imgur.com/9ZpZZfe.png",
                Product_code=6,
            },
            new GalleryEntity
             {
                Image="https://i.imgur.com/YgKapTz.png",
                Product_code=7,
            },
            new GalleryEntity
            {
                Image="https://i.imgur.com/kgj7C77.png",
                Product_code=8,
            },
            new GalleryEntity
            {
                Image="https://i.imgur.com/ATQsdPb.png",
                Product_code=9,
            },
            new GalleryEntity
            {
                Image = "https://i.imgur.com/ADMjfOX.png",
                Product_code=10,
            },
            new GalleryEntity
             {
                Image="https://i.imgur.com/IMMlRaG.png",
                Product_code=11,
            },
            new GalleryEntity
            {
                Image = "https://i.imgur.com/qNLCqrT.png",
                Product_code=12,
            },
            new GalleryEntity
            {
                Image = "https://i.imgur.com/qImnFwc.png",
                Product_code=13,
            },
            new GalleryEntity
            {
                Image = "https://i.imgur.com/icpDfTu.png",
                Product_code=14,
            },
            new GalleryEntity
            {
                Image="https://i.imgur.com/B9UeUnE.png",
                Product_code=15,
            },
            new GalleryEntity
            {
                Image="https://www.timeshighereducation.com/student/sites/default/files/styles/default/public/different_sports.jpg",
                Category=Category.Sport
            },
            new GalleryEntity
            {
                Image="https://hips.hearstapps.com/hmg-prod/images/online-buying-and-delivery-concept-royalty-free-image-1675370119.jpg",
                Category=Category.Grocery
            },
            new GalleryEntity
            {
                Image="https://miro.medium.com/v2/resize:fit:720/format:webp/1*f9N5gbBNXLGqD7NgjzVg5g.jpeg",
                Category=Category.Techno
            }
        };
        modelBuilder.Entity<GalleryEntity>().HasData(images);
    }
}