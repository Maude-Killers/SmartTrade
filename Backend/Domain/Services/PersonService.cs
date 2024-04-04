using Backend.Interfaces;
using Microsoft.AspNetCore.Components;
using SmartTrade.Models;


namespace Backend.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _repository;

        [Inject]
        private IClientRepository _clientRepository { get; set; }
        [Inject]
        private ISalesPersonRepository _salespersonRepository { get; set; }

        public PersonService(IPersonRepository repository)
        {
            _repository = repository;
        }

        public void Create(Person item)
        {
            _repository.Create(item);
        }

        public void Delete(string Email)
        {
            _repository.Delete(Email);
        }

        public Person? Get(string Email)
        {
            return _repository.Get(Email);
        }

        public IEnumerable<Person> GetAll()
        {
            return _repository.GetAll();
        }

        public void Set(string Email, Person item)
        {
            _repository.Set(Email, item);
        }

        public Person GetPersonByCredentials(string email, string password)
        {
            var client = _clientRepository.Get(email);
            if (client != null)
            {
                return client; 
            }

            var salesman = _salespersonRepository.Get(email);
            if (salesman != null)
            {
                return salesman;
            }

            return null;
        }
    }
}