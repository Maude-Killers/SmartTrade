using SmartTrade.Models;

namespace Backend.Interfaces
{
    public interface IListService<S> : EntityService<S> where S : List
    {
        void AddProduct(Product product);
    }

}