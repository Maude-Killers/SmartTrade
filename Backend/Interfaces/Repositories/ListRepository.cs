using SmartTrade.Models;

namespace Backend.Interfaces
{
    public interface IListRepository<S, T>
    {
        void AddProduct(Product product);
        void Create(S item);
        IEnumerable<S> GetAll();
        S? Get(T item);

        void Delete(S item);

        void DeleteProduct(Product product);
    }
}