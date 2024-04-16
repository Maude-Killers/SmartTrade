using Backend.Repositories;
using Backend.Services;
using SmartTrade.Models;

namespace Backend.Domain.DesignPattern.FactoryMethod
{
    public class GroceryProductFactory : ProductFactory
    {
        public override Product CreateProduct()
        {
            var dbContext = AppServices.CreateDbContext();
            return new GroceryProduct(new GroceryProductService(new GroceryProductRepository(dbContext)));
        }
    }
}
