using Microsoft.AspNetCore.Mvc;
using SmartTrade.Models;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/salesperson")]
    public class SalesPersonController : ControllerBase
    {

        private readonly ILogger<SalesPersonController> _logger;
        private readonly SalesPersonEntity _domain;
        private readonly HttpClient _httpClient;

        public SalesPersonController(SalesPersonEntity domain, ILogger<SalesPersonController> logger, HttpClient httpClient)
        {
            _logger = logger;
            _domain = domain;
            _httpClient = httpClient;
        }

        // [HttpPost("login")]
        // public async Task<ActionResult> Login([FromBody] LoginRequest loginRequest)
        // {
        //     // Delegate authentication to AuthController
        //     // Call AuthController's login action and handle the response
        //     var response = await _httpClient.PostAsJsonAsync("/api/auth/login", loginRequest);

        //     if (response.IsSuccessStatusCode)
        //     {
        //         // Handle successful login
        //         var loginResult = await response.Content.ReadAsAsync<LoginResult>();
        //         return Ok(loginResult);
        //     }
        //     else
        //     {
        //         // Handle failed login
        //         return BadRequest("Invalid email or password");
        //     }
        // }



        [HttpGet(Name = "GetSalesPerson")]
        public IEnumerable<SalesPerson> Get()
        {
            return _domain.GetAll();
        }

        [HttpGet("salesPerson/{Email}", Name = "GetSalesPersonByEmail")]
        public ActionResult<SalesPerson> Get(int Email)
        {
            var salesPerson = _domain.GetById(Email);

            if (salesPerson == null)
            {
                return NotFound();
            }

            return salesPerson;
        }

        [HttpPost(Name = "CreateSalesPerson")]
        public void Post(SalesPerson salesPerson)
        {
            _domain.CreateSalesPerson(salesPerson);
        }

        [HttpPut("/salesPerson/{Email}", Name = "EditSalesPerson")]
        public void Put(int Email, SalesPerson salesPerson)
        {
            _domain.EditSalesPerson(Email, salesPerson);
        }

        [HttpDelete("/salesPerson/{Email}", Name = "DeleteSalesPerson")]
        public void Delete(int Email)
        {
            _domain.DeleteSalesPerson(Email);
        }
    }
}