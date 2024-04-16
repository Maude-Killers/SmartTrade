using Backend.Repositories;
using Backend.Services;
using SmartTrade.Models;

namespace Backend.Domain.DesignPattern.FactoryMethod
{
    public class LaterListFactory : ListFactory
    {
        public override List CreateList()
        {
            var dbContext = AppServices.CreateDbContext();
            return new LaterList(new LaterListService(new LaterListRepository(dbContext), new ClientRepository(dbContext)));
        }
    }
}
