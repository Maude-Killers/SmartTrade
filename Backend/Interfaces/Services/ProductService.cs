using SmartTrade.Models;

namespace Backend.Interfaces
{
    public interface IProductService<S, T> : EntityService<S, T> where S: Product
    {
    }
}