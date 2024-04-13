using Backend.Repositories;
using Backend.Services;
using SmartTrade.Models;

namespace Backend.Domain.DesignPattern.FactoryMethod
{
    public class WishListFactory : ListFactory
    {
        public override List CreateList()
        {
            var dbContext = AppServices.CreateDbContext();
            var domain = new WishList();
            return new WishList(new WishListService(new WishListRepository(dbContext,domain)));
        }
    }
}
