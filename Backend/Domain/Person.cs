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

        public IEnumerable<Person> GetPersons()
        {
            return _service.GetAll();
        }

        public Person? GetPersonById(string Email)
        {
            return _service.Get(Email);
        }

        public void CreatePerson(Person Person)
        {
            _service.Create(Person);
        }

        public void EditPerson(string Email, Person Person)
        {
            _service.Set(Email, Person);
        }

        public void DeletePerson(string Email)
        {
            _service.Delete(Email);
        }

        Person? ValidateEmail(string email, string password)
        {
            PersonService personService = _service as PersonService;
            Person p = personService.GetPersonByCredentials(email, password);
            return p;
        }
    }
}