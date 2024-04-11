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
           
        }

        public void Create(WishList item)
        {
            _repository.Create(item);
        }

        public void Delete(int List_code)
        {
            _repository.Delete(List_code);
        }

        public WishList? Get(int List_code)
        {
            return _repository.Get(List_code);
        }

        public IEnumerable<WishList> GetAll()
        {
            return _repository.GetAll();
        }

        public void Set(int List_code, WishList item)
        {
            _repository.Set(List_code, item);
        }

        
    }
}