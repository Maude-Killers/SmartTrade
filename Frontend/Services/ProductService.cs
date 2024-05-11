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

    public async Task<Product[]> SearchProduct(string searchValue)
    {
        return await _httpClient.GetFromJsonAsync<Product[]>($"search?value={searchValue}") ?? Array.Empty<Product>();
    }

    public async Task SaveProductAsync(Product product)
    {
        await _httpClient.PostAsJsonAsync("/products", product);
    }

    public async Task DeleteProductAsync(int Product_code)
    {
        var response = await _httpClient.DeleteAsync($"product/{Product_code}");
        //if (response.StatusCode == System.Net.HttpStatusCode.NotFound) { throw new }
    }
}
