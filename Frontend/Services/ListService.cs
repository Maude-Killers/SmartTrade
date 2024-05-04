using DataTransferObject;
using System.Net.Http.Json;

public class ListService
{
    private readonly HttpClient _httpClient;

    public ListService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<ProductDTO>> GetWishListProducts()
    {
        return await _httpClient.GetFromJsonAsync<List<ProductDTO>>($"/wishlist") ?? new List<ProductDTO>();
    }

    public async Task<List<ProductDTO>> GetGiftListProducts()
    {
        return await _httpClient.GetFromJsonAsync<List<ProductDTO>>($"/giftlist") ?? new List<ProductDTO>();
    }

    public async Task<List<ProductDTO>> GetLaterListProducts()
    {
        return await _httpClient.GetFromJsonAsync<List<ProductDTO>>($"/laterlist") ?? new List<ProductDTO>();
    }

    public async Task AddProductToWishList(ProductDTO product)
    {
        await _httpClient.PostAsync($"/wishlist/{product.Product_code}", null);
    }

    public async Task AddProductToGiftList(ProductDTO product)
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

