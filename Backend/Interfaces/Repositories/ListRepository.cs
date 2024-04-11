using SmartTrade.Models;

namespace Backend.Interfaces
{
    public interface IListRepository<S> : EntityRepository<S> where S : List
    {
    }
}