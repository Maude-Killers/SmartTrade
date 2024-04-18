public class LaterListService
{
    private readonly HttpClient _httpClient;

    public LaterListService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
}

