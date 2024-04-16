﻿using Backend.Interfaces;

namespace SmartTrade.Models
{
    public partial class WishList : List
    {
        private readonly IListService<WishList, string> _service;

        public WishList(IWishListService service)
        {
            _service = service;
        }

        public override IEnumerable<WishList> GetAll()
        {
            return _service.GetAll();
        }

        public override WishList? GetByEmail(string Email)
        {
            return _service.Get(Email);
        }
        
        public override void CreateList(string Email)
        {
            _service.Create(Email);
        }

        public override void DeleteList(string Email)
        {
            _service.Delete(Email);
        }

        public override void AddProduct(Product product, string Email) 
        { 
            _service.AddProduct(product, Email);
        }

        public override void DeleteProduct(Product product, string Email)
        {
            _service.DeleteProduct(product, Email);
        }

    }
}