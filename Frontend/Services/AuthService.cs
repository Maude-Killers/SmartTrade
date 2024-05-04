using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Json;
using Fluxor;
using Frontend.Store;
using Microsoft.JSInterop;
using SmartTrade.Models;

public class AuthService
{
    private readonly HttpClient _httpClient;
    private readonly IJSRuntime _jsRuntime;
    private readonly IDispatcher _dispatcher;

    public AuthService(HttpClient httpClient, IJSRuntime jsRuntime, IDispatcher dispatcher)
    {
        _httpClient = httpClient;
        _jsRuntime = jsRuntime;
        _dispatcher = dispatcher;
    }

    public async Task Login(string emailInput, string passwordInput)
    {
        var loginRequest = new Person
        {
            Email = emailInput,
            Password = passwordInput
        };

        await _httpClient.PostAsJsonAsync("/login", loginRequest);
        UpdateUserState();
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

    public async void UpdateUserState()
    {
        var token = await GetJWTTokenCookieAsync();
        var (isValid, name) = ValidateAndDecode(token);
        if (isValid && !string.IsNullOrEmpty(name))
        {
            _dispatcher.Dispatch(new SetUserAction(isValid, name));
        }
        else
        {
            _dispatcher.Dispatch(new SetUserAction());
        }
    }
}