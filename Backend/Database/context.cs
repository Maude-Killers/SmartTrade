using Backend.Database;
using Microsoft.EntityFrameworkCore;
using Backend.Models;

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

        var nike = new SportProductEntity
        {
            Product_code = 1,
            Name = "Zapatillas Nike",
            Price = 90,
            Description = "Zapatillas Nike Court Vision color blanco y verde, inspirado en el baloncesto de los 80" +
            "Nike Court Vision Mid reúne el rétro del parquet y la comodidad moderna, con materiales reciclados para al menos el 20% de su peso. " +
            "La suela tiene piezas en Nike Grind, mientras que el Tomaia testurizado en cuero sintético mantiene el aspecto clásico que le gusta tanto.",
            Features = "Dimensiones del producto : 34 x 23 x 12 cm; 500 g" + "\n" +
            "Material de la suelaCaucho" + "\n" +
            "Altura de ejeAnkle Strap" + "\n" +
            "Material exteriorSintético" + "\n" +
            "Material internoSynthetic",
            FingerPrint = Random.Shared.Next(-20, 55)
        };
        modelBuilder.Entity<SportProductEntity>().HasData(nike);

        var raqueta = new SportProductEntity
        {
            Product_code = 2,
            Name = "Raqueta pádel",
            Price = 80,
            Description = "Raqueta de espuma suave con protector integrado para mayor durabilidad, mayor potencia y menos vibraciones. " +
            "La raqueta tiene un cuadro de carbono. Es la elección perfecta para los jóvenes",
            Features = "Dimensiones del producto : 45 x 22 x 4 cm; 200 g" + "\n" +
            "Material : Grafito" + "\n" +
            "Material del marco : Carbono" + "\n" +
            "Material de la varilla : Fibra de carbono" + "\n" ,
            FingerPrint = Random.Shared.Next(-20, 55)
        };
        modelBuilder.Entity<SportProductEntity>().HasData(raqueta);

        var bolsa = new SportProductEntity
        {
            Product_code = 3,
            Name = "Bolsa de gimnasio",
            Price = 23,
            Description = "con la bolsa de FITGRIFF puede esperar una bolsa multiusos moderna y bien pensada: " +
            "súper adecuada como bolsa de entrenamiento, bolsa de viaje, bolsa de baño",
            Features = "Dimensiones del producto : 48 x 26 x 25 cm; 700 g" + "\n" +
            "Fabricante : Fitgriff" + "\n" +
            "Material: 100% poliéster" + "\n" ,
            FingerPrint = Random.Shared.Next(-20, 55)
        };
        modelBuilder.Entity<SportProductEntity>().HasData(bolsa);

        var balon = new SportProductEntity
        {
            Product_code = 4,
            Name = "Balón fútbol",
            Price = 30,
            Description = " el balón de fútbol está hecho de cuero de PVC suave y cosido con máquinas exquisitas para proporcionar una sensación de mano suave y equilibrada," +
            "resistente al desgaste y duradero. Revestimiento a prueba de explosiones",
            Features = "Dimensiones del producto : 27 x 13,7 x 12 cm; 540 g" + "\n" +
            "Material : Cuero" + "\n" +
            "Marca : Aipwerer" + "\n" ,
            FingerPrint = Random.Shared.Next(-20, 55)
        };
        modelBuilder.Entity<SportProductEntity>().HasData(balon);

        var camiseta = new SportProductEntity
        {
            Product_code = 5,
            Name = "Camiseta de deporte",
            Price = 25,
            Description = "Tejido de malla suave y confortable, cómodo y transpirable la camiseta deportiva tiene un corte holgado y es cómoda de llevar." +
            " Confeccionada con un tejido transpirable y que absorbe la humedad, absorbe el sudor y se seca rápidamente",
            Features = "Dimensiones del producto : 15 x 10 x 1 cm; 300 g" + "\n" +
            "Material : dry-fit 100% poliéster " + "\n" +
            "Marca : Herbalife" + "\n",
            FingerPrint = Random.Shared.Next(-20, 55)
        };
        modelBuilder.Entity<SportProductEntity>().HasData(camiseta);

        var tomate = new GroceryProductEntity
        {
            Product_code = 6,
            Name = "Tomates",
            Price = 1,
            Description = "Tomate de rama de gran calidad, proveniente de Almería" ,
            Features = "Dimensiones del producto : 7 x 8 x 7 cm; 250 g" + "\n" +
            "Fabricante : MERCOPHAL, S.L" + "\n" ,
            FingerPrint = Random.Shared.Next(-20, 55),
        };
        modelBuilder.Entity<GroceryProductEntity>().HasData(tomate);

        var lechuga = new GroceryProductEntity
        {
            Product_code = 7,
            Name = "Lechuga trocadero",
            Price = 2,
            Description = "Lechuga trocadero de gran calidad, proveniente de Francia",
            Features = "Dimensiones del producto : 24,5 x 17 x 9,5 cm; 380 g" + "\n" +
            "Fabricante : Felixia" + "\n" +
            "Instrucciones de almacenaje : 6° C -8° C" + "\n",
            FingerPrint = Random.Shared.Next(-20, 55),
        };
        modelBuilder.Entity<GroceryProductEntity>().HasData(lechuga);

        var calabacin = new GroceryProductEntity
        {
            Product_code = 8,
            Name = "Calabacín",
            Price = 1,
            Description = "Calabacín de gran calidad, proveniente de España",
            Features = "Dimensiones del producto : 18,01 x 5 x 3,99 cm; 500 g" + "\n" +
            "Fabricante : Eurobanan" + "\n" +
            "Instrucciones de almacenaje : 6° C -8° C" + "\n",
            FingerPrint = Random.Shared.Next(-20, 55),
        };
        modelBuilder.Entity<GroceryProductEntity>().HasData(calabacin);

        var platano = new GroceryProductEntity
        {
            Product_code = 9,
            Name = "Plátano de canarias",
            Price = 2,
            Description = "Platanos de gran calidad, provenientes de Canarias",
            Features = "Dimensiones del producto : 24 x 20 x 8 cm; 1,2 kg" + "\n" +
            "Fabricante : ARC-EUROBANAN, S.L." + "\n" +
            "Consumir preferiblemente en 2-3 días" + "\n",
            FingerPrint = Random.Shared.Next(-20, 55),
        };
        modelBuilder.Entity<GroceryProductEntity>().HasData(platano);

        var melon = new GroceryProductEntity
        {
            Product_code = 10,
            Name = "Melón Cantaloup",
            Price = 7,
            Description = "Melón de gran calidad, proveniente de Canarias",
            Features = "Dimensiones del producto : 5,99 x 5 x 3,99 cm; 1,25 kg" + "\n" +
           "Fabricante : Felixia" + "\n" +
           "Instrucciones de almacenaje : 10° C -12° C" + "\n",
            FingerPrint = Random.Shared.Next(-20, 55),
        };
        modelBuilder.Entity<GroceryProductEntity>().HasData(melon);

        var raton = new TechnoProductEntity
        {
            Product_code = 11,
            Name = "Ratón gaming",
            Price = 32,
            Description = "De tamaño mediano, fácil de agarrar para la mayoría de las personas, el peso ultraligero es de solo 75 gramos, " +
            "diseño de panal ergonómico, fácil de agarrar y operar en juegos y oficinas",
            Features = "Dimensiones del producto : 12,6 x 6,3 x 4 cm; 105 g" + "\n" +
           "Fabricante : DIERYA" + "\n" +
           "Sistema operativo: Windows 7/10" + "\n",
            FingerPrint = Random.Shared.Next(-20, 55),
        };
        modelBuilder.Entity<TechnoProductEntity>().HasData(raton);

        var teclado = new TechnoProductEntity
        {
            Product_code = 12,
            Name = "Teclado gaming",
            Price = 42,
            Description = "Teclado ultra responsivo + silencioso. disfrute de tiempos de respuesta rapidísimos con la tecnología inalámbrica de 2,4 ghz." +
            " el keyz tungsten ofrece una respuesta mucho más rápida y precisa que la mayoría de los teclados inalámbricos para juegos del mercado",
            Features = "Dimensiones del producto : 25,4 x 5,08 x 6,86 cm; 800 g" + "\n" +
           "Fabricante : AXS" + "\n" +
           "Sistema operativo: Windows" + "\n",
            FingerPrint = Random.Shared.Next(-20, 55),
        };
        modelBuilder.Entity<TechnoProductEntity>().HasData(teclado);

        var monitor = new TechnoProductEntity
        {
            Product_code = 13,
            Name = "Monitor",
            Price = 202,
            Description = "el monitor de 24 pulgadas adopta una nueva generación de pantalla VA, que cubre el 99 % de la gama de colores SRGB. " +
            "Por lo tanto, el monitor de la computadora puede restaurar al 100% los colores reales y presentar detalles vívidos. " +
            "Además, el amplio ángulo de visión de 178° de este monitor de PC le permite disfrutar de imágenes claras, nítidas y delicadas desde cualquier ángulo.",
            Features = "Dimensiones del producto : 42,32 x 54,2 x 18,11 cm; 3,63 kg" + "\n" +
           "Fabricante : KOORUI" + "\n" +
           "Interfaz del hardware: VGA, HDMI" + "\n",
            FingerPrint = Random.Shared.Next(-20, 55),
        };
        modelBuilder.Entity<TechnoProductEntity>().HasData(monitor);

        var ventilador = new TechnoProductEntity
        {
            Product_code = 14,
            Name = "Ventilador ordenador",
            Price = 7,
            Description = "El ventilador Aura II ha sido fabricado con el exclusivo y reconocido sistema de rodamientos de alta tecnología Tacens Fluxus II (10-12-12dB). " +
            "Equipado a su vez con un cableado negro de alta calidad, que aumenta la protección y mejora la apariencia de este ventilador",
            Features = "Dimensiones del producto : 35 x 3 x 15,01 cm; 98,5 g" + "\n" +
           "Fabricante : ‎Tacens Spain" + "\n" +
           "Descripción de la batería: 12VDC" + "\n",
            FingerPrint = Random.Shared.Next(-20, 55),
        };
        modelBuilder.Entity<TechnoProductEntity>().HasData(ventilador);

        var patrisioapruebame = new TechnoProductEntity
        {
            Product_code = 15,
            Name = "Peluche pingüino",
            Price = 12,
            Description = "hecho de telas de felpa de alta calidad. Relleno de plumas de algodón PP en este peluche de pingüino totalmente vestido. " +
            "El interior de alta calidad es realmente cómodo de sostener y soporta cualquier posición del cuerpo descansada a su alrededor.",
            Features = "Dimensiones del producto : ‎6 x 5 x 12 cm; 140 g" + "\n" +
           "Material : ‎Nailon" + "\n" +
           "Marca: Generic" + "\n",
            FingerPrint = Random.Shared.Next(-20, 55),
        };
        modelBuilder.Entity<TechnoProductEntity>().HasData(patrisioapruebame);

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