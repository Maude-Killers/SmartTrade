using Backend.Interfaces;
using SmartTrade.Models;

namespace Backend.Services
{
    public class LaterListService : ILaterListService
    {
        private readonly ILaterListRepository _repository;
        private readonly IClientRepository _personrepository;

        public LaterListService(ILaterListRepository repository, IClientRepository personrepository)
        {
            _repository = repository;
            _personrepository = personrepository;
        }

        public void AddProduct(Product product, string email)
        {
            var client = _personrepository.Get(email);
            _repository.AddProduct(product, client);
        }

        public void DeleteProduct(Product product, string email)
        {
            var client = _personrepository.Get(email);
            _repository.DeleteProduct(product, client);
        }

        public void Create(string email)
        {
            _repository.Create(email);
        }

        public void Delete(string email)
        {

            _repository.Delete(email);
        }

        public LaterList? Get(string email)
        {
            return _repository.Get(email);
        }

        public IEnumerable<Product> GetAll(string email)
        {
            Client person = _personrepository.Get(email);
            return _repository.GetAll(person);
        }
        public List<Product> GetProducts(string email)
        {
            Client person = _personrepository.Get(email);
            return _repository.GetProducts(person);
        }
    }
}