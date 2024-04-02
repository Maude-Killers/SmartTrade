using System.Net.Http.Json;
using SmartTrade.Models;

public class AuthService
{
    private readonly HttpClient _httpClient;

    public AuthService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task Login(string emailInput, string passwordInput)
    {
        // Send login request to the backend
        var loginRequest = new Person
        {
            Email = emailInput,
            Password = passwordInput
        };
    }

    public async Task DeleteForecastAsync(int id)
    {
        await _httpClient.DeleteAsync($"weatherforecast/{id}");
    }
}