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
    public class MockProductRepository : IProductRepository
    {
        private readonly List<Product> _products;

        public MockProductRepository()
        {
            _products = new List<Product>
            {
                new Product
                {
                    Product_code = 1,
                    Name = "Producto 1",
                    Price = 10
                }
            };
        }

        public void Create(Product item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Product Get(int productCode)
        {
            return _products.FirstOrDefault(p => p.Product_code == productCode);
        }

        public List<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GroceryProduct> GetAllGroceryProducts()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SportProduct> GetAllSportProducts()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TechnoProduct> GetAllTechnoProducts()
        {
            throw new NotImplementedException();
        }

        public void Set(int id, Product item)
        {
            throw new NotImplementedException();
        }
    }
}
