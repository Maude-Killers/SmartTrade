using Backend.Repositories;
using Backend.Services;
using SmartTrade.Models;

namespace Backend.Domain.DesignPattern.FactoryMethod
{
    public class GenericProductFactory : ProductFactory
    {
        public override Product CreateProduct()
        {
            var dbContext = AppServices.CreateDbContext();
            return new Product(new ProductService<Product>(new ProductRepository(dbContext)));
        }
    }
}
