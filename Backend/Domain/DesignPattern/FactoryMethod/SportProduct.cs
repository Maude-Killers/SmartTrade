using Backend.Repositories;
using Backend.Services;
using SmartTrade.Models;

namespace Backend.Domain.DesignPattern
{
    public class SportProductFactory : ProductFactory
    {
        public override Product CreateProduct()
        {
            var dbContext = AppServices.CreateDbContext();
            return new SportProduct(new SportProductService(new SportProductRepository(dbContext)));
        }
    }

}
