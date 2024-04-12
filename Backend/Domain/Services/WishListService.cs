using Backend.Interfaces;
using Microsoft.AspNetCore.Mvc;
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

        public void AddProduct(Product product, string Email)
        {
           _repository.AddProduct(product, Email); 
        }

        public void DeleteProduct(Product product, string Email)
        {
            _repository.DeleteProduct(product, Email);
        }

        public void Create(string Email)
        {
            _repository.Create(Email);
        }

        public void Delete(string Email)
        {
            _repository.Delete(Email);
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