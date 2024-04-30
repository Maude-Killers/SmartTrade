using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Frontend;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
var apiUrl = builder.Configuration["API_URL"] ?? "Failed getting API URL";

builder.Services.AddScoped(sp => new HttpClient(new CookieHandler()) { BaseAddress = new Uri(apiUrl), });

builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<AuthService>();

await builder.Build().RunAsync();
