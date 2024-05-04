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
            WishList wishlist = client.WishList;
            var isInList = wishlist.listProducts.Where(x => x.Product_code == product.Product_code).FirstOrDefault();
            if (isInList != null)
            {
                throw new ResourceNotFound("product is already in WishList", product);
            }
            _context.ListProducts.Add(new ListProduct { List_code = wishlist.List_code, Product_code = product.Product_code });
            _context.SaveChanges();
        }

        public void DeleteProduct(Product product, Client client)
        {
            var wishlist = client.WishList;
            var productList = wishlist.listProducts
                .Where(listProduct => listProduct.Product_code == product.Product_code)
                .FirstOrDefault();

            if (wishlist == null || productList == null) throw new ResourceNotFound("list or productList not found", product);

            _context.ListProducts.Remove(productList);
            _context.SaveChanges();
        }

        public List<Product> GetProducts(Client client)
        {
            _context.Entry(client).Reference(client => client.WishList).Load();
            var listCodes = _context.ListProducts
                .Include(lp => lp.Product).ThenInclude(p => p.Images)
                .Where(lp => lp.List_code == client.WishList.List_code)
                .ToList();
                
            return listCodes.Select(lc => lc.Product).ToList();
        }
    }
}