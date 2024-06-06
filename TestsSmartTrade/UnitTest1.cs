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
    public class UnitTest1
    {
        private readonly IClientRepository _moqclientRepository;
        private readonly IProductRepository _moqproductRepository;

        public UnitTest1()
        {
            _moqclientRepository = new MockClientRepository();
            _moqproductRepository = new MockProductRepository();
        }

        [Fact]
        public void AñadirProductoListaDeseos()
        {
            String Email = "prueba1@prueba.com";
            Client client= _moqclientRepository.Get(Email);
            int Product_code = 1;
            Product product= _moqproductRepository.Get(Product_code);
            if (client.WishList == null) { 
                client.WishList = new List<Product>();
            }
            client.AddProductToWishList(product.Product_code);
            Assert.Single(client.WishList);
            Assert.Contains(product, client.WishList);

        }

        [Fact]
        public void EliminarProductoCarrito()
        {
            String Email = "prueba1@prueba.com";
            Client client = _moqclientRepository.Get(Email);
            int Product_code = 1;
            Product product = _moqproductRepository.Get(Product_code);
            if (client.WishList == null)
            {
                client.WishList = new List<Product>();
            }
            client.RemoveProductToWishList(Product_code);
            Assert.Single(client.WishList);
            Assert.DoesNotContain(product, client.WishList);

        }
        

    }
}
