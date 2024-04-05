using Backend.Interfaces;
using Backend.Repositories;
using Microsoft.AspNetCore.Components;
using SmartTrade.Models;


namespace Backend.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _repository;
        private readonly IClientRepository _clientRepository;
        private readonly ISalesPersonRepository _salespersonRepository;

        public PersonService(IPersonRepository repository, IClientRepository clientRepository, ISalesPersonRepository salesRepository)
        {
            _repository = repository;
            _clientRepository = clientRepository;
            _salespersonRepository = salesRepository;
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

        public Person? GetPersonByCredentials(string email, string password)
        {
            ClientRepository castedClientRepository = _clientRepository as ClientRepository;
            var client = castedClientRepository?.GetByCredentials(email, password);
            if (client != null)
            {
                return client; 
            }

            SalesPersonRepository castedSalesRepository = _salespersonRepository as SalesPersonRepository;
            var salesman = castedSalesRepository?.GetByCredentials(email, password);
            if (salesman != null)
            {
                return salesman;
            }

            return null;
        }
    }
}