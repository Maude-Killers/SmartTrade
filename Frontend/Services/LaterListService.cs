using DataTransferObject;
using System.Net.Http.Json;

public class LaterListService
{
    private readonly HttpClient _httpClient;

    public LaterListService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task AñadirLaterList(ProductDTO product)
    {
        await _httpClient.PostAsJsonAsync("/laterlist", product);
    }
}

