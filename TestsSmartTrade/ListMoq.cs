using Xunit;
using Moq;
using Backend.Models;
using Backend.Interfaces;
using Backend.Repositories;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Backend.Database;

namespace TestsSmartTrade
{
    public class MockListRepository : IListRepository
    {
        private readonly List<WishListEntity> _wishList;
        private readonly List<GiftListEntity> _giftList;
        private readonly List<LaterListEntity> _laterList;
        private readonly List<ShoppingCartEntity> _cartList;

        public MockListRepository()
        {
            _wishList = new List<WishListEntity>();
            _giftList = new List<GiftListEntity>();
            _laterList = new List<LaterListEntity>();  
            _cartList = new List<ShoppingCartEntity>();
            {
                new ShoppingCartEntity
                {
                    List_code = 1,
                    Name = "Cart",
                    ClientEmail = "prueba1@prueba.com",
                    listProducts = new List<ListProduct>
                    {
                        new ListProduct { Product_code = 1, List_code = 1 }
                    }
                };
            };


        }
        public void AddProduct(Product product, Client client)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(Product product, Client client)
        {
                var cartlist = _cartList.FirstOrDefault(ct => ct.ClientEmail == client.Email);
                if (cartlist != null)
                {

                var productList = cartlist.listProducts
                .Where(listProduct => listProduct.Product_code == product.Product_code)
                .FirstOrDefault();

      
                    if (product != null)
                    {
                        cartlist.listProducts.Remove(productList);
                    }
                }
        }

        public List<Product> GetProducts(Client client)
        {
            throw new NotImplementedException();
        }
    }
}
