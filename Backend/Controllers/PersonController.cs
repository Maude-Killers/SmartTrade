using Backend.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SmartTrade.Models;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {

        private readonly ILogger<PersonController> _logger;
        private readonly PersonEntity _domain;

        public PersonController(PersonEntity domain, ILogger<PersonController> logger)
        {
            _logger = logger;
            _domain = domain;
        }

        [HttpGet(Name = "GetPerson")]
        public IEnumerable<Person> Get()
        {
            return _domain.GetAll();
        }

        [HttpGet("/person/{Email}", Name = "GetPersonByEmail")]
        public ActionResult<Person> Get(int Email)
        {
            var person = _domain.GetById(Email);

            if (person == null)
            {
                return NotFound();
            }

            return person;
        }

        [HttpPost(Name = "CreatePerson")]
        public void Post(Person person)
        {
            _domain.CreatePerson(person);
        }

        [HttpPut("/person/{Email}", Name = "EditPerson")]
        public void Put(int Email, Person person)
        {
            _domain.EditPerson(Email, person);
        }

        [HttpDelete("/person/{Email}", Name = "DeletePerson")]
        public void Delete(int Email)
        {
            _domain.DeletePerson(Email);
        }
    }
}