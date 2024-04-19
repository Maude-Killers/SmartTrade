using DataTransferObject;
using System.Net.Http.Json;
using SmartTrade.Models;

public class ListService
{
    private readonly HttpClient _httpClient;

    public ListService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task AddWishList(ProductDTO product)
    {
        await _httpClient.PostAsJsonAsync("/wishlist", product);
    }

    public async Task AddLaterList(ProductDTO product)
    {
        await _httpClient.PostAsJsonAsync("/laterlist", product);
    }

}

