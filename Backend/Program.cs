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

builder.Services.AddScoped<IWishListRepository, WishListRepository>();
builder.Services.AddScoped<IWishListService, WishListService>();
builder.Services.AddScoped<WishList>();

builder.Services.AddControllers();

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

var app = builder.Build();

AppServices.Configure(app.Services);

app.UseCors("AllowAnyOrigin");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Docker")
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Docker")
{
    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
