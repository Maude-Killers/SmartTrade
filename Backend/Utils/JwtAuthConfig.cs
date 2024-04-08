using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.Text.Json;
using Microsoft.Extensions.Options;

namespace Backend.Utils
{
    public static class JwtAuthConfig
    {
        public static void ConfigureJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
            {
                
                services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                    
                        options.RequireHttpsMetadata = true;
                        options.SaveToken = false;
                        options.TokenValidationParameters = new TokenValidationParameters

                        {
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtConfig:key"])),
                            ValidateIssuer = false,
                            ValidateAudience = false,
                            ClockSkew = TimeSpan.Zero
                        };

                        options.Events = new JwtBearerEvents
                        {
                            OnTokenValidated = context =>
                            {
                                if (context.Principal.Identity is ClaimsIdentity identity)
                                {
                                    var roleClaim = context.Principal.FindFirst(ClaimTypes.Role);
                                    if (roleClaim != null)
                                    {
                                        var rol = JsonSerializer.Deserialize<string>(roleClaim.Value);
                                        
                                        identity.AddClaim(new Claim(ClaimTypes.Role, rol));
                                        
                                    }
                                }

                                return Task.CompletedTask;
                            }
                        };
                    });
            }
    }
}



