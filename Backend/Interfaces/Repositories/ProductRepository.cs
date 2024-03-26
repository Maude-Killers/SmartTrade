using SmartTrade.Models;

namespace Backend.Interfaces
{
    public interface IProductRepository<S> : EntityRepository<S> where S : Product
    {
    }
}