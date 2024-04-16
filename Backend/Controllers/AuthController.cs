using Backend.Utils;
using Microsoft.AspNetCore.Mvc;
using SmartTrade.Models;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthHelpers _authService;
        private readonly Person _domain;

        public AuthController(AuthHelpers authService, Person domain)
        {
            _authService = authService;
            _domain = domain;
        }

        [HttpPost("/login")]
        public void Login([FromBody] Person loginRequest)
        {
            // Perform authentication
            var result = _domain.ValidateEmail(loginRequest.Email, loginRequest.Password);
            if (result != null)
            {
                string token;
                //Llamar helper para generar token
                if (result is Client) { token = _authService.GenerateJWTToken(result, "client"); }
                else { token = _authService.GenerateJWTToken(result, "salesPerson"); }

                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true,
                    Expires = DateTime.Now.AddDays(1),
                };

                // Enviar la cookie
                Response.Cookies.Append("JWTToken", token, cookieOptions);
            }
            else { }
        }
    }
}
