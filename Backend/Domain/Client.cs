using Backend.Interfaces;

namespace SmartTrade.Models
{
    public partial class Client
    {
        private readonly IClientService _service;

        public Client(IClientService service)
        {
            _service = service;
        }

        public IEnumerable<Client> GetAll()
        {
            return _service.GetAll();
        }

        public Client? GetById(int Email)
        {
            return _service.Get(Email);
        }

        public void CreateClient(Client client)
        {
            _service.Create(client);
        }

        public void EditClient(int Email, Client client)
        {
            _service.Set(Email, client);
        }

        public void DeleteClient(int Email)
        {
            _service.Delete(Email);
        }
    }
}