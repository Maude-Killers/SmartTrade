using System.Net.Http.Json;
using DataTransferObject;

public class ProductService
{
    private readonly HttpClient _httpClient;

    public ProductService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ProductDTO> GetProductAsync(int product_code)
    {
        return await _httpClient.GetFromJsonAsync<ProductDTO>($"products/{product_code}") ?? new ProductDTO();
    }


    public async Task<ProductDTO[]> SearchProduct(string searchValue)
    {
        return await _httpClient.GetFromJsonAsync<ProductDTO[]>($"search?value={searchValue}") ?? Array.Empty<ProductDTO>();
    }

    public async Task SaveProductAsync(ProductDTO product)
    {
        await _httpClient.PostAsJsonAsync("/products", product);
    }

    public async Task DeleteProductAsync(int Product_code)
    {
        var response = await _httpClient.DeleteAsync($"product/{Product_code}");
        //if (response.StatusCode == System.Net.HttpStatusCode.NotFound) { throw new }
    }
}
