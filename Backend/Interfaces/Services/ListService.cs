using SmartTrade.Models;

namespace Backend.Interfaces
{
    public interface IListService<List, T> 
    {
        void AddProduct(Product product, string Email);
        void Create(string Email);
        IEnumerable<List> GetAll();
        List Get(T item);

        void Delete(string Email);

        void DeleteProduct(Product product, string Email);
    }

}