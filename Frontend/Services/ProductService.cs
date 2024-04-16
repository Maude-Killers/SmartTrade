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
