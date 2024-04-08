using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SmartTrade.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Backend.Utils
{
    public class AuthHelpers
    {
        private readonly JwtConfig _jwtKey;
        public AuthHelpers(IOptions<JwtConfig> jwtKey)
        {
            _jwtKey = jwtKey.Value;
        }
        public string GenerateJWTToken(Person person, string rol)
        {
            var claims = new List<Claim> {
                new Claim("email", person.Email),
                new Claim("name", person.FullName),
                new Claim(ClaimTypes.Role, rol)
            };
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtKey.key)),
                                                            SecurityAlgorithms.HmacSha256Signature),
                Subject = new ClaimsIdentity(claims)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
