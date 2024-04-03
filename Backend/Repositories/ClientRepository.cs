using Backend.Interfaces;
using SmartTrade.Models;

namespace Backend.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly AppDbContext _context;

        public ClientRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Create(Client client)
        {
            _context.Client.Add(client);
            _context.SaveChanges();
        }

        public void Delete(string Email)
        {
            var targetClient = _context.Client
                .Where(client => client.Email == Email)
                .FirstOrDefault();

            if (targetClient == null) throw new InvalidOperationException();

            _context.Client.Remove(targetClient);
            _context.SaveChanges();
        }

        public Client? Get(string Email)
        {
            var client = _context.Client
                .Where(client => client.Email == Email)
                .FirstOrDefault();

            return client;
        }

        public IEnumerable<Client> GetAll()
        {
            return _context.Client.ToList();
        }

        public void Set(string Email, Client client)
        {
            var actualClient = _context.Client
                .Where(client => client.Email == Email)
                .FirstOrDefault();

            if (actualClient== null) throw new InvalidOperationException();

            actualClient.Password = client.Password;
            _context.SaveChanges();
        }
    }
}