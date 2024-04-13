using Backend.Controllers;
using Backend.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartTrade.Models;

namespace Backend.Repositories
{
    public class WishListRepository : IWishListRepository
    {
        private readonly AppDbContext _context;
        private readonly WishList _domain;

        public WishListRepository(AppDbContext context, WishList domain)
        {
            _context = context;
            _domain = domain;
        }

        public void Create(string Email)
        {
            _context.WishList.Add(_domain.GetByEmail(Email));
            _context.SaveChanges();
        }

        public void Delete(string Email)
        {
            var targetWishList = _domain.GetByEmail(Email);

            if (targetWishList == null) throw new InvalidOperationException();

            _context.WishList.Remove(targetWishList);
            _context.SaveChanges();
        }

        public void AddProduct(Product product, string Email)
        {
            //_context.WishList.Products.Add(product);
            var wishlist = _domain.GetByEmail(Email);

            if (wishlist != null)
            {
                _context.Entry(wishlist).Collection(w => w.Products).Load();
                wishlist.Products.Add(product);
                _context.SaveChanges();
            }
        }
        public void DeleteProduct(Product product, string Email) 
        {
            var wishlist = _domain.GetByEmail(Email);

            if (wishlist != null && wishlist.Products.Contains(product))
            {
                _context.Entry(wishlist).Collection(w => w.Products).Load();
                wishlist.Products.Remove(product);
                _context.SaveChanges();
            }

        }

        public WishList? Get(string Email)
        {
            WishList targetWishList = _domain.GetByEmail(Email);
            return targetWishList;
        }

        public IEnumerable<WishList> GetAll()
        {
            return _context.WishList.ToList();
        }

        public void Set(int List_code, WishList item)
        {
            var actualWishList = _context.WishList
                .Where(item => item.List_code == List_code)
                .FirstOrDefault();
        }

    }
}