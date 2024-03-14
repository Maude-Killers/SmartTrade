using System.Net.Http.Json;
using SmartTrade.Models;

public class WeatherForecastService
{
    private readonly HttpClient _httpClient;

    public WeatherForecastService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task SaveForecastAsync(WeatherForecast usuario)
    {
        if (usuario.Id == 0)
        {
            await _httpClient.PostAsJsonAsync("/weatherforecast", usuario);
        }
        else
        {
            await _httpClient.PutAsJsonAsync($"weatherforecast/{usuario.Id}", usuario);
        }
    }

    public async Task DeleteForecastAsync(int id)
    {
        await _httpClient.DeleteAsync($"weatherforecast/{id}");
    }
}
