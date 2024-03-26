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

        public void Delete(int Email)
        {
            _repository.Delete(Email);
        }

        public Client? Get(int Email)
        {
            return _repository.Get(Email);
        }

        public IEnumerable<Client> GetAll()
        {
            return _repository.GetAll();
        }

        public void Set(int Email, Client item)
        {
            _repository.Set(Email, item);
        }
    }
}