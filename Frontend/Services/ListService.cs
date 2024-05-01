using DataTransferObject;
using System.Net.Http.Json;
using SmartTrade.Models;
using Microsoft.AspNetCore.Components.WebAssembly.Http;

public class ListService
{
    private readonly HttpClient _httpClient;

    public ListService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ProductDTO> GetWishList()
    {
        return await _httpClient.GetFromJsonAsync<ProductDTO>($"/wishlist") ?? new ProductDTO();
    }

    public async Task<ProductDTO> GetGiftList()
    {
        return await _httpClient.GetFromJsonAsync<ProductDTO>($"/giftlist") ?? new ProductDTO();
    }

    public async Task AddWishList(ProductDTO product)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, $"/wishlist/{product.Product_code}");
        request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);
        await _httpClient.SendAsync(request);
    }

    public async Task AddGiftList(ProductDTO product)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, $"/giftlist/{product.Product_code}");
        request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);
        await _httpClient.SendAsync(request);
    }

    public async Task DeleteWishList(int Product_code)
    {
        var request = new HttpRequestMessage(HttpMethod.Delete, $"/wishlist/{Product_code}");
        request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);
        await _httpClient.SendAsync(request);
    }

    public async Task DeleteGiftList(int Product_code)
    {
        var request = new HttpRequestMessage(HttpMethod.Delete, $"/giftlist/{Product_code}");
        request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);
        await _httpClient.SendAsync(request);
    }

}

