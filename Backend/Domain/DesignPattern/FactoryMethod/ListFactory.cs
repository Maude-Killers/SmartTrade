using SmartTrade.Models;

namespace Backend.Domain.DesignPattern
{
    public abstract class ListFactory
    {
        public abstract List AddProduct();
        public abstract List DeleteProduct();

    }
}