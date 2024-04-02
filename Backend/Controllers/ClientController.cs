using Backend.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SmartTrade.Models;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/clients")]
    public class ClientController : ControllerBase
    {

        private readonly ILogger<ClientController> _logger;
        private readonly ClientEntity _domain;
        private readonly HttpClient _httpClient;

        public ClientController(ClientEntity domain, ILogger<ClientController> logger, HttpClient httpClient)
        {
            _logger = logger;
            _domain = domain;
            _httpClient = httpClient;
        }

        [HttpPost("login")]
            public async Task<ActionResult> Login([FromBody] LoginRequest loginRequest)
            {
                // Delegate authentication to AuthController
                // Call AuthController's login action and handle the response
                var response = await _httpClient.PostAsJsonAsync("/api/auth/login", loginRequest);

                if (response.IsSuccessStatusCode)
                {
                    // Handle successful login
                    var loginResult = await response.Content.ReadAsAsync<LoginResult>();
                    return Ok(loginResult);
                }
                else
                {
                    // Handle failed login
                    return BadRequest("Invalid email or password");
                }
            }

        

        [HttpGet(Name = "GetClient")]
        public IEnumerable<Client> Get()
        {
            return _domain.GetAll();
        }

        [HttpGet("/client/{Email}", Name = "GetClientByEmail")]
        public ActionResult<Client> Get(int Email)
        {
            var client = _domain.GetById(Email);

            if (client == null)
            {
                return NotFound();
            }

            return client;
        }

        [HttpPost(Name = "CreateClient")]
        public void Post(Client client)
        {
            _domain.CreateClient(client);
        }

        [HttpPut("/client/{Email}", Name = "EditClient")]
        public void Put(int Email, Client client)
        {
            _domain.EditClient(Email, client);
        }

        [HttpDelete("/client/{Email}", Name = "DeleteClient")]
        public void Delete(int Email)
        {
            _domain.DeleteClient(Email);
        }
    }
}