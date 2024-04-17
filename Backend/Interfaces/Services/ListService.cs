using SmartTrade.Models;

namespace Backend.Interfaces
{
    public interface IListService<List, T> 
    {
        void AddProduct(Product product, string email);
        void Create(string email);
        IEnumerable<Product> GetAll(string email);
        List Get(T item);

        void Delete(string email);

        void DeleteProduct(Product product, string email);
    }

}