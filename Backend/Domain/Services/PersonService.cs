using Backend.Interfaces;
using Backend.Repositories;
using SmartTrade.Models;


namespace Backend.Services
{
    public class PersonService : IPersonService
    {
        private readonly IClientRepository _clientRepository;
        private readonly ISalesPersonRepository _salespersonRepository;

        public PersonService(IClientRepository clientRepository, ISalesPersonRepository salesRepository)
        {
            _clientRepository = clientRepository;
            _salespersonRepository = salesRepository;
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