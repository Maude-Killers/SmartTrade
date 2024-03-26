using Backend.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SmartTrade.Models;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {

        private readonly ILogger<ClientController> _logger;
        private readonly ClientEntity _domain;

        public ClientController(ClientEntity domain, ILogger<ClientController> logger)
        {
            _logger = logger;
            _domain = domain;
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