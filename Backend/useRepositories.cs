using Backend.Interfaces;
using Backend.Repositories;
using SmartTrade.Models;

public static class Repositories
{
    public static void UseRepositories(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ISalesPersonRepository, SalesPersonRepository>();

        builder.Services.AddScoped<IClientRepository, ClientRepository>();

        builder.Services.AddScoped<IPersonRepository, PersonRepository>();

        builder.Services.AddScoped<IProductRepository<Product>, ProductRepository>();

        builder.Services.AddScoped<ISportProductRepository, SportProductRepository>();

        builder.Services.AddScoped<IGroceryProductRepository, GroceryProductRepository>();

        builder.Services.AddScoped<ITechnoProductRepository, TechnoProductRepository>();

        builder.Services.AddScoped<IWishListRepository, WishListRepository>();

        builder.Services.AddScoped<ILaterListRepository, LaterListRepository>();

        builder.Services.AddScoped<IGalleryRepository, GalleryRepository>();
    }
}