public class WishListService
{
    private readonly HttpClient _httpClient;

    public WishListService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
}
