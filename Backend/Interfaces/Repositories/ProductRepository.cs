using SmartTrade.Models;

namespace Backend.Interfaces
{
    public interface IProductRepository<S> : EntityRepository<S, int> where S : Product
    {
    }
}