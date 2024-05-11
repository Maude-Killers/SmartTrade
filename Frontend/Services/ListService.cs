using System.Net.Http.Json;
using SmartTrade.Models;

public class ListService
{
    private readonly HttpClient _httpClient;

    public ListService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Product>> GetWishListProducts()
    {
        return await _httpClient.GetFromJsonAsync<List<Product>>($"/wishlist") ?? new List<Product>();
    }

    public async Task<List<Product>> GetGiftListProducts()
    {
        return await _httpClient.GetFromJsonAsync<List<Product>>($"/giftlist") ?? new List<Product>();
    }

    public async Task<List<Product>> GetLaterListProducts()
    {
        return await _httpClient.GetFromJsonAsync<List<Product>>($"/laterlist") ?? new List<Product>();
    }

    public async Task AddProductToWishList(Product product)
    {
        await _httpClient.PostAsync($"/wishlist/{product.Product_code}", null);
    }

    public async Task AddProductToGiftList(Product product)
    {
        await _httpClient.PostAsync($"/giftlist/{product.Product_code}", null);
    }

    public async Task AddProductToCart(int product)
    {
        await _httpClient.PostAsync($"/cart/{product}", null);
    }

    public async Task DeleteProductFromWishList(int Product_code)
    {
        await _httpClient.DeleteAsync($"/wishlist/{Product_code}");
    }

    public async Task DeleteProductFromGiftList(int Product_code)
    {
        await _httpClient.DeleteAsync($"/giftlist/{Product_code}");
    }
    
    public async Task DeleteItemFromCart(int product)
    {
        await _httpClient.DeleteAsync($"/cart/{product}");
    }
    public async Task DeleteProductFromCart(int product)
    {
        await _httpClient.DeleteAsync($"/cart/{product}/?all=true");
    }

    public async Task MoveProductFromLaterToCart(int product)
    {
        await _httpClient.PostAsync($"/cart/{product}/?fromLater=true", null);
    }

    public async Task MoveProductFromCartToLater(int product)
    {
        await _httpClient.PostAsync($"/laterlist/{product}/?fromCart=true", null);
    }
}

