using Microsoft.AspNetCore.Http;
using SmartTrade.Models;

namespace Backend.Domain.DesignPattern
{
    public class TechnoProductFactory : ProductFactory
    {
        public override Product CreateProduct()
        {
            return new TechnoProduct();
        }
    }

}
