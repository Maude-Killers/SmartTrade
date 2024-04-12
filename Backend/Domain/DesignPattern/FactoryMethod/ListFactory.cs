using SmartTrade.Models;

namespace Backend.Domain.DesignPattern
{
    public abstract class ListFactory
    {
        public abstract List AddProduct(Product product);
        public abstract List DeleteProduct(Product product);

    }
}