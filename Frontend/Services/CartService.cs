using DataTransferObject;
using System.Net.Http.Json;
using SmartTrade.Models;
using Microsoft.AspNetCore.Components.WebAssembly.Http;

public class CartService
{
    private readonly HttpClient _httpClient;

    public CartService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task AddItem(int product)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, $"/cart/{product}");

        request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);
        await _httpClient.SendAsync(request);
    }
    public async Task DeleteItem(int product)
    {
        var request = new HttpRequestMessage(HttpMethod.Delete, $"/cart/{product}");

        request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);
        await _httpClient.SendAsync(request);
    }
    public async Task DeleteProduct(int product)
    {
        var request = new HttpRequestMessage(HttpMethod.Delete, $"/cart/{product}/?all=true");

        request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);
        await _httpClient.SendAsync(request);
    }
    
}

