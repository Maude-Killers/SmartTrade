using System.Net.Http.Json;
using SmartTrade.Models;

public class ProductService
{
    private readonly HttpClient _httpClient;

    public ProductService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task SaveProductAsync(Product product)
    {
        if (product.Product_code == 0)
        {
            await _httpClient.PostAsJsonAsync("/product", product);
        }
        else
        {
            await _httpClient.PutAsJsonAsync($"product/{product.Product_code}", product);
        }
    }

    public async Task DeleteProductAsync(int Product_code)
    {
        var response= await _httpClient.DeleteAsync($"product/{Product_code}");
        //if (response.StatusCode == System.Net.HttpStatusCode.NotFound) { throw new }
    }
}
