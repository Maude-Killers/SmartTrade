using Backend.Repositories;
using Backend.Services;
using SmartTrade.Models;

namespace Backend.Domain.DesignPattern.FactoryMethod
{
    public class WishListFactory : ListFactory
    {
        public override List AddProduct(Product product)
        {
            var dbContext = AppServices.CreateDbContext();
            return new WishList(new WishListService(new WishListRepository(dbContext)));
        }
        public override List DeleteProduct(Product product)
        {
            var dbContext = AppServices.CreateDbContext();
            return new WishList(new WishListService(new WishListRepository(dbContext)));
        }
    }
}
