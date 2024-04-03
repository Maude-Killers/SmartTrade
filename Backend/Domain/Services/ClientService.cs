using Backend.Interfaces;
using SmartTrade.Models;

namespace Backend.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _repository;

        public ClientService(IClientRepository repository)
        {
            _repository = repository;
        }

        public void Create(Client item)
        {
            _repository.Create(item);
        }

        public void Delete(string Email)
        {
            _repository.Delete(Email);
        }

        public Client? Get(string Email)
        {
            return _repository.Get(Email);
        }

        public IEnumerable<Client> GetAll()
        {
            return _repository.GetAll();
        }

        public void Set(string Email, Client item)
        {
            _repository.Set(Email, item);
        }
    }
}