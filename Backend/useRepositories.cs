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

        builder.Services.AddScoped<IProductRepository, ProductRepository>();

        builder.Services.AddScoped<IWishListRepository, WishListRepository>();

        builder.Services.AddScoped<ILaterListRepository, LaterListRepository>();

        builder.Services.AddScoped<IGalleryRepository, GalleryRepository>();
    }
}