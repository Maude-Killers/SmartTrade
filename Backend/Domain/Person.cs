using Backend.Interfaces;
using Backend.Services;

namespace SmartTrade.Models
{
    public partial class PersonEntity
    {
        private readonly IPersonService _service;

        public PersonEntity(IPersonService service)
        {
            _service = service;
        }

        public IEnumerable<Person> GetAll()
        {
            return _service.GetAll();
        }

        public Person? GetById(int Email)
        {
            return _service.Get(Email);
        }

        public void CreatePerson(Person person)
        {
            _service.Create(person);
        }

        public void EditPerson(int Email, Person person)
        {
            _service.Set(Email, person);
        }

        public void DeletePerson(int Email)
        {
            _service.Delete(Email);
        }
    }
}