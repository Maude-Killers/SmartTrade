using Backend.Interfaces;
using SmartTrade.Models;

namespace Backend.Services
{
    public class ProductService<T> : IProductService<T> where T : Product
    {
        private readonly IProductRepository<T> _repository;

        public ProductService(IProductRepository<T> repository)
        {
            _repository = repository;
        }

        public void Create(T item)
        {
            _repository.Create(item);
        }

        public void Delete(int Product_code)
        {
            _repository.Delete(Product_code);
        }

        public T? Get(int Product_code)
        {
            return _repository.Get(Product_code);
        }

        public IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public void Set(int Product_code, T item)
        {
            _repository.Set(Product_code, item);
        }
    }
}