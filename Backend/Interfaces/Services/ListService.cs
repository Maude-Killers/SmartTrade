using SmartTrade.Models;

namespace Backend.Interfaces
{
    public interface IListService<List, T> 
    {
        void AddProduct(Product product);
        void Create(List item);
        IEnumerable<List> GetAll();
        List? Get(T item);

        void Delete(List item);

        void DeleteProduct(Product product);
    }

}