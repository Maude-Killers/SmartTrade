using Backend.Interfaces;
using SmartTrade.Models;

namespace Backend.Services
{
    public class WishListService : IWishListService
    {
        private readonly IWishListRepository _repository;

        public WishListService(IWishListRepository repository)
        {
            _repository = repository;
        }

        public void AddProduct(Product product)
        {
           _repository.AddProduct(product); 
        }

        public void DeleteProduct(Product product)
        {
            _repository.DeleteProduct(product);
        }

        public void Create(WishList item)
        {
            _repository.Create(item);
        }

        public void Delete(WishList item)
        {
            _repository.Delete(item);
        }

        public WishList? Get(string Email)
        {
            return _repository.Get(Email);
        }

        public IEnumerable<WishList> GetAll()
        {
            return _repository.GetAll();
        }

        
        
    }
}