using SmartTrade.Models;

namespace Backend.Interfaces
{
    public interface IListRepository<List, T>
    {
        void AddProduct(Product product, Client client);
        void Create(string email);
        IEnumerable<Product> GetAll(Client client);
        List Get(string email);

        void Delete(string email);

        void DeleteProduct(Product product, Client client);
    }
}