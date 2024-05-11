using System.Net.Http.Json;

public class CategoryService
{
    private readonly HttpClient _httpClient;

    public CategoryService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ProductDTO[]> GetAllProductsByCategoriesAsync(string category)
    {
        return await _httpClient.GetFromJsonAsync<ProductDTO[]>($"products/{category}") ?? Array.Empty<ProductDTO>();
        
    }
}
