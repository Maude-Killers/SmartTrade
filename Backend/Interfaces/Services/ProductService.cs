using SmartTrade.Models;

namespace Backend.Interfaces
{
    public interface IProductService<S> : EntityService<S> where S: Product
    {
    }

}