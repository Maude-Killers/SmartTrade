using System.Net.Http.Json;
using Backend.Models;

public class CategoryService
{
    private readonly HttpClient _httpClient;

    public CategoryService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Product[]> GetAllProductsByCategoriesAsync(string category)
    {
        return await _httpClient.GetFromJsonAsync<Product[]>($"products/{category}") ?? Array.Empty<Product>();
    }
}
