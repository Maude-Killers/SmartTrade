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

    public async Task<ProductDTO> GetWishList()
    {
        return await _httpClient.GetFromJsonAsync<ProductDTO>($"/wishlist") ?? new ProductDTO();
    }

    public async Task<ProductDTO> GetLaterList()
    {
        return await _httpClient.GetFromJsonAsync<ProductDTO>($"/laterlist") ?? new ProductDTO();
    }

    public async Task AddWishList(ProductDTO product)
    {
        await _httpClient.PostAsJsonAsync("/wishlist", product);
    }

    public async Task AddLaterList(ProductDTO product)
    {
        await _httpClient.PostAsJsonAsync("/laterlist", product);
    }

    public async Task DeleteWishList(int Product_code)
    {
        await _httpClient.DeleteAsync($"/wishlist/{Product_code}");
    }

    public async Task DeleteLaterList(int Product_code)
    {
        await _httpClient.DeleteAsync($"/laterlist/{Product_code}");
    }

}

