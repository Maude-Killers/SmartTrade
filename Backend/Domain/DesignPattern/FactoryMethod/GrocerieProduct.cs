using Microsoft.AspNetCore.Http;
using SmartTrade.Models;

namespace Backend.Domain.DesignPattern.FactoryMethod
{
    public class GrocerieProductFActory : ProductFactory
    {
        public override Product CreateProduct()
        {
            return new GrocerieProduct();
        }
    }
}
