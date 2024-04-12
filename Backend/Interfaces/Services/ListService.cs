using SmartTrade.Models;

namespace Backend.Interfaces
{
    public interface IListService<S> : EntityService<S, int> where S : List
    {
        void AddProduct(Product product);
    }

}