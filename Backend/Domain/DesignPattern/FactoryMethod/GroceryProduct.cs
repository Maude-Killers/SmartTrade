using SmartTrade.Models;

namespace Backend.Domain.DesignPattern.FactoryMethod
{
    public class GroceryProductFactory : ProductFactory
    {
        public override Product CreateProduct()
        {
            return new GroceryProduct();
        }
    }
}
