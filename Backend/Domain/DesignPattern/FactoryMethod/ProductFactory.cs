using SmartTrade.Models;

namespace Backend.Domain.DesignPattern
{
    public abstract class ProductFactory
    {
        public abstract Product CreateProduct();
    }
}