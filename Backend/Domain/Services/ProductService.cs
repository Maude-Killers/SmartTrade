using Backend.Interfaces;
using SmartTrade.Models;

namespace Backend.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository<Product> _repository;

        public ProductService(IProductRepository<Product> repository)
        {
            _repository = repository;
        }

        public void Create(Product item)
        {
            _repository.Create(item);
        }

        public void Delete(int Product_code)
        {
            _repository.Delete(Product_code);
        }

        public Product? Get(int Product_code)
        {
            return _repository.Get(Product_code);
        }

        public IEnumerable<Product> GetAll()
        {
            return _repository.GetAll();
        }

        public void Set(int Product_code, Product item)
        {
            _repository.Set(Product_code, item);
        }
    }
}