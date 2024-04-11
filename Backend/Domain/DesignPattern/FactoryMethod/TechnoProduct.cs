using Backend.Repositories;
using Backend.Services;
using Microsoft.AspNetCore.Http;
using SmartTrade.Models;

namespace Backend.Domain.DesignPattern
{
    public class TechnoProductFactory : ProductFactory
    {
        public override Product CreateProduct()
        {
            var dbContext = AppServices.CreateDbContext();
            return new TechnoProduct(new TechnoProductService(new TechnoProductRepository(dbContext)));
        }
    }

}
