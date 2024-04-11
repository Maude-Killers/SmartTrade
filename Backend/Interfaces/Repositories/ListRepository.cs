using SmartTrade.Models;

namespace Backend.Interfaces
{
    public interface IListRepository<S> : EntityRepository<S, int> where S : List
    {
    }
}