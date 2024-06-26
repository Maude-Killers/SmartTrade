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

        public void AddProduct(Product product, Client client)
        {
            _context.Entry(client).Reference(x => x.WishList).Load();
            var wishList = client.WishList;
            var existsProduct = _context.Products.Where(item => item.Product_code == product.Product_code).FirstOrDefault();
            if (existsProduct == null)
            {
                throw new ResourceNotFound("product doesn't exists", product);
            }
            
            _context.ListProducts.Add(new ListProduct { List_code = wishList.List_code, Product_code = product.Product_code });
            _context.SaveChanges();
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

        public List<Product> GetProducts(Client client)
        {
            _context.Entry(client).Reference(client => client.WishList).Load();
            var listCodes = _context.ListProducts
                .Include(lp => lp.Product)
                .Include(lp => lp.Product.Images)
                .Where(lp => lp.List_code == client.WishList.List_code)
                .ToList();
            return listCodes.Select(lc => lc.Product).ToList();
        }
    }
}