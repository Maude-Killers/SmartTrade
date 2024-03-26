using SmartTrade.Models;

namespace Backend.Interfaces
{
    public interface IProductRepository<S> : EntityRepository<Product> where S : Product
    {
    }
}