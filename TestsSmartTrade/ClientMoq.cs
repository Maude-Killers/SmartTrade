using Xunit;
using Moq;
using Backend.Models;
using Backend.Interfaces;
using Backend.Repositories;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Backend.Database;

namespace TestsSmartTrade
{
    public class MockClientRepository : IClientRepository
    {
        private readonly List<Client> _clients;
        private readonly IListRepository _moqlistRepository;

        public MockClientRepository()
        {
            _moqlistRepository = new MockListRepository();
            _clients = new List<Client>
            {
                new Client
                {
                    Email = "prueba1@prueba.com",
                    Password = "cliente1",
                    FullName = "Cliente 1",
                    PhoneNumber = 654654655,
                }
            };
            new WishListEntity
            {
                List_code = 1,
                Name = "WishList",
                ClientEmail = "prueba1@prueba.com"
            };
        }

        public void Create(Client item)
        {
            throw new NotImplementedException();
        }
        public void Delete(string id)
        {
            throw new NotImplementedException();
        }
        public Client Get(string email)
        {
            return _clients.FirstOrDefault(c => c.Email == email);
        }
        public List<Client> GetAll()
        {
            throw new NotImplementedException();
        }
        public void Set(string id, Client item)
        {
            throw new NotImplementedException();
        }
    }
}
