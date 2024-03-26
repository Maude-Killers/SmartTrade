using Backend.Interfaces;
using SmartTrade.Models;

namespace Backend.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _repository;

        public PersonService(IPersonRepository repository)
        {
            _repository = repository;
        }

        public void Create(Person item)
        {
            _repository.Create(item);
        }

        public void Delete(int Email)
        {
            _repository.Delete(Email);
        }

        public Person? Get(int Email)
        {
            return _repository.Get(Email);
        }

        public IEnumerable<Person> GetAll()
        {
            return _repository.GetAll();
        }

        public void Set(int Email, Person item)
        {
            _repository.Set(Email, item);
        }
    }
}