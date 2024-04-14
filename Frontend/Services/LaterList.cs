using System.Net.Http.Json;
using SmartTrade.Models;

public class LaterListService
{
    private readonly HttpClient _httpClient;

    public LaterListService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
}

