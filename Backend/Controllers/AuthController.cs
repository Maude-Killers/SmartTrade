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
    private readonly SmartTrade _smartTrade;

    public AuthController(AuthHelpers authService, SmartTrade smartTrade)
    {
        _authService = authService;
        _smartTrade = smartTrade;
    }

    [HttpPost("/login")]
    public void Login([FromBody] Person loginRequest)
    {
        Person result = _smartTrade.LoginPerson(loginRequest.Email, loginRequest.Password);
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