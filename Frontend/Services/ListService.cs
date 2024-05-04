using DataTransferObject;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.WebAssembly.Http;

public class ListService
{
    private readonly HttpClient _httpClient;

    public ListService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ProductDTO> GetWishListProducts()
    {
        return await _httpClient.GetFromJsonAsync<ProductDTO>($"/wishlist") ?? new ProductDTO();
    }

    public async Task<ProductDTO> GetGiftListProducts()
    {
        return await _httpClient.GetFromJsonAsync<ProductDTO>($"/giftlist") ?? new ProductDTO();
    }

    public async Task AddProductToWishList(ProductDTO product)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, $"/wishlist/{product.Product_code}");
        request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);
        await _httpClient.SendAsync(request);
    }

    public async Task AddProductToGiftList(ProductDTO product)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, $"/giftlist/{product.Product_code}");
        request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);
        await _httpClient.SendAsync(request);
    }

    public async Task DeleteProductFromWishList(int Product_code)
    {
        var request = new HttpRequestMessage(HttpMethod.Delete, $"/wishlist/{Product_code}");
        request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);
        await _httpClient.SendAsync(request);
    }

    public async Task DeleteProductFromGiftList(int Product_code)
    {
        var request = new HttpRequestMessage(HttpMethod.Delete, $"/giftlist/{Product_code}");
        request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);
        await _httpClient.SendAsync(request);
    }

    public async Task AddProductToCart(int product)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, $"/cart/{product}");

        request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);
        await _httpClient.SendAsync(request);
    }
    public async Task DeleteItemFromCart(int product)
    {
        var request = new HttpRequestMessage(HttpMethod.Delete, $"/cart/{product}");

        request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);
        await _httpClient.SendAsync(request);
    }
    public async Task DeleteProductFromCart(int product)
    {
        var request = new HttpRequestMessage(HttpMethod.Delete, $"/cart/{product}/?all=true");

        request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);
        await _httpClient.SendAsync(request);
    }

    public async Task MoveProductFromLaterToCart(int product)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, $"/cart/{product}/?fromLater=true");

        request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);
        await _httpClient.SendAsync(request);
    }

    public async Task MoveProductFromCartToLater(int product)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, $"/laterlist/{product}/?fromCart=true");

        request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);
        await _httpClient.SendAsync(request);
    }
}

