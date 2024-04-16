using System.ComponentModel.DataAnnotations;
using System.Net.Http.Json;
using SmartTrade.Models;

public class ProductService
{
    private readonly HttpClient _httpClient;

    public ProductService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Product> GetProductAsync(int product_code)
    {
        return await _httpClient.GetFromJsonAsync<Product>($"products/{product_code}") ?? new Product();
    }


    public async Task <Product[]> SearchProduct(string searchValue)
    {
        return await _httpClient.GetFromJsonAsync<Product[]>($"search?value={searchValue}") ?? Array.Empty<Product>();  
    }
  
    public async Task<String[]> GetProductImagesAsync(int product_code) 
    {
        var result = await _httpClient.GetFromJsonAsync<Gallery[]>($"galleries/{product_code}") ?? Array.Empty<Gallery>();
        return result.Select(gallery => gallery.Image).ToArray();
    }
}
