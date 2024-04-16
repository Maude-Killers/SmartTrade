using Backend.Interfaces;
using Backend.Repositories;
using Backend.Services;
using dotenv.net;
using Microsoft.EntityFrameworkCore;
using SmartTrade.Models;

DotEnv.Load();

var builder = WebApplication.CreateBuilder(args);


var connectionString = Environment.GetEnvironmentVariable("PostgresDbContext") ?? builder.Configuration.GetConnectionString("PostgresDbContext");

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddScoped<IWeatherForecastRepository, WeatherForecastsRepository>();
builder.Services.AddScoped<IWeatherForecastService, WeatherForecastService>();
builder.Services.AddScoped<WeatherForecastEntity>();
builder.Services.AddScoped<ISportProductRepository, SportProductRepository>();
builder.Services.AddScoped<ISportProductService, SportProductService>();
builder.Services.AddScoped<SportProduct>();

builder.Services.AddScoped<IGroceryProductRepository, GroceryProductRepository>();
builder.Services.AddScoped<IGroceryProductService, GroceryProductService>();
builder.Services.AddScoped<GroceryProduct>();

builder.Services.AddScoped<ITechnoProductRepository, TechnoProductRepository>();
builder.Services.AddScoped<ITechnoProductService, TechnoProductService>();
builder.Services.AddScoped<TechnoProduct>();

builder.Services.AddScoped<IGalleryRepository, GalleryRepository>();
builder.Services.AddScoped<IGalleryService, GalleryService>();
builder.Services.AddScoped<Gallery>();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.WriteIndented = true;
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});
AppServices.Configure(builder.Services.BuildServiceProvider());

var app = builder.Build();

app.UseCors("AllowAnyOrigin");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Docker")
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Docker")
{
    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        dbContext.Database.Migrate();
    }
}

// app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
