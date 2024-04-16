using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
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

        var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:5173/login")
        { 
            Content = JsonContent.Create(loginRequest)
        };
        
        request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);
        var result = await _httpClient.SendAsync(request);
    }

    public async Task DeleteForecastAsync(int id)
    {
        await _httpClient.DeleteAsync($"weatherforecast/{id}");
    }
}