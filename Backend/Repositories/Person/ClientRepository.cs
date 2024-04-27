using Backend.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
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

        public Client Get(string email)
        {
            var client = _context.Client
                .Where(client => client.Email == email)
                .FirstOrDefault();

            if (client != null)
            {

                _context.Entry(client.WishList).Collection(x => x.listProducts).Load();

                return client ?? throw new ResourceNotFound("Client email don't exists", email);
            }
            throw new ResourceNotFound("Client not found", email);
        }

        public Client? GetByCredentials(string Email, string Password)
        {
            var client = _context.Client
                .Where(client => client.Email == Email && client.Password == Password)
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

            if (actualClient == null) throw new InvalidOperationException();

            actualClient.Password = client.Password;
            _context.SaveChanges();
        }
    }
}