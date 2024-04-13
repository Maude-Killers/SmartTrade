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

        public WishListRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Create(string Email)
        {
            var cliente= _context.Client
            .Where(item => item.Email == Email)
            .FirstOrDefault();
            
            _context.WishList.Add(cliente.wishList);
            _context.SaveChanges();
        }

        public void Delete(string Email)
        {
            var cliente = _context.Client
            .Where(item => item.Email == Email)
            .FirstOrDefault();


            if (cliente.wishList == null) throw new InvalidOperationException();

            _context.WishList.Remove(cliente.wishList);
            _context.SaveChanges();
        }

        public void AddProduct(Product product, string Email)
        {
            //_context.WishList.Products.Add(product);
            var cliente = _context.Client
            .Where(item => item.Email == Email)
            .FirstOrDefault();
            var wishList = cliente.wishList;

            if (wishList != null)
            {
                _context.Entry(wishList).Collection(w => w.Products).Load();
                wishList.Products.Add(product);
                _context.SaveChanges();
            }
        }
        public void DeleteProduct(Product product, string Email) 
        {
            var cliente = _context.Client
            .Where(item => item.Email == Email)
            .FirstOrDefault();
            var wishlist = cliente.wishList;

            if (wishlist != null && wishlist.Products.Contains(product))
            {
                _context.Entry(wishlist).Collection(w => w.Products).Load();
                wishlist.Products.Remove(product);
                _context.SaveChanges();
            }

        }

        public WishList? Get(string Email)
        {
            var cliente = _context.Client
            .Where(item => item.Email == Email)
            .FirstOrDefault();
            var wishList = cliente.wishList;
            return wishList;
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