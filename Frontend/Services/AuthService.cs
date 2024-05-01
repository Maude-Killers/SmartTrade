using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Microsoft.JSInterop;
using SmartTrade.Models;

public class AuthService
{
    private readonly HttpClient _httpClient;
    private readonly IJSRuntime _jsRuntime;

    public AuthService(HttpClient httpClient, IJSRuntime jsRuntime)
    {
        _httpClient = httpClient;
        _jsRuntime = jsRuntime;
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

    private async Task<string> GetJWTTokenCookieAsync()
    {
        return await _jsRuntime.InvokeAsync<string>("getJWTTokenCookie");
    }

    private (bool IsValid, string? UserId) ValidateAndDecode(string jwtToken)
    {
        var handler = new JwtSecurityTokenHandler();

        // Asegúrate de que el token es un JWT válido.
        if (!handler.CanReadToken(jwtToken))
        {
            throw new ArgumentException("El token proporcionado no es válido.");
        }

        var token = handler.ReadJwtToken(jwtToken);

        // Verifica la expiración sin validar la firma.
        if (token.ValidTo < DateTime.UtcNow)
        {
            return (false, null);  // Token expirado
        }

        // Extrae el claim que necesitas, por ejemplo, el UserId.
        var userId = token.Claims.FirstOrDefault(c => c.Type == "name")?.Value;

        return (true, userId);
    }

    public async Task<(bool, string?)> GetCurrentUser()
    {
        var jwtToken = await GetJWTTokenCookieAsync();
        if (jwtToken == null)
        {
            return (false, null);
        }

        var (isValid, username) = ValidateAndDecode(jwtToken);

        return (isValid, username);
    }
}