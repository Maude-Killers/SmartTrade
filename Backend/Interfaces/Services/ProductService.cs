using SmartTrade.Models;

namespace Backend.Interfaces
{
    public interface IProductService<S> : EntityService<S, int> where S: Product
    {
    }
}