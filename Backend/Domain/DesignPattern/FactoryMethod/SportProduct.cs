using SmartTrade.Models;

namespace Backend.Domain.DesignPattern
{
    public class SportProductFactory : ProductFactory
    {
        public override Product CreateProduct()
        {
            return new SportProduct();
        }
    }

}
