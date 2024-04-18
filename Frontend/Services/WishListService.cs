using DataTransferObject;
using System.Net.Http.Json;
using SmartTrade.Models;

public class WishListService
{
    private readonly HttpClient _httpClient;

    public WishListService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task SaveProductAsync(Product product)
    {
        await _httpClient.PostAsJsonAsync("/wishlist", product);
    }

}

