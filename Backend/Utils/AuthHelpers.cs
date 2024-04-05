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
        public AuthHelpers(IOptions <JwtConfig> jwtKey) { 
            _jwtKey = jwtKey.Value;
        }
        public string GenerateJWTToken(Person person)
        {
            var claims = new List<Claim> {
            new Claim(ClaimTypes.NameIdentifier, person.Email),
            new Claim(ClaimTypes.Name, person.FullName),
        };
            var jwtToken = new JwtSecurityToken(
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddDays(30),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(
                       Encoding.UTF8.GetBytes(_jwtKey.key)
                        ),
                    SecurityAlgorithms.HmacSha256Signature)
                );
            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }

    }
}
