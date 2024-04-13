using Backend.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SmartTrade.Models;

namespace Backend.Services
{
    public class WishListService : IWishListService
    {
        private readonly IWishListRepository _repository;
        private readonly IPersonRepository _personrepository;

        public WishListService(IWishListRepository repository, IPersonRepository personrepository)
        {
            _repository = repository;
            _personrepository = personrepository;
        }

        public void AddProduct(Product product, string email)
        {
           _repository.AddProduct(product, email); 
        }

        public void DeleteProduct(Product product, string email)
        {
            _repository.DeleteProduct(product, email);
        }

        public void Create(string email)
        {
            _repository.Create(email);
        }

        public void Delete(string email)
        {
            _repository.Delete(email);
        }

        public WishList? Get(string email)
        {
            return _repository.Get(email);
        }

        public IEnumerable<WishList> GetAll()
        {
            return _repository.GetAll();
        }

        
        
    }
}