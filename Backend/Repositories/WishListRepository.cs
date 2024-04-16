﻿using Backend.Interfaces;
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

        public void AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

                // Este metodo no deberia ser necesario porque todos los clientes tienen una wishList por defecto
        public void Create(string Email)
        {
            var cliente = _context.Client
            .Where(item => item.Email == Email)
            .FirstOrDefault();

            _context.WishList.Add(cliente.WishList);
            _context.SaveChanges();
        }

        // Este metodo realmente hace falta? podemos borrarle la lista de deseos a un usuario?
        public void Delete(string Email)
        {
            var cliente = _context.Client
            .Where(item => item.Email == Email)
            .FirstOrDefault();


            if (cliente.WishList == null) throw new InvalidOperationException();

            _context.WishList.Remove(cliente.WishList);
            _context.SaveChanges();
        }

        public void AddProduct(Product product, Client client)
        {
            _context.Entry(client).Reference(x => x.WishList).Load();
            var wishList = client?.WishList;

            if (wishList != null)
            {
                var existsProduct = _context.Products.Where(item => item.Product_code == product.Product_code).FirstOrDefault();
                if (existsProduct == null)
                {
                    _context.Products.Add(product);
                    _context.SaveChanges();
                }
                _context.ListProducts.Add(new ListProduct { List_code = wishList.List_code, Product_code = product.Product_code });
                _context.SaveChanges();
            }
        }

        public void DeleteProduct(Product product, Client client)
        {
            var wishlist = client.WishList;
            var productList = _context.ListProducts
                .Where(listProduct => listProduct.Product_code == product.Product_code && listProduct.List_code == wishlist.List_code)
                .FirstOrDefault();

            if (wishlist != null && productList != null)
            {
                _context.ListProducts.Remove(productList);
                _context.SaveChanges();
            }
        }

        public WishList? Get(string Email)
        {
            var cliente = _context.Client
            .Where(item => item.Email == Email)
            .FirstOrDefault();
            var wishList = cliente.WishList;
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

        public List<Product> GetProducts(Person person)
        {
            var cliente = (Client) person;

            _context.Entry((Client)person).Reference(client => client.WishList).Load();

            var listCodes = _context.ListProducts
                .Include(lp => lp.Product)
                .Include(lp => lp.Product.Images)
                .Where(lp => lp.List_code == cliente.WishList.List_code)
                .ToList();
            
            return listCodes.Select(lc => lc.Product).ToList();
        }
    }
}