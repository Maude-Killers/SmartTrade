using Backend.Repositories;
using Backend.Services;
using SmartTrade.Models;

namespace Backend.Domain.DesignPattern.FactoryMethod
{
    public class LaterListFactory : ListFactory
    {
        public override List AddProduct(Product product)
        {
            var dbContext = AppServices.CreateDbContext();
            return new LaterList(new LaterListService(new LaterListRepository(dbContext)));
        }
        public override List DeleteProduct(Product product)
        {
            var dbContext = AppServices.CreateDbContext();
            return new LaterList(new LaterListService(new LaterListRepository(dbContext)));
        }
    }
}
