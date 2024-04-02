using Backend.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SmartTrade.Models;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            // Authentication logic
            // Perform authentication
            if (IsValidUser(loginRequest.Email, loginRequest.Password))
            {
                // Return success response with user type (Client or Salesperson)
                var userType = GetUserType(loginRequest.Email);
                return Ok(new LoginResult { Type = userType, Message = "Login successful" });
            }
            else
            {
                // Return error response for invalid credentials
                return Unauthorized(new LoginResult { Message = "Invalid email or password" });
            }
        }
        private bool IsValidUser(string email, string password)
        {
            // Perform authentication logic here, e.g., check credentials against database
            // For demonstration purposes, let's assume hardcoded credentials
            return (email == "client@example.com" && password == "password") ||
                   (email == "salesperson@example.com" && password == "password");
        }

        private string GetUserType(string email)
        {
            // Perform logic to determine user type (Client or Salesperson)
            // For demonstration purposes, let's assume hardcoded logic
            return (email == "client@example.com") ? "Client" : "Salesperson";
        }

    }
}
    