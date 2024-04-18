using Backend.Interfaces;
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
        private readonly IPersonRepository _personRepository;

        public AuthController(AuthHelpers authService, IPersonRepository personRepository)
        {
            _authService = authService;
            _personRepository = personRepository;
        }

        [HttpPost("/login")]
        public void Login([FromBody] Person loginRequest)
        {
            var result = _personRepository.Get(loginRequest.Email, loginRequest.Password);
            string token;
            if (result is Client) 
            { 
                token = _authService.GenerateJWTToken(result, "client"); 
                
            }

            else { token = _authService.GenerateJWTToken(result, "salesPerson"); }

            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.Now.AddDays(1),
            };

            Response.Cookies.Append("JWTToken", token, cookieOptions);
        }
    }
}
