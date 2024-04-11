using SmartTrade.Models;

namespace Backend.Interfaces
{
    public interface IProductRepository<S, T> : EntityRepository<S, T> where S : Product
    {
    }
}