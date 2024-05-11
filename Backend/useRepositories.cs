using Backend.Interfaces;
using Backend.Repositories;

public static class Repositories
{
    public static void UseRepositories(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IClientRepository, ClientRepository>();

        builder.Services.AddScoped<IPersonRepository, PersonRepository>();

        builder.Services.AddScoped<IProductRepository, ProductRepository>();

        builder.Services.AddScoped<IWishListRepository, WishListRepository>();

        builder.Services.AddScoped<IGiftListRepository, GiftListRepository>();

        builder.Services.AddScoped<IGalleryRepository, GalleryRepository>();
        
        builder.Services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>();

        builder.Services.AddScoped<ILaterListRepository, LaterListRepository>();
    }
}