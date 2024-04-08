using Backend.Interfaces;
using Backend.Services;

namespace SmartTrade.Models
{
    public partial class Person
    {
        private readonly IPersonService _service;

        public Person(IPersonService service)
        {
            _service = service;
        }

        public Person? ValidateEmail(string email, string password)
        {
            PersonService personService = _service as PersonService;
            Person p = personService.GetPersonByCredentials(email, password);
            return p;
        }
    }
}