using Backend.Services;
using Backend.Utils;
using dotenv.net;
using Microsoft.EntityFrameworkCore;
using Backend.Models;
using Backend.Domain.DesignPattern;

DotEnv.Load();

var builder = WebApplication.CreateBuilder(args);

var connectionString = Environment.GetEnvironmentVariable("DATABASE_STRING_CONNECTION") ?? builder.Configuration.GetConnectionString("PostgresDbContext");
var jwtSecret = Environment.GetEnvironmentVariable("JWT_SECRET") ?? builder.Configuration.GetSection("JwtConfig:key").Value ?? throw new Exception("Fail to get jwt config key");

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));
builder.Services.AddScoped<AuthHelpers>(ah => new AuthHelpers(jwtSecret));

builder.Services.AddScoped<ProductService>();

Repositories.UseRepositories(builder);

builder.Services.AddSingleton<SmartTrade>();
builder.Services.AddSingleton<CommandInvoker>();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.WriteIndented = true;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

AppServices.Configure(builder.Services.BuildServiceProvider());

builder.Services.ConfigureJwtAuthentication(builder.Configuration);

var app = builder.Build();

app.UseCors(x => x
    .AllowAnyHeader()
    .AllowAnyMethod()
    .SetIsOriginAllowed(origin => true)
    .AllowCredentials()
);

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

// app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

