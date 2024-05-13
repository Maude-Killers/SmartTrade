using Backend.Interfaces;
using Backend.Utils;
using Microsoft.AspNetCore.Mvc;
using Backend.Models;

namespace Backend.Controllers;
[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly AuthHelpers _authService;

    public AuthController(AuthHelpers authService)
    {
        _authService = authService;
    }

    [HttpPost("/login")]
    public void Login([FromBody] Person loginRequest)
    {
        Person result = SmartTrade.Singleton.LoginPerson(loginRequest.Email, loginRequest.Password);
        string token;
        if (result is Client)
        {
            token = _authService.GenerateJWTToken(result, "client");
        }
        else
        {
            token = _authService.GenerateJWTToken(result, "salesPerson");
        }

        var cookieOptions = new CookieOptions
        {
            Secure = true,
            HttpOnly = false,
            SameSite = SameSiteMode.None,
            Expires = DateTime.Now.AddDays(1),
        };

        Response.Cookies.Append("JWTToken", token, cookieOptions);
    }
}